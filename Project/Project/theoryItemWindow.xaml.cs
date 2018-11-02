using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

namespace Project
{
    public partial class TheoryItemWindow : Window
    {
        public string start_time = "", num = ((App)Application.Current).class_num, 
            letter = ((App)Application.Current).class_let, child_uk = ((App)Application.Current).child_uk,
            master_uk = ((App)Application.Current).master_uk, theory_uk = ((App)Application.Current).theory_uk,
            grant_ccode = ((App)Application.Current).grant_ccode;

        private void FavBtn_Click(object sender, RoutedEventArgs e)
        {
            string author_uk = grant_ccode == "master" ? master_uk : child_uk;
            DataTable res = DbManager.Execute("select * from progress_log where theory_uk = " + theory_uk +
                " and author_uk = " + author_uk + " and status_uk = 3");
            if (res.Rows.Count > 0)
            {
                DbManager.ExecuteNonQ("delete from progress_log where pk = " + res.Rows[0]["pk"].ToString());
            }
            else
            {
                DbManager.ExecuteNonQ("insert into progress_log (author_uk, theory_uk, status_uk, start_time)" +
                " values (" + author_uk + ", " + theory_uk + ", 3, '" + start_time + "')");
            }
        }

        public TheoryItemWindow()
        {
            InitializeComponent();
            start_time = System.DateTime.Now.ToShortTimeString() + " " + System.DateTime.Now.ToShortDateString();
            DataTable dTable = DbManager.Execute("select * from theory_sdim where uk = " + theory_uk);
            XpsDocument doc = new XpsDocument(Directory.GetCurrentDirectory() + 
                "/theory/" + dTable.Rows[0]["file_name"], FileAccess.Read);
            DocV.Document = doc.GetFixedDocumentSequence();
            doc.Close();
            Title = dTable.Rows[0]["ccode"].ToString();
            if (child_uk == "" || master_uk == "")
            {
                TxtBoxChat.IsEnabled = false;
                BtnOkChat.IsEnabled = false;
            }
            if (grant_ccode == "master")
            {
                AllRbtn.Content = "Задать на дом";
                if (child_uk == "" && letter == "" && num == "")
                {
                    AllRbtn.IsEnabled = false;
                }
                QueBtn.IsEnabled = false;
            }
        }

        private void BtnOkChat_Click(object sender, RoutedEventArgs e)
        {
            string author_uk, targ_uk;
            if (TxtBoxChat.Text != "")
            {
                if (grant_ccode == "master")
                {
                    author_uk = master_uk;
                    targ_uk = child_uk;
                }
                else
                {
                    targ_uk = master_uk;
                    author_uk = child_uk;
                }
                DbManager.ExecuteNonQ("insert into chat_log (author_uk, targ_uk, msg, time, theory_uk) values (" +
                    author_uk + ", " + targ_uk + ", '" + TxtBoxChat.Text + "', '"
                    + System.DateTime.Now.ToShortTimeString() + " " + System.DateTime.Now.ToShortDateString() + 
                    "', " + theory_uk + ")");
                TxtBoxChat.Clear();
            }
        }

        private void QueBtn_Click(object sender, RoutedEventArgs e)
        {// доступна только ученикам
            string end_time = System.DateTime.Now.ToShortTimeString() + " " + System.DateTime.Now.ToShortDateString();
            DbManager.ExecuteNonQ("insert into progress_log (author_uk, targ_uk, theory_uk, status_uk, start_time," +
                "end_time) values (" + child_uk + ", '" + master_uk +
                "', " + theory_uk + ", 5, '" + start_time + "', '" + end_time + "')");
            this.Close();
        }

        private void AllRbtn_Click(object sender, RoutedEventArgs e)
        { // ученик закрывает тему, учитель задает ее на дом
            string end_time = System.DateTime.Now.ToShortTimeString() + " " + System.DateTime.Now.ToShortDateString();
            if (grant_ccode == "child")
            {
                DbManager.ExecuteNonQ("insert into progress_log (author_uk, targ_uk, theory_uk, status_uk, start_time," +
                "end_time) values (" + child_uk + ", '" + master_uk +
                "', " + theory_uk + ", 1, '" + start_time + "', '" + end_time + "')");
            }
            else
            {
                if (child_uk == "" && letter != "" && num != "")
                {
                    DataTable res = DbManager.Execute("select u.uk from user_sdim u join class_sdim cl " +
                        "on u.class_uk = cl.uk and cl.num = '" + num + "' and cl.letter = '" + letter + "'");
                    for (int i = 0; i < res.Rows.Count; ++i)
                    {
                        DbManager.ExecuteNonQ("insert into progress_log (author_uk, targ_uk, theory_uk, status_uk, start_time," +
                        "end_time) values (" + master_uk + ", '" + res.Rows[i]["uk"].ToString() + "', " + theory_uk + ", 6, '" + 
                        start_time + "', '" + end_time + "')");
                    }
                }
                else if (child_uk != "")
                {
                    DbManager.ExecuteNonQ("insert into progress_log (author_uk, targ_uk, theory_uk, status_uk, start_time," +
                        "end_time) values (" + master_uk + ", '" + child_uk + "', " + theory_uk + ", 6, '" +
                        start_time + "', '" + end_time + "')");
                }
            }
            this.Close();
        }
    }
}
