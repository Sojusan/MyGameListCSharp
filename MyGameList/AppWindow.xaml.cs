using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyGameList.Pages;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WcfServiceLibrary;
using MyGameList.Windows;
using MyGameList.Utilities;

namespace MyGameList
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public static Account LoggedUser { get; set; }
        public AppWindow()
        {
            InitializeComponent();
            MainWindow.myGameListEventLog.WriteEntry($"{LoggedUser.Login} logged in.", "Info");
            AppFrame.Navigate(new MenuPage());
            LoginHolder.Header = LoggedUser.Login;
            if (LoggedUser.Avatar != null)
            {
                BitmapImage avatarImage = EverythingAboutImages.ConvertByteArrayToImage(LoggedUser.Avatar.ToArray());
                AvatarImage.Source = avatarImage;
            }
            if (LoggedUser.IsAdmin || LoggedUser.IsModerator)
            {
                AdministrativePanelButton.Visibility = Visibility.Visible;
            }
            GetNotifications();
        }
        private void GetNotifications()
        {
            int sumOfNotifications = 0;
            List<Friend> friendRequests = MainWindow.client.GetFriendRequests(LoggedUser.Id).ToList();
            List<Follow> follows = MainWindow.client.GetFollowListByAccountId(LoggedUser.Id).ToList();
            foreach (var follow in follows)
            {
                sumOfNotifications += follow.NewReview;
            }
            sumOfNotifications += friendRequests.Count;
            if (sumOfNotifications != 0)
            {
                NotificationCounter.Text = sumOfNotifications.ToString();
                NotificationCounter.Visibility = Visibility.Visible;
            }
        }

        private void SearchButton_Clicked(object sender, RoutedEventArgs e)
        {
            AppFrame.Navigate(new SearchPage());
        }

        private void AdministrativeButton_Clicked(object sender, RoutedEventArgs e)
        {
            AppFrame.Navigate(new AdministrativePanelPage());
        }

        private void AccountButton_Clicked(object sender, RoutedEventArgs e)
        {
            AppFrame.Navigate(new AccountPage(AppWindow.LoggedUser));
        }

        private void NotificationButton_Clicked(object sender, RoutedEventArgs e)
        {
            AppFrame.Navigate(new NotificationPanelPage());
        }

        private void PreviousPage_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (AppFrame.CanGoBack)
            {
                AppFrame.GoBack();
            }
        }

        private void NextPage_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (AppFrame.CanGoForward)
            {
                AppFrame.GoForward();
            }
        }

        private void BackToMainView_Clicked(object sender, MouseButtonEventArgs e)
        {
            AppFrame.Navigate(new MenuPage());
        }

        private void GameListButton_Clicked(object sender, RoutedEventArgs e)
        {
            AppFrame.Navigate(new GameListPage(LoggedUser));
        }

        private void LogOut_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Friends_Clicked(object sender, RoutedEventArgs e)
        {
            AppFrame.Navigate(new FriendsPage(AppWindow.LoggedUser));
        }

        private void GameRequest_Clicked(object sender, RoutedEventArgs e)
        {
            RequestGameWindow requestGameWindow = new RequestGameWindow();
            requestGameWindow.ShowDialog();
        }

        private void StudioRequest_Clicked(object sender, RoutedEventArgs e)
        {
            RequestStudioWindow requestStudioWindow = new RequestStudioWindow();
            requestStudioWindow.ShowDialog();
        }

        private void WindowClosing_Action(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Show();
            MainWindow.myGameListEventLog.WriteEntry($"{LoggedUser.Login} log out.", "Info");
            AppWindow.LoggedUser = null;
        }
    }
}
