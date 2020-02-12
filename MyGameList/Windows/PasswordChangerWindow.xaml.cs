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
    /// Interaction logic for PasswordChangerWindow.xaml
    /// </summary>
    public partial class PasswordChangerWindow : Window
    {
        public static string newPassword = null;
        public PasswordChangerWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {
            bool firstPasswordCorrect = false;
            bool secondPasswordCorrect = false;
            if (FirstPassword.Password.Trim().Length >= 8)
            {
                firstPasswordCorrect = true;
                FirstPassword.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                FirstPasswordError.Visibility = Visibility.Hidden;
            }
            else
            {
                FirstPassword.BorderBrush = Brushes.Red;
                FirstPasswordError.Text = "At least 8 characters !";
                FirstPasswordError.Visibility = Visibility.Visible;
                firstPasswordCorrect = false;
            }
            if (FirstPassword.Password.Trim().Equals(SecondPassword.Password.Trim()))
            {
                secondPasswordCorrect = true;
                SecondPassword.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                SecondPasswordError.Visibility = Visibility.Hidden;
            }
            else
            {
                SecondPassword.BorderBrush = Brushes.Red;
                SecondPasswordError.Text = "Passwords don't match !";
                SecondPasswordError.Visibility = Visibility.Visible;
                secondPasswordCorrect = false;
            }
            if (secondPasswordCorrect && firstPasswordCorrect)
            {
                newPassword = FirstPassword.Password.Trim();
                this.Close();
            }
        }
    }
}
