using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace Project
{
    public partial class MainWindow : Window
    {
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        public MainWindow()
        { // При инициализации окна подключаемся к бд. При необходимости создаем бд и таблицу пользователей
            InitializeComponent();
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            dbFileName = "dbSQLite";
            if (!File.Exists(dbFileName))
                SQLiteConnection.CreateFile(dbFileName);
            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;

                m_sqlCmd.CommandText = @"CREATE TABLE IF NOT EXISTS Users 
                    (id INTEGER PRIMARY KEY AUTOINCREMENT, LOGIN TEXT, PASSWORD TEXT)";
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            incorrectPassLabel.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        { // Достаем и сверяем пароль
            DataTable dTable = new DataTable();
            String sqlQuery, login = txtBoxLogin.Text, pass = passwordBox.Text;
            if (login == "" || pass == "")
            {
                incorrectPassLabel.Visibility = Visibility.Visible;
                return;
            }

            try
            {
                sqlQuery = "SELECT password FROM Users where login = '" + login + "'";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);
                if (dTable.Rows.Count == 0 || dTable.Rows[0].ItemArray[0].ToString() != pass)
                {
                    incorrectPassLabel.Visibility = Visibility.Visible;
                    return;
                }
                MessageBox.Show("END:)");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
