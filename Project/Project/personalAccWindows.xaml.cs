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

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для personalAccWindows.xaml
    /// </summary>
    public partial class personalAccWindows : Window
    {
        public personalAccWindows()
        {
            InitializeComponent();

            DataTable people = DbManager.Execute(@"select u.name from users u join grant g on u.grant_uk = g.uk
                                                    where g.ccode = 'child'");
            for (int i = 0; i < people.Rows.Count; ++i)
                comboboxDisciple.Items.Add(people.Rows[i].ItemArray[0].ToString());

            txtBlockStat.Text = @"Всего решено задач: 0
Количество правильных ответов / общее количество: 0.0
Успешность решения после теории: 0.0
Успешность решения без теории: 0.0";
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            txtBlockStat.Visibility = Visibility.Visible;
            imgProgress.Visibility = Visibility.Hidden;
        }

        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            txtBlockStat.Visibility = Visibility.Hidden;
            imgProgress.Visibility = Visibility.Visible;
        }

        private void ComboboxDisciple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboboxDisciple.SelectedValue = this.Title;
            comboboxDisciple.IsEnabled = false;
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
    }
}
