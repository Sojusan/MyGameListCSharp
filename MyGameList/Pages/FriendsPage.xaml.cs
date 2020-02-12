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
    /// Interaction logic for FriendsPage.xaml
    /// </summary>
    public partial class FriendsPage : Page
    {
        private Account account;
        public FriendsPage(Account account)
        {
            InitializeComponent();
            this.account = account;
            NicknameTextBlock.Text = account.Nickname;
            GetFriends();
        }
        private void GetFriends()
        {
            FriendsWrapPanel.Children.Clear();
            List<Friend> friends = MainWindow.client.GetFriendListByAccountId(account.Id).ToList();
            friends.Sort((o1, o2) => o2.DateOfAdding.CompareTo(o1.DateOfAdding));
            foreach (var friend in friends)
            {
                FriendsWrapPanel.Children.Add(GetFriendElement(friend));
            }
        }
        private FriendElement GetFriendElement(Friend friendInfo)
        {
            Account tmpAccount = MainWindow.client.GetAccountById(friendInfo.Friend_Id);
            FriendElement friendElement = new FriendElement();
            friendElement.Height = Double.NaN;
            friendElement.Width = Double.NaN;
            friendElement.AvatarImage.Source = EverythingAboutImages.ConvertByteArrayToImage(tmpAccount.Avatar != null ? tmpAccount.Avatar.ToArray() : null);
            friendElement.NicknameTextBlock.Text = tmpAccount.Nickname;
            friendElement.DateTextBlock.Text = friendInfo.DateOfAdding == null ? "n/a" : ((DateTime)friendInfo.DateOfAdding).ToString("dd-MM-yyyy");
            friendElement.MouseUp += new MouseButtonEventHandler((sender, e) => FriendElement_Clicked(sender, e, tmpAccount));
            friendElement.MinWidth = 300;
            return friendElement;
        }
        void FriendElement_Clicked(object sender, RoutedEventArgs e, Account account)
        {
            NavigationService.Navigate(new AccountPage(account));
        }
    }
}
