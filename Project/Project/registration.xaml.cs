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
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
            // вытаскием следующий uk для нового пользователя
            DataTable dTable = DbManager.Execute("select a.seq+1 from sqlite_sequence a where a.name = 'USER_SDIM'");
            logBox.Text = "User_" + dTable.Rows[0].ItemArray[0].ToString();
            // заполняем существующие классы из справочника
            dTable = DbManager.Execute("select distinct num from CLASS_SDIM order by num desc");
            for (int i = 0; i < dTable.Rows.Count; ++i)
                ClassNum.Items.Add(dTable.Rows[i].ItemArray[0]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dTable;
            if (nameBox.Text == "" || logBox.Text == "" || passBox1.Text == "" 
                || ClassNum.Text == "" || ClassLett.Text == "")
            {
                incorrectPassLabel.Visibility = Visibility.Visible;
                return;
            }
            dTable = DbManager.Execute("select * from user_sdim where login = '" + logBox.Text + "'");
            if (dTable.Rows.Count > 0)
            {
                incorrectPassLabel.Content = "Логин занят!";
                incorrectPassLabel.Visibility = Visibility.Visible;
                return;
            }
            // вытаскиваем нужны UK из справочника
            dTable = DbManager.Execute("select uk from class_sdim where num = " +
                ClassNum.Text + " and letter = '" + ClassLett.Text + "'");
            string class_uk = dTable.Rows[0].ItemArray[0].ToString();
            // вставляем нового пользователя в таблицу
            DbManager.ExecuteNonQ("insert into user_sdim (login, password, name, class_uk, help4pass) values ('" +
                logBox.Text + "','" + passBox1.Text + "','" + nameBox.Text + "'," +
                class_uk + ",'" + passBoxHelp.Text +"')");
            // увеличиваем кол-во учеников в классе
            DbManager.ExecuteNonQ("update class_sdim set count = (select count from class_sdim where uk = " +
                class_uk + ") + 1 where uk = " + class_uk);
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

        private void ClassNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            incorrectPassLabel.Visibility = Visibility.Hidden;
            ClassLett.Items.Clear();
            DataTable dTable = DbManager.Execute("select letter from CLASS_SDIM where num = '" +
                ClassNum.SelectedItem.ToString() + "' order by letter");
            for (int i = 0; i < dTable.Rows.Count; ++i)
                ClassLett.Items.Add(dTable.Rows[i].ItemArray[0]);
        }

        private void ClassLett_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            incorrectPassLabel.Visibility = Visibility.Hidden;
        }
    }
}
