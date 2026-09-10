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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InfourokParser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataType.Text.Equals("Текст"))
            {
                ParserStarter starter = new ParserStarter();
                starter.GetText(urlSelect.Text);
            } else
            {
                ParserStarter starter = new ParserStarter();
                starter.GetText(urlSelect.Text);
            }
        }
    }
}
