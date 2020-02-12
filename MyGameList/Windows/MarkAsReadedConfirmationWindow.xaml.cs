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
    /// Interaction logic for MarkAsReadedConfirmationWindow.xaml
    /// </summary>
    public partial class MarkAsReadedConfirmationWindow : Window
    {
        public static bool isAccepted = false;
        public MarkAsReadedConfirmationWindow()
        {
            InitializeComponent();
        }

        private void NoButton_Clicked(object sender, RoutedEventArgs e)
        {
            isAccepted = false;
            this.Close();
        }

        private void YesButton_Clicked(object sender, RoutedEventArgs e)
        {
            isAccepted = true;
            this.Close();
        }
    }
}
