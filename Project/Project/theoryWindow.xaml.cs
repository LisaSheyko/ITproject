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
using System.Data;

namespace Project
{
    public partial class theoryWindow : Window
    {

        public void CreateTree(ref TreeViewItem elem, ref DataTable dTable, int cur, ref DataTable tTable)
        {
            TreeViewItem sub_elem;
            string s, uk = dTable.Rows[cur]["uk"].ToString();
            string[] words;

            if (dTable.Rows[cur]["leaf_flag"].ToString() == "0")
            {
                for (int i = 0; i < dTable.Rows.Count; ++i)
                {
                    if (dTable.Rows[i]["parent_uk"].ToString() == uk &&
                        dTable.Rows[i]["uk"].ToString() != uk)
                    {
                        sub_elem = new TreeViewItem
                        {
                            Header = dTable.Rows[i]["ccode"]
                        };
                        elem.Items.Add(sub_elem);
                        if (!((App)Application.Current).TaskMode)
                            ComboElem.Items.Add(sub_elem.Header);
                        CreateTree(ref sub_elem, ref dTable, i, ref tTable);
                    }
                }
            }
            if (((App)Application.Current).TaskMode)
            {
                for (int i = 0; i < tTable.Rows.Count; ++i)
                {
                    s = tTable.Rows[i]["theory_mask"].ToString();
                    words = s.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string tmp in words)
                        if (uk == tmp)
                        {
                            sub_elem = new TreeViewItem
                            {
                                Header = tTable.Rows[i]["ccode"]
                            };
                            elem.Items.Add(sub_elem);
                            ComboElem.Items.Add(sub_elem.Header);
                        }
                }
            }
        }

        public theoryWindow()
        {
            InitializeComponent();
            if  (((App)Application.Current).grant_ccode == "child")
            {
                AddBtn.Visibility = Visibility.Hidden;
            }

            TreeViewItem elem = new TreeViewItem
            {
                Header = "Математика" //! Пока только один корневой предмет
            };
            DataTable dTable = DbManager.Execute("select * from theory_sdim");
            DataTable tTable = DbManager.Execute("select * from task_sdim"); //! оптимизировать
            CreateTree(ref elem, ref dTable, 0, ref tTable);
            Tree.Items.Add(elem);
            // right
            string sqlQbase;
            DataTable th;
            if (((App)Application.Current).grant_ccode == "child")
            {
                sqlQbase = "select t.ccode from progress_log pr join theory_sdim t on " +
                    "pr.theory_uk = t.uk join status_sdim st on pr.status_uk = st.uk and " +
                    "pr.targ_uk = " + ((App)Application.Current).child_uk +
                    (((App)Application.Current).master_uk == "" ? "" : (" and pr.author_uk = " +
                    ((App)Application.Current).master_uk));
                th = DbManager.Execute("select distinct x.ccode from (" + sqlQbase + " and st.ccode = 'hw') x " +
                    "where not exists ( " + sqlQbase + " and st.ccode = 'ok' and t.ccode = x.ccode)");
            }
            else
            {
                sqlQbase = "select distinct t.ccode from progress_log pr join theory_sdim t on " +
                    "pr.theory_uk = t.uk join status_sdim st on pr.status_uk = st.uk and " +
                    "pr.author_uk = " + ((App)Application.Current).master_uk + " and st.ccode = 'hw'";
                th = DbManager.Execute(sqlQbase);
            }
            for (int i = 0; i < th.Rows.Count; ++i)
            {
                hwlst.Items.Add(th.Rows[i]["ccode"]);
            }
            string author_uk = ((App)Application.Current).grant_ccode == "child" ? ((App)Application.Current).child_uk : 
                ((App)Application.Current).master_uk;
            th = DbManager.Execute("select distinct t.ccode from progress_log pr join theory_sdim t on " +
                "pr.theory_uk = t.uk join status_sdim st on pr.status_uk = st.uk and " +
                "pr.author_uk = " + author_uk + " and st.ccode = 'fav'");
            for (int i = 0; i < th.Rows.Count; ++i)
            {
                favlst.Items.Add(th.Rows[i]["ccode"]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string item = "";
            ((App)Application.Current).task_uk = "";
            ((App)Application.Current).theory_uk = "";
            try
            {
                item = ((TreeViewItem)Tree.SelectedItem).Header.ToString();
            }
            catch { }
            item = ComboElem.Text == "" ? item : ComboElem.Text;
            if (((App)Application.Current).TaskMode)
            {
                if (item != "")
                {
                    DataTable dTable = DbManager.Execute("select uk from task_sdim where ccode = '" +
                        item + "'");
                    if (dTable.Rows.Count > 0)
                    {
                        ((App)Application.Current).task_uk = dTable.Rows[0]["uk"].ToString();
                        TaskItemWindow TskI = new TaskItemWindow();
                        TskI.ShowDialog();
                    }
                }
            }
            else
            {
                if (item != "")
                {
                    DataTable dTable = DbManager.Execute("select uk from theory_sdim where ccode = '" +
                        item + "'");
                    if (dTable.Rows.Count > 0)
                    {
                        ((App)Application.Current).theory_uk = dTable.Rows[0]["uk"].ToString();
                        TheoryItemWindow Ti = new TheoryItemWindow();
                        Ti.ShowDialog();
                    }
                }
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            addNewWindow ANW = new addNewWindow();
            ANW.ShowDialog();
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            personalAccWindows acc = new personalAccWindows();
            if (((App)Application.Current).grant_ccode == "master")
            {
                acc.Title = ((App)Application.Current).master_name;
            }
            else
            {
                acc.Title = ((App)Application.Current).child_name;
            }
            acc.Show();
            this.Close();
        }
    }
}
