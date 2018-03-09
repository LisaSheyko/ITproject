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
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            incorrectPassLabel.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dTable;
            if (nameBox.Text == "" || logBox.Text == "" || passBox1.Text == "" || comboBox.Text == "")
            {
                incorrectPassLabel.Visibility = Visibility.Visible;
                return;
            }
            dTable = dbManager.execute("select * from users where login = '" + logBox.Text + "'");
            if (dTable.Rows.Count > 0)
            {
                incorrectPassLabel.Content = "Логин занят!";
                incorrectPassLabel.Visibility = Visibility.Visible;
                return;
            }
            dbManager.execute("insert into users (login, password, name, class) values ('" +
                logBox.Text + "','" + passBox1.Text + "','" + nameBox.Text + "'," + comboBox.Text + ")");
            this.Close();
        }

        private void nameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            incorrectPassLabel.Visibility = Visibility.Hidden;
        }

        private void logBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            incorrectPassLabel.Visibility = Visibility.Hidden;
        }

        private void passBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            incorrectPassLabel.Visibility = Visibility.Hidden;
        }
    }
}
