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
        {
            InitializeComponent();
            string res = DbManager.Start();
            if (res != "")
            {
                MessageBox.Show(res);
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            incorrectPassLabel.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                sqlQuery = "SELECT * FROM User where login = '" + login + "'";
                dTable = DbManager.Execute(sqlQuery);
                if (dTable.Rows.Count == 0 || dTable.Rows[0]["password"].ToString() != pass)
                {
                    incorrectPassLabel.Visibility = Visibility.Visible;
                    return;
                }
                ((App)Application.Current).uk = dTable.Rows[0]["UK"].ToString();
                ((App)Application.Current).name = dTable.Rows[0]["name"].ToString();
                sqlQuery = "select ccode from grant where uk = " + dTable.Rows[0]["grant_uk"].ToString();
                dTable = DbManager.Execute(sqlQuery);
                ((App)Application.Current).grant_ccode = dTable.Rows[0]["ccode"].ToString();
                personalAccWindows acc = new personalAccWindows
                {
                    Title = ((App)Application.Current).name
                };
                acc.Show();
                this.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            registration reg = new registration
            {
                Owner = this
            };
            reg.ShowDialog();
        }
    }
}
