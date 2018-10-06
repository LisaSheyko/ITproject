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
            TreeViewItem elem = new TreeViewItem
            {
                Header = "Test"
            };
            TreeViewItem sub_elem = new TreeViewItem
            {
                Header = "subTest"
            };
            elem.Items.Add(sub_elem);
            tree.Items.Add(elem);
            //tree.Items.Insert(0, elem);
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
            MessageBox.Show(tree.SelectedItem.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            addNewWindow ANW = new addNewWindow();
            ANW.ShowDialog();
        }
    }
}
