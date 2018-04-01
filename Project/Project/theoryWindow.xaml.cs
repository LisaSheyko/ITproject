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

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для theoryWindow.xaml
    /// </summary>
    public partial class theoryWindow : Window
    {
        public theoryWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Title == "Банк задач")
            {
                TaskItemWindow TskI = new TaskItemWindow();
                TskI.ShowDialog();
            }
            else
            {
                TheoryItemWindow Ti = new TheoryItemWindow();
                Ti.ShowDialog();
            }
        }
    }
}
