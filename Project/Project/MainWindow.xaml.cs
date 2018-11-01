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
            { // Если было поймано исключение с сообщением об ошибке
                MessageBox.Show(res);
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        { // При изменении полей скрывается надпись о некорректном вводе
            incorrectPassLabel.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { // Достаем и сверяем пароль
            DataTable dTable = new DataTable();
            String sqlQuery, login = txtBoxLogin.Text, pass = passwordBox.Text, uk, name;
            if (login == "" || pass == "")
            { // логин и пароль должны быть не пустые
                incorrectPassLabel.Visibility = Visibility.Visible;
                return;
            }
            try
            {
                sqlQuery = "SELECT * FROM User_sdim where login = '" + login + "'";
                dTable = DbManager.Execute(sqlQuery);
                if (dTable.Rows.Count == 0)
                { // Если запрос вернул пустую таблицу
                    incorrectPassLabel.Content = "Логин не найден в базе";
                    incorrectPassLabel.Visibility = Visibility.Visible;
                    return;
                }
                else if (dTable.Rows[0]["password"].ToString() != pass)
                { // Если пароль не совпал, выводим сообщение об ошибке и подсказку
                    incorrectPassLabel.Content = "Неверный пароль.\nПодсказка: " + dTable.Rows[0]["help4pass"].ToString();
                    incorrectPassLabel.Visibility = Visibility.Visible;
                    return;
                }
				// сохраняем в переменные uk и имя текущего пользователя
                uk = dTable.Rows[0]["UK"].ToString();
                name = dTable.Rows[0]["name"].ToString();
				// узнаем права пользователя
                sqlQuery = "select ccode from grant_sdim where uk = " + dTable.Rows[0]["grant_uk"].ToString();
                dTable = DbManager.Execute(sqlQuery);
                ((App)Application.Current).grant_ccode = dTable.Rows[0]["ccode"].ToString();
                if (((App)Application.Current).grant_ccode == "master")
                { // в зависимости от прав записываем в глобальные переменные ключ и имя пользователя
                    ((App)Application.Current).master_uk = uk;
                    ((App)Application.Current).master_name = name;
                }
                else
                {
                    ((App)Application.Current).child_name = name;
                    ((App)Application.Current).child_uk = uk;
                }
                personalAccWindows acc = new personalAccWindows
                {
                    Title = name
                };
				// вызываем окно с ЛК, закрываем начальное
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
			// вызывываем окно регистрации
            reg.ShowDialog();
        }
    }
}
