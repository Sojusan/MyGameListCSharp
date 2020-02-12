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

namespace MyGameList.Windows
{
    /// <summary>
    /// Interaction logic for SuccesfullyCreatedAccountWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(string header, string body)
        {
            InitializeComponent();
            HeaderTextBlock.Text = header;
            BodyTextBlock.Text = body;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
