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
using System.Media;
using System.Globalization;
using System.Data;
using System.Diagnostics;

namespace Project
{
    public partial class personalAccWindows : Window
    {
        public personalAccWindows()
        {
            InitializeComponent();
            DataTable sql_res;
            if (((App)Application.Current).grant_ccode == "master")
            { // для учителя заполняем все возможные номера классов
                sql_res = DbManager.Execute("select distinct num from CLASS_SDIM order by num desc");
                for (int i = 0; i < sql_res.Rows.Count; ++i)
                    comboboxClassNum.Items.Add(sql_res.Rows[i].ItemArray[0]);
                sql_res = DbManager.Execute(@"select u.name from user_sdim u join grant_sdim g
                                            on u.grant_uk = g.uk where g.ccode = 'child'");
                for (int i = 0; i < sql_res.Rows.Count; ++i)
                    comboboxDisciple.Items.Add(sql_res.Rows[i].ItemArray[0].ToString());
            }
            else
            { // для ученика выключаем все фильтры, но вписываем туда его класс
                labChild.Content = "Выберите учителя";
                labClass.IsEnabled = false;
                comboboxClassLet.IsEnabled = false;
                comboboxClassNum.IsEnabled = false;
                sql_res = DbManager.Execute("select num, letter from user_sdim u join class_sdim cl " +
                    "on u.class_uk = cl.uk and u.uk = " + ((App)Application.Current).child_uk);
                comboboxClassNum.Items.Add(sql_res.Rows[0]["num"].ToString());
                comboboxClassNum.SelectedIndex = 0;
                comboboxClassLet.Items.Add(sql_res.Rows[0]["letter"].ToString());
                comboboxClassLet.SelectedIndex = 0;
                sql_res = DbManager.Execute(@"select u.name from user_sdim u join grant_sdim g
                                             on u.grant_uk = g.uk where g.ccode = 'master'");
                for (int i = 0; i < sql_res.Rows.Count; ++i)
                    comboboxDisciple.Items.Add(sql_res.Rows[i].ItemArray[0].ToString());
            }

            //Сгенерирум данные для графиков
            int Np = 30;
            double[] Data1 = new double[Np + 1];
            double[] Data2 = new double[Np + 1];

            for (int i = 0; i < Np + 1; i++)
            {
                Data1[i] = Math.Sin(i / 5.0) + 1;
                Data2[i] = Math.Cos(i / 5.0) + 1;
            }
            //Теперь нарисуем график
            DrawingGroup aDrawingGroup = new DrawingGroup();
            for (int DrawingStage = 0; DrawingStage < 10; DrawingStage++)
            {
                GeometryDrawing drw = new GeometryDrawing();
                GeometryGroup gg = new GeometryGroup();


                //Задный фон
                if (DrawingStage == 1)
                {
                    drw.Brush = Brushes.Beige;
                    drw.Pen = new Pen(Brushes.LightGray, 0.01);

                    RectangleGeometry myRectGeometry = new RectangleGeometry();
                    myRectGeometry.Rect = new Rect(0, 0, 1, 1);
                    gg.Children.Add(myRectGeometry);
                }

                //Мелкая сетка
                if (DrawingStage == 2)
                {
                    drw.Brush = Brushes.Beige;
                    drw.Pen = new Pen(Brushes.Gray, 0.003);
                    //drw.Pen.DashStyle = DashStyles.Dot;

                    DoubleCollection dashes = new DoubleCollection();
                    for (int i = 1; i < 10; i++)
                        dashes.Add(0.1);
                    drw.Pen.DashStyle = new DashStyle(dashes, 0);

                    drw.Pen.EndLineCap = PenLineCap.Round;
                    drw.Pen.StartLineCap = PenLineCap.Round;
                    drw.Pen.DashCap = PenLineCap.Round;


                    for (int i = 1; i < 10; i++)
                    {
                        LineGeometry myRectGeometry = new LineGeometry(new Point(1.1, i * 0.1), new Point(-0.1, i * 0.1));
                        gg.Children.Add(myRectGeometry);
                    }
                }


                //график #1 - линия
                if (DrawingStage == 3)
                {

                    drw.Brush = Brushes.White;
                    drw.Pen = new Pen(Brushes.Black, 0.005);

                    gg = new GeometryGroup();
                    for (int i = 0; i < Np; i++)
                    {
                        LineGeometry l = new LineGeometry(new Point((double)i / (double)Np, 1.0 - (Data1[i] / 2.0)),
                            new Point((double)(i + 1) / (double)Np, 1.0 - (Data1[i + 1] / 2.0)));
                        gg.Children.Add(l);
                    }
                }

                //график #2 - точки
                if (DrawingStage == 4)
                {

                    drw.Brush = Brushes.White;
                    drw.Pen = new Pen(Brushes.Black, 0.005);

                    gg = new GeometryGroup();
                    for (int i = 0; i < Np; i++)
                    {
                        EllipseGeometry el = new EllipseGeometry(new Point((double)i / (double)Np, 1.0 - (Data2[i] / 2.0)), 0.01, 0.01);
                        gg.Children.Add(el);
                    }
                }


                //Обрезание лишнего
                if (DrawingStage == 5)
                {
                    drw.Brush = Brushes.Transparent;
                    drw.Pen = new Pen(Brushes.White, 0.2);

                    RectangleGeometry myRectGeometry = new RectangleGeometry();
                    myRectGeometry.Rect = new Rect(-0.1, -0.1, 1.2, 1.2);
                    gg.Children.Add(myRectGeometry);

                }


                //Рамка
                if (DrawingStage == 6)
                {
                    drw.Brush = Brushes.Transparent;
                    drw.Pen = new Pen(Brushes.LightGray, 0.01);

                    RectangleGeometry myRectGeometry = new RectangleGeometry();
                    myRectGeometry.Rect = new Rect(0, 0, 1, 1);
                    gg.Children.Add(myRectGeometry);
                }


                //Надписи
                if (DrawingStage == 7)
                {
                    drw.Brush = Brushes.LightGray;
                    drw.Pen = new Pen(Brushes.Gray, 0.003);

                    for (int i = 1; i < 10; i++)
                    {

                        // Create a formatted text string.
                        FormattedText formattedText = new FormattedText(
                            ((double)(1 - i * 0.1)).ToString(),
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            0.05,
                            Brushes.Black);

                        // Set the font weight to Bold for the formatted text.
                        formattedText.SetFontWeight(FontWeights.Bold);

                        // Build a geometry out of the formatted text.
                        Geometry geometry = formattedText.BuildGeometry(new Point(-0.1, i * 0.1 - 0.03));
                        gg.Children.Add(geometry);
                    }
                }
                drw.Geometry = gg;
                aDrawingGroup.Children.Add(drw);
            }
            imgProgress.Source = new DrawingImage(aDrawingGroup);
        }

        private void ComboboxDisciple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable sql_res;
            string targ_name, targ_uk, author_uk;
            string all_right, right2all, afterT, beforeT;

            if (!comboboxDisciple.Items.IsEmpty)
            { // если мы заполнили возможных учеников
				BtnOk.IsEnabled = true;
				textBox.IsEnabled = true;
				textBlock.Text = "";
				
                targ_name = comboboxDisciple.SelectedValue.ToString();
                targ_uk = DbManager.Execute("select uk from user_sdim where name = '" +
                    targ_name + "'").Rows[0]["uk"].ToString();
                if (((App)Application.Current).grant_ccode == "master")
                {
                    ((App)Application.Current).child_uk = targ_uk;
                    ((App)Application.Current).child_name = targ_name;
                    author_uk = ((App)Application.Current).master_uk;
                }
                else
                {
                    ((App)Application.Current).master_uk = targ_uk;
                    ((App)Application.Current).master_name = targ_name;
                    author_uk = ((App)Application.Current).child_uk;
                }
				// достаем все сообщения и выводим их в окне
                sql_res = DbManager.Execute("select * from chat_log where author_uk in (" +
                    author_uk + ", " + targ_uk + ") and targ_uk in(" + author_uk + ", " + targ_uk
                    + ") order by pk");
                for (int i = 0; i < sql_res.Rows.Count; ++i)
                {
                    if (sql_res.Rows[i]["author_uk"].ToString() == targ_uk)
                        textBlock.Text += targ_name + ": ";
                    textBlock.Text += sql_res.Rows[i]["msg"].ToString() + " \n";
                }
            }
            // Собираем статистику
            DataTable res = DbManager.Execute("select count(*) from (select task_uk from progress_log" +
                " where status_uk = 1)");
            all_right = res.Rows[0].ItemArray[0].ToString();
            res = DbManager.Execute("select count(*) from (select task_uk from progress_log" +
                " where status_uk = 2)");
            right2all = res.Rows[0].ItemArray[0].ToString();
            res = DbManager.Execute("select count(*) from (select theory_uk from progress_log" +
                " where status_uk = 1)");
            beforeT = res.Rows[0].ItemArray[0].ToString();
            res = DbManager.Execute("select count(*) from (select theory_uk from progress_log" +
                " where status_uk = 5)");
            afterT = res.Rows[0].ItemArray[0].ToString();
            txtBlockStat.Text = "Верных попыток решения задач: " + all_right + "\n" +
                "Неверных попыток: " + right2all + "\n" +
                "Изучено тем: " + beforeT + "\n" +
                "Тем, по которым есть вопросы: " + afterT;
        }

        private void TheoryBtn_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).TaskMode = false;
            ((App)Application.Current).class_num = comboboxClassNum.Text;
            ((App)Application.Current).class_let = comboboxClassLet.Text;
            if (((App)Application.Current).grant_ccode == "master" && (comboboxDisciple.Text == ""))
            {
                ((App)Application.Current).child_uk = "";
                ((App)Application.Current).child_name = "";
            }
            else if (comboboxDisciple.Text == "")
            {
                ((App)Application.Current).master_name = "";
                ((App)Application.Current).master_uk = "";
            }
            theoryWindow T = new theoryWindow();
            if (((App)Application.Current).grant_ccode == "master")
            {
                T.exp_1.Header = "Домашнее задание";
            }
            T.Show();
            this.Close();
        }

        private void TaskBtn_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).TaskMode = true;
            if (((App)Application.Current).grant_ccode == "master" && (comboboxDisciple.Text == ""))
            {
                ((App)Application.Current).child_uk = "";
                ((App)Application.Current).child_name = "";
            }
            else if (comboboxDisciple.Text == "")
            {
                ((App)Application.Current).master_name = "";
                ((App)Application.Current).master_uk = "";
            }
            theoryWindow T = new theoryWindow
            {
                Title = "Банк задач"
            };
            T.exp_2.Header = "Неправильно решенные";
            T.exp_3.Header = "Последние";
            T.exp_4.Header = "Избранные";
            T.exp_5.Visibility = Visibility.Hidden;
            T.exp_6.Visibility = Visibility.Hidden;
            ((App)Application.Current).class_num = comboboxClassNum.Text;
            ((App)Application.Current).class_let = comboboxClassLet.Text;
            if (((App)Application.Current).grant_ccode == "master")
            {
                T.exp_1.Header = "Домашнее задание";
            }
            else
            {
                T.exp_1.Header = "Заданные учителем";
            }
            T.Show();
            this.Close();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            string author_uk, targ_uk;
            if (textBox.Text != "")
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
                DbManager.ExecuteNonQ("insert into chat_log (author_uk, targ_uk, msg, time) values (" +
                    author_uk + ", " + targ_uk + ", '" + textBox.Text + "', '" 
                    + System.DateTime.Now.ToShortTimeString() + " " + System.DateTime.Now.ToShortDateString() + "')");
                textBlock.Text += textBox.Text + "\n";
                textBox.Clear();
            } 
        }

        private void comboboxClassNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboboxClassLet.Items.Clear();
            comboboxDisciple.Items.Clear();
            DataTable dTable = DbManager.Execute("select letter from CLASS_SDIM where num = '" +
                comboboxClassNum.SelectedItem.ToString() + "' order by letter");
            for (int i = 0; i < dTable.Rows.Count; ++i)
                comboboxClassLet.Items.Add(dTable.Rows[i].ItemArray[0]);
        }

        private void comboboxClassLet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboboxDisciple.Items.Clear();
            if (!comboboxClassLet.Items.IsEmpty && ((App)Application.Current).grant_ccode == "master")
            {
                DataTable dTable = DbManager.Execute("select name from USER_SDIM u join CLASS_SDIM cl" +
                    " on u.class_uk = cl.uk and cl.num = " + comboboxClassNum.SelectedValue.ToString() +
                    " and cl.letter = '" + comboboxClassLet.SelectedValue.ToString() + "'");
                for (int i = 0; i < dTable.Rows.Count; ++i)
                    comboboxDisciple.Items.Add(dTable.Rows[i].ItemArray[0]);
            }
        }
    }
}
