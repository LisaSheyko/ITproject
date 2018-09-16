﻿using System;
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
            {
                sql_res = DbManager.Execute(@"select u.name from user u join grant g on u.grant_uk = g.uk
                                                    where g.ccode = 'child'");
                for (int i = 0; i < sql_res.Rows.Count; ++i)
                    comboboxDisciple.Items.Add(sql_res.Rows[i].ItemArray[0].ToString());
            }
            else
            {
                labTop.Content = "Выбор преподавателя:";
                sql_res = DbManager.Execute(@"select u.name from user u join grant g on u.grant_uk = g.uk
                                                    where g.ccode = 'master'");
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

        private void RadioButtonSt_Checked(object sender, RoutedEventArgs e)
        {
            txtBlockStat.Visibility = Visibility.Visible;
            imgProgress.Visibility = Visibility.Hidden;
        }

        private void RadioButtonGr_Checked(object sender, RoutedEventArgs e)
        {
            txtBlockStat.Visibility = Visibility.Hidden;
            imgProgress.Visibility = Visibility.Visible;
        }

        private void ComboboxDisciple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable sql_res;
            string targ_name, targ_uk, author_uk;
            double all_right = 0, right2all = 0, afterT = 0, beforeT = 0;
            BtnOk.IsEnabled = true;
            textBox.IsEnabled = true;
            radioButtonSt.IsEnabled = true;
            radioButtonGr.IsEnabled = true;
            textBlock.Text = "";

            targ_name = comboboxDisciple.SelectedValue.ToString();
            targ_uk = DbManager.Execute("select uk from user where name = '" +
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
            sql_res = DbManager.Execute("select * from chat_log where author_uk in (" +
                author_uk + ", " + targ_uk + ") and targ_uk in(" + author_uk + ", " + targ_uk 
                + ") order by pk");
            for (int i = 0; i < sql_res.Rows.Count; ++i)
            {
                if (sql_res.Rows[i]["author_uk"].ToString() == targ_uk)
                    textBlock.Text += targ_name + ": ";
                textBlock.Text += sql_res.Rows[i]["msg"].ToString() + " \n";
            }
            // Собираем статистику
            txtBlockStat.Text = "Всего решено задач: " + all_right.ToString() + "\n" +
                "Количество правильно решенных / общее количество попыток: " + right2all.ToString() + "\n" +
                "Успешность решения задач до изучения теории: " + beforeT.ToString() + "\n" +
                "Успешность решения задач после изучения теории: " + afterT.ToString();
        }

        private void TheoryBtn_Click(object sender, RoutedEventArgs e)
        {
            theoryWindow T = new theoryWindow();
            T.ShowDialog();
        }

        private void TaskBtn_Click(object sender, RoutedEventArgs e)
        {
            theoryWindow T = new theoryWindow();
            T.exp_1.Header = "Заданные учителем";
            T.exp_2.Header = "Неправильно решенные";
            T.exp_3.Header = "Рекомендованные";
            T.exp_4.Header = "Последние";
            T.exp_5.Header = "Избранные";
            T.exp_6.IsEnabled = false;
            T.exp_6.Visibility = Visibility.Hidden;
            T.Title = "Банк задач";
            T.ShowDialog();
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
    }
}
