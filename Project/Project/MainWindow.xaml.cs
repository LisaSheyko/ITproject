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
        public MainWindow()
        { // При инициализации окна подключаемся к бд. При необходимости создаем бд и таблицу пользователей
            //((App)Application.Current)
            InitializeComponent();
            string res = dbManager.start();
            if (res != "")
            {
                MessageBox.Show(res);
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
                dTable = dbManager.execute(sqlQuery);
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            registration reg = new registration();
            reg.Owner = this;
            reg.ShowDialog();
        }
    }
}
