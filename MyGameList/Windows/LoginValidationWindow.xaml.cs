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
using WcfServiceLibrary;

namespace MyGameList.Windows
{
    /// <summary>
    /// Interaction logic for LoginValidationWindow.xaml
    /// </summary>
    public partial class LoginValidationWindow : Window
    {
        public static bool loginIsCorrect { get; set; }
        public static Account account { get; set; }
        public LoginValidationWindow()
        {
            InitializeComponent();
        }

        private void AcceptButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (!LoginTextBox.Text.Trim().Equals(""))
            {
                if ((account = MainWindow.client.GetAccount(LoginTextBox.Text.Trim())) != null)
                {
                    loginIsCorrect = true;
                    this.Close();
                }
                else
                {
                    LoginTextBox.BorderBrush = Brushes.Red;
                    LoginErrorTextBlock.Text = "This login don't exists !";
                    LoginErrorTextBlock.Visibility = Visibility.Visible;
                }
            }
            else
            {
                LoginTextBox.BorderBrush = Brushes.Red;
                LoginErrorTextBlock.Text = "This can't be empty !";
                LoginErrorTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
