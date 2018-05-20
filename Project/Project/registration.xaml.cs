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
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
            DataTable dTable = DbManager.Execute("select a.seq from sqlite_sequence a where a.name = 'User'");
            logBox.Text = "User_" + dTable.Rows[0].ItemArray[0].ToString();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            incorrectPassLabel.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dTable;
            if (nameBox.Text == "" || logBox.Text == "" || passBox1.Text == "" || comboBox.Text == "")
            {
                incorrectPassLabel.Visibility = Visibility.Visible;
                return;
            }
            dTable = DbManager.Execute("select * from user where login = '" + logBox.Text + "'");
            if (dTable.Rows.Count > 0)
            {
                incorrectPassLabel.Content = "Логин занят!";
                incorrectPassLabel.Visibility = Visibility.Visible;
                return;
            }
            DbManager.ExecuteNonQ("insert into user (login, password, name, class) values ('" +
                logBox.Text + "','" + passBox1.Text + "','" + nameBox.Text + "'," + comboBox.Text + ")");
            this.Close();
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            incorrectPassLabel.Visibility = Visibility.Hidden;
        }

        private void LogBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            incorrectPassLabel.Visibility = Visibility.Hidden;
        }

        private void PassBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            incorrectPassLabel.Visibility = Visibility.Hidden;
        }
    }
}
