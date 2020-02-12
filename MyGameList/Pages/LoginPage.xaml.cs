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
using WcfServiceLibrary;
using MyGameList.Utilities;
using MyGameList.Windows;

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private bool loginAccepted = false;
        private bool passwordAccepted = false;
        private Account logInAccount;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LogInButton_Clicked(object sender, RoutedEventArgs e)
        {
            VerifyFields();
            if (loginAccepted && passwordAccepted)
            {
                if (logInAccount.IsActivated)
                {
                    AppWindow.LoggedUser = logInAccount;
                    AppWindow appWindow = new AppWindow();
                    appWindow.Show();
                    Application.Current.MainWindow.Hide();
                }
                else
                {
                    EmailSender emailSender = new EmailSender(logInAccount.Email);
                    emailSender.SendVerificationCode();
                    CodeValidationWindow codeValidationWindow = new CodeValidationWindow(emailSender.code);
                    codeValidationWindow.ShowDialog();
                    if (CodeValidationWindow.codeIsCorrect)
                    {
                        logInAccount.IsActivated = true;
                        MainWindow.client.UpdateAccount(logInAccount.Id, logInAccount);
                        MessageWindow messageWindow = new MessageWindow("Verification Completed !", "Your account has been activated.");
                        messageWindow.ShowDialog();
                        AppWindow appWindow = new AppWindow();
                        AppWindow.LoggedUser = logInAccount;
                        appWindow.Show();
                        Application.Current.MainWindow.Close();
                        CodeValidationWindow.codeIsCorrect = false;
                    }
                    else
                    {
                        MessageWindow messageWindow = new MessageWindow("Verification Canceled !", "Verification process was terminated.");
                        messageWindow.ShowDialog();
                    }
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage(this));
        }
        private void VerifyFields()
        {
            if (!LoginTextBox.Text.Trim().Equals(""))
            {
                if ((logInAccount = MainWindow.client.GetAccount(LoginTextBox.Text.Trim())) != null)
                {
                    LoginErrorTextBlock.Visibility = Visibility.Hidden;
                    LoginTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                    loginAccepted = true;
                }
                else
                {
                    LoginTextBox.BorderBrush = Brushes.Red;
                    LoginErrorTextBlock.Text = "This login don't exists !";
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
                if (loginAccepted)
                {
                    if (BCrypt.Net.BCrypt.Verify(PasswordTextBox.Password.Trim(), logInAccount.Password))
                    {
                        PasswordTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                        PasswordErrorTextBlock.Visibility = Visibility.Hidden;
                        passwordAccepted = true;
                    }
                    else
                    {
                        PasswordTextBox.BorderBrush = Brushes.Red;
                        PasswordErrorTextBlock.Text = "Wrong password !";
                        PasswordErrorTextBlock.Visibility = Visibility.Visible;
                        passwordAccepted = false;
                        MainWindow.myGameListEventLog.WriteEntry($"Wrong password for user: {LoginTextBox.Text.Trim()}", "Warning");
                    }
                }
                else
                {
                    PasswordTextBox.BorderBrush = Brushes.Red;
                    PasswordErrorTextBlock.Text = "Wrong login !";
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
        }

        private void ForgotPassword_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoginValidationWindow loginValidationWindow = new LoginValidationWindow();
            loginValidationWindow.ShowDialog();
            if (LoginValidationWindow.loginIsCorrect)
            {
                LoginValidationWindow.loginIsCorrect = false;
                EmailSender emailSender = new EmailSender(LoginValidationWindow.account.Email);
                emailSender.SendVerificationCode();
                CodeValidationWindow codeValidationWindow = new CodeValidationWindow(emailSender.code);
                codeValidationWindow.ShowDialog();
                if (CodeValidationWindow.codeIsCorrect)
                {
                    CodeValidationWindow.codeIsCorrect = false;
                    PasswordChangerWindow passwordChangerWindow = new PasswordChangerWindow();
                    passwordChangerWindow.ShowDialog();
                    if (PasswordChangerWindow.newPassword != null)
                    {
                        LoginValidationWindow.account.Password = BCrypt.Net.BCrypt.HashPassword(PasswordChangerWindow.newPassword);
                        MainWindow.client.UpdateAccount(LoginValidationWindow.account.Id, LoginValidationWindow.account);
                        MessageWindow messageWindow = new MessageWindow("Password changed !", "Your password was successfully changed.");
                        messageWindow.ShowDialog();
                        LoginValidationWindow.account = null;
                        PasswordChangerWindow.newPassword = null;
                    }
                    else
                    {
                        MessageWindow messageWindow = new MessageWindow("Operation canceled !", "Operation was stoped by user.");
                        messageWindow.ShowDialog();
                    }
                }
                else
                {
                    MessageWindow messageWindow = new MessageWindow("Operation canceled !", "Operation was stoped by user.");
                    messageWindow.ShowDialog();
                }
            }
            else
            {
                MessageWindow messageWindow = new MessageWindow("Operation canceled !", "Operation was stoped by user.");
                messageWindow.ShowDialog();
            }
        }
    }
}
