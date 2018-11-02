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
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using System.Data;
using System.IO;

namespace Project
{
    public partial class TaskItemWindow : Window
    {
        public DataTable dTable;
        public string start_time = System.DateTime.Now.ToShortTimeString() + " " + System.DateTime.Now.ToShortDateString();

        public TaskItemWindow()
        {
            InitializeComponent();
            dTable = DbManager.Execute("select * from task_sdim where uk = " +
                ((App)Application.Current).task_uk);
            XpsDocument doc = new XpsDocument(Directory.GetCurrentDirectory() +
                "/task/" + dTable.Rows[0]["file_name"], FileAccess.Read);
            DocV.Document = doc.GetFixedDocumentSequence();
            doc.Close();
            Title = dTable.Rows[0]["ccode"].ToString();
            if (dTable.Rows[0]["help"].ToString() != "")
            {
                BtnQue.IsEnabled = true;
            }
            if (((App)Application.Current).grant_ccode == "child")
            {
                SettBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                TxtBoxAns.Text = dTable.Rows[0]["answer"].ToString();
            }
            if (dTable.Rows[0]["combo_flag"].ToString() == "Y")
            {
                string s = dTable.Rows[0]["value_mask"].ToString();
                string[] words = s.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string tmp in words)
                    ComboAnswers.Items.Add(tmp);
                ComboAnswers.IsEnabled = true;
                TxtBoxAns.IsEnabled = false;
            }
            if (((App)Application.Current).child_uk == "" || ((App)Application.Current).master_uk == "")
            {
                TxtBoxChat.IsEnabled = false;
                BtnOkChat.IsEnabled = false;
            }
        }

        private void BtnOkChat_Click(object sender, RoutedEventArgs e)
        {
            string author_uk, targ_uk;
            if (TxtBoxChat.Text != "")
            {
                if (((App)Application.Current).grant_ccode == "master")
                {
                    author_uk = ((App)Application.Current).master_uk;
                    targ_uk = ((App)Application.Current).child_uk;
                }
                else
                {
                    targ_uk = ((App)Application.Current).master_uk;
                    author_uk = ((App)Application.Current).child_uk;
                }
                DbManager.ExecuteNonQ("insert into chat_log (author_uk, targ_uk, msg, time, task_uk) values (" +
                    author_uk + ", " + targ_uk + ", '" + TxtBoxChat.Text + "', '"
                    + System.DateTime.Now.ToShortTimeString() + " " + System.DateTime.Now.ToShortDateString() +
                    "', " + ((App)Application.Current).task_uk + ")");
                TxtBoxChat.Clear();
            }
        }

        private void BtnQue_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(dTable.Rows[0]["help"].ToString());
            if (((App)Application.Current).grant_ccode == "child")
            { // в лог

            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).grant_ccode == "child")
            {
                string ans = dTable.Rows[0]["answer"].ToString();
                string end_time = System.DateTime.Now.ToShortTimeString() + " " + System.DateTime.Now.ToShortDateString();
                if (ComboAnswers.Text == ans || TxtBoxAns.Text == ans)
                {
                    BtnOk.Background = Brushes.Green;
                    DbManager.ExecuteNonQ("insert into progress_log (author_uk, targ_uk, task_uk, status_uk, " +
                        "start_time, end_time) values (" + ((App)Application.Current).child_uk + ", '" +
                        ((App)Application.Current).master_uk + "', " + ((App)Application.Current).task_uk + ", 1, " +
                        "'" + start_time + "', '" + end_time + "')");
                }
                else
                {
                    BtnOk.Background = Brushes.Red;
                    DbManager.ExecuteNonQ("insert into progress_log (author_uk, targ_uk, task_uk, status_uk, " +
                        "start_time, end_time) values (" + ((App)Application.Current).child_uk + ", '" +
                        ((App)Application.Current).master_uk + "', " + ((App)Application.Current).task_uk + ", 2, " +
                        "'" + start_time + "', '" + end_time + "')");
                }
            }
            else
            {// в дз

            }
        }

        private void FavBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
