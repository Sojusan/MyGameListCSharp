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

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for NotificationPanelPage.xaml
    /// </summary>
    public partial class NotificationPanelPage : Page
    {
        public NotificationPanelPage()
        {
            InitializeComponent();
            GetNotifications();
        }
        private void GetNotifications()
        {
            int sumOfNewReviews = 0;
            List<Friend> friendRequests = MainWindow.client.GetFriendRequests(AppWindow.LoggedUser.Id).ToList();
            List<Follow> follows = MainWindow.client.GetFollowListByAccountId(AppWindow.LoggedUser.Id).ToList();
            foreach (var follow in follows)
            {
                sumOfNewReviews += follow.NewReview;
            }
            FriendsRequestsCounter.Text = friendRequests.Count.ToString();
            NewReviewsCounter.Text = sumOfNewReviews.ToString();
        }

        private void FriendsRequestsButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FriendRequestsPage());
        }

        private void NewReviewsButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewReviewPage());
        }
    }
}
