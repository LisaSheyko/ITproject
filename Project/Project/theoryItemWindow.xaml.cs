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

namespace Project
{
    public partial class TheoryItemWindow : Window
    {
        public TheoryItemWindow()
        {
            InitializeComponent();
            XpsDocument doc = new XpsDocument(Directory.GetCurrentDirectory() + 
                "/test.xps", FileAccess.Read);
            DocV.Document = doc.GetFixedDocumentSequence();
            doc.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
