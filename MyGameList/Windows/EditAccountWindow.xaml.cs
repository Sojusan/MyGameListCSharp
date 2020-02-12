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
using MyGameList.Utilities;

namespace MyGameList.Windows
{
    /// <summary>
    /// Interaction logic for EditAccountWindow.xaml
    /// </summary>
    public partial class EditAccountWindow : Window
    {
        private BitmapImage avatarImage = null;
        public EditAccountWindow()
        {
            InitializeComponent();
        }

        private void SelectFileButton_Clicked(object sender, RoutedEventArgs e)
        {
            avatarImage = EverythingAboutImages.GetImageFromFile();
            AvatarImage.Source = avatarImage;
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (!NicknameTextBox.Text.Trim().Equals(""))
            {
                if (MainWindow.client.IsUniqueNickname(NicknameTextBox.Text.Trim()))
                {
                    NicknameTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                    NicknameErrorTextBlock.Visibility = Visibility.Hidden;
                    AppWindow.LoggedUser.Nickname = NicknameTextBox.Text.Trim();
                }
                else
                {
                    NicknameTextBox.BorderBrush = Brushes.Red;
                    NicknameErrorTextBlock.Text = "Nickname already taken !";
                    NicknameErrorTextBlock.Visibility = Visibility.Visible;
                }
            }
            if (avatarImage != null)
            {
                AppWindow.LoggedUser.Avatar = new System.Data.Linq.Binary(EverythingAboutImages.ConvertImageToByteArray(avatarImage));
            }
            if (GenderComboBox.Text != null)
            {
                AppWindow.LoggedUser.Sex = GenderComboBox.Text;
            }
            MainWindow.client.UpdateAccount(AppWindow.LoggedUser.Id, AppWindow.LoggedUser);
            MessageWindow messageWindow = new MessageWindow("Information updated !", "Informations was successfully edited.");
            messageWindow.ShowDialog();
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
