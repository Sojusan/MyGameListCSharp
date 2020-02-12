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
using System.Text.RegularExpressions;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyGameList.Utilities;
using WcfServiceLibrary;
using MyGameList.Windows;

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        readonly Page previousPage;
        bool loginAccepted = false;
        bool passwordAccepted = false;
        bool emailAccepted = false;
        bool nicknameAccepted = false;
        public RegisterPage(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(this.previousPage);
        }

        private void RegisterButton_Clicked(object sender, RoutedEventArgs e)
        {
            VerifyAccountFields();
            if (loginAccepted && passwordAccepted && emailAccepted && nicknameAccepted)
            {
                Account account = new Account();
                if (GenderComboBox.Text != null)
                {
                    account.Sex = GenderComboBox.Text;
                }
                else
                {
                    account.Sex = null;
                }
                account.Login = LoginTextBox.Text.Trim();
                account.Password = BCrypt.Net.BCrypt.HashPassword(PasswordTextBox.Password.Trim());
                account.Email = EmailTextBox.Text.Trim();
                account.Nickname = NicknameTextBox.Text.Trim();
                account.Joined = DateTime.Now;
                account.IsAdmin = false;
                account.IsModerator = false;
                account.IsActivated = false;
                account.Avatar = null;
                MainWindow.client.AddAccount(account);
                MessageWindow window = new MessageWindow("Successfully Created !", "Your account was successfully created. On your first login attempt we will send you a activation code on your email.");
                window.ShowDialog();
                NavigationService.Navigate(this.previousPage);
            }
        }
        private void VerifyAccountFields()
        {
            if (!LoginTextBox.Text.Trim().Equals(""))
            {
                if (LoginTextBox.Text.Trim().Length >= 4)
                {
                    if(MainWindow.client.IsUniqueLogin(LoginTextBox.Text.Trim()))
                    {
                        LoginErrorTextBlock.Visibility = Visibility.Hidden;
                        LoginTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                        loginAccepted = true;
                    }
                    else
                    {
                        LoginTextBox.BorderBrush = Brushes.Red;
                        LoginErrorTextBlock.Text = "Login already taken !";
                        LoginErrorTextBlock.Visibility = Visibility.Visible;
                        loginAccepted = false;
                    }
                }
                else
                {
                    LoginTextBox.BorderBrush = Brushes.Red;
                    LoginErrorTextBlock.Text = "At least 4 characters !";
                    LoginErrorTextBlock.Visibility = Visibility.Visible;
                    loginAccepted = false;
                }
            }
            else
            {
                LoginTextBox.BorderBrush = Brushes.Red;
                LoginErrorTextBlock.Text = "This can't be empty !";
                LoginErrorTextBlock.Visibility = Visibility.Visible;
                loginAccepted = false;
            }
            if (!PasswordTextBox.Password.Trim().Equals(""))
            {
                if (PasswordTextBox.Password.Trim().Length >= 8)
                {
                    PasswordErrorTextBlock.Visibility = Visibility.Hidden;
                    PasswordTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                    passwordAccepted = true;
                }
                else
                {
                    PasswordTextBox.BorderBrush = Brushes.Red;
                    PasswordErrorTextBlock.Text = "At least 8 characters !";
                    PasswordErrorTextBlock.Visibility = Visibility.Visible;
                    passwordAccepted = false;
                }
            }
            else
            {
                PasswordTextBox.BorderBrush = Brushes.Red;
                PasswordErrorTextBlock.Text = "This can't be empty !";
                PasswordErrorTextBlock.Visibility = Visibility.Visible;
                passwordAccepted = false;
            }
            if (!EmailTextBox.Text.Trim().Equals(""))
            {
                if (IsValidEmailAddress(EmailTextBox.Text.Trim()))
                {
                    if (MainWindow.client.IsUniqueEmail(EmailTextBox.Text.Trim()))
                    {
                        EmailErrorTextBlock.Visibility = Visibility.Hidden;
                        EmailTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                        emailAccepted = true;
                    }
                    else
                    {
                        EmailTextBox.BorderBrush = Brushes.Red;
                        EmailErrorTextBlock.Text = "There is account on that email !";
                        EmailErrorTextBlock.Visibility = Visibility.Visible;
                        emailAccepted = false;
                    }
                }
                else
                {
                    EmailTextBox.BorderBrush = Brushes.Red;
                    EmailErrorTextBlock.Text = "Enter a valid email !";
                    EmailErrorTextBlock.Visibility = Visibility.Visible;
                    emailAccepted = false;
                }
            }
            else
            {
                EmailTextBox.BorderBrush = Brushes.Red;
                EmailErrorTextBlock.Text = "This can't be empty !";
                EmailErrorTextBlock.Visibility = Visibility.Visible;
                emailAccepted = false;
            }
            if (!NicknameTextBox.Text.Trim().Equals(""))
            {
                if (MainWindow.client.IsUniqueNickname(NicknameTextBox.Text.Trim()))
                {
                    NicknameErrorTextBlock.Visibility = Visibility.Hidden;
                    NicknameTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                    nicknameAccepted = true;
                }
                else
                {
                    NicknameTextBox.BorderBrush = Brushes.Red;
                    NicknameErrorTextBlock.Text = "Nickname already taken !";
                    NicknameErrorTextBlock.Visibility = Visibility.Visible;
                    nicknameAccepted = false;
                }
            }
            else
            {
                NicknameTextBox.BorderBrush = Brushes.Red;
                NicknameErrorTextBlock.Text = "This can't be empty !";
                NicknameErrorTextBlock.Visibility = Visibility.Visible;
                nicknameAccepted = false;
            }
        }

        private bool IsValidEmailAddress(String email)
        {
            String regex = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])";
            return Regex.IsMatch(email, regex);
        }
    }
}
