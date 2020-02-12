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
using MyGameList.Models;
using MyGameList.Utilities;

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for FriendRequestsPage.xaml
    /// </summary>
    public partial class FriendRequestsPage : Page
    {
        public FriendRequestsPage()
        {
            InitializeComponent();
            NicknameTextBlock.Text = AppWindow.LoggedUser.Nickname;
            GetFriendRequets();
        }
        private void GetFriendRequets()
        {
            FriendsRequetsWrapPanel.Children.Clear();
            List<Friend> friendRequests = MainWindow.client.GetFriendRequests(AppWindow.LoggedUser.Id).ToList();
            foreach (var friend in friendRequests)
            {
                FriendsRequetsWrapPanel.Children.Add(GetInfoOverlay(MainWindow.client.GetAccountById(friend.Account_Id)));
            }
        }
        private InfoOverlay GetInfoOverlay(Account account)
        {
            InfoOverlay infoOverlay = new InfoOverlay();
            infoOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(account.Avatar != null ? account.Avatar.ToArray() : null);
            infoOverlay.HeaderTextBox.Text = account.Nickname;
            infoOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => InfoOverlay_Clicked(sender, e, account));
            return infoOverlay;
        }
        void InfoOverlay_Clicked(object sender, RoutedEventArgs e, Account account)
        {
            NavigationService.Navigate(new AccountPage(account));
        }
    }
}
