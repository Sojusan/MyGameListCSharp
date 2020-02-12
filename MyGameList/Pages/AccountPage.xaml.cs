using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Globalization;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Drawing;
using System.Windows.Shapes;
using MyGameList.Windows;
using WcfServiceLibrary;
using MyGameList.Utilities;
using MyGameList.Models;

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        private Account account;
        private Friend friend = null;
        private Friend oneSideFriend = null;
        private Friend[] friends;
        private Friend[] loggedUserFriends;
        private GameList[] userGameList;
        public AccountPage(Account account)
        {
            InitializeComponent();
            this.account = account;
            NicknameTextBlock.Text = account.Nickname;
            if (account.Id != AppWindow.LoggedUser.Id)
            {
                EditProfileButton.Visibility = Visibility.Hidden;
            }
            else
            {
                EditProfileButton.Visibility = Visibility.Visible;
            }
            AvatarImage.Source = EverythingAboutImages.ConvertByteArrayToImage(account.Avatar != null ? account.Avatar.ToArray() : null);
            GenderTextBlock.Text = account.Sex != null ? account.Sex : "n/a";
            JoinedTextBlock.Text = account.Joined == null ? "n/a" : ((DateTime)account.Joined).ToString("dd-MM-yyyy");

            GetFriendsInfo();
            GetStatistics();
            GetHistory();
            if (AppWindow.LoggedUser.Id == account.Id)
            {
                AddFriendButton.Visibility = Visibility.Hidden;
            }
            else
            {
                if (AlreadyFriends())
                {
                    if (friend.IsAcceptedByBoth)
                    {
                        AddFriendImage.Source = (BitmapImage)EverythingAboutImages.Convert(Properties.Resources.removeFriend);
                        AddFriendButton.ToolTip = "Remove Friend";
                    }
                    else
                    {
                        AddFriendImage.Source = (BitmapImage)EverythingAboutImages.Convert(Properties.Resources.friendRequestWaiting);
                        AddFriendButton.ToolTip = "Cancel Friend Request";
                    }
                }
                else
                {
                    if (IsOneSideFriend())
                    {
                        AddFriendImage.Source = (BitmapImage)EverythingAboutImages.Convert(Properties.Resources.acceptFriendRequest);
                        AddFriendButton.ToolTip = "Accept Friend Request";
                    }
                }
            }
        }
        private bool AlreadyFriends()
        {
            loggedUserFriends = MainWindow.client.GetFriendListByAccountId(AppWindow.LoggedUser.Id);
            foreach (var friend in loggedUserFriends)
            {
                if (friend.Friend_Id == account.Id)
                {
                    this.friend = friend;
                    return true;
                }
            }
            return false;
        }
        private bool IsOneSideFriend()
        {
            foreach (var friend in friends)
            {
                if (friend.Friend_Id == AppWindow.LoggedUser.Id)
                {
                    this.oneSideFriend = friend;
                    return true;
                }
            }
            return false;
        }
        private void GetHistory()
        {
            HistoryStackPanel.Children.Clear();
            int maxHistory = 0;
            List<GameList> userGameListL = userGameList.ToList();
            userGameListL.Sort((o1,o2) => o2.DateOfAddition.CompareTo(o1.DateOfAddition));
            foreach (var game in userGameListL)
            {
                if (maxHistory++ < 4)
                {
                    HistoryStackPanel.Children.Add(GetHistoryElement(game));
                }
                else
                {
                    break;
                }
            }
        }
        private HistoryElement GetHistoryElement(GameList gameList)
        {
            Game tmpGame = MainWindow.client.GetGameById(gameList.Game_Id);
            HistoryElement historyElement = new HistoryElement();
            historyElement.Height = Double.NaN;
            historyElement.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(tmpGame.Image != null ? tmpGame.Image.ToArray() : null);
            historyElement.TitleTextBlock.Text = tmpGame.Title;
            historyElement.DateTextBlock.Text = gameList.DateOfAddition == null ? "n/a" : ((DateTime)gameList.DateOfAddition).ToString("dd-MM-yyyy");
            historyElement.StatusTextBlock.Text = gameList.Status;
            historyElement.ScoreTextBlock.Text = gameList.Score.ToString();
            historyElement.MouseUp += new MouseButtonEventHandler((sender, e) => HistoryElement_Clicked(sender, e, tmpGame));
            return historyElement;
        }
        void HistoryElement_Clicked(object sender, RoutedEventArgs e, Game game)
        {
            NavigationService.Navigate(new GamePage(game.Title));
        }
        private void GetStatistics()
        {
            userGameList = MainWindow.client.GetGameListByAccountId(account.Id);
            int currentlyPlaayingCounter = 0, completedCounter = 0, onHoldCounter = 0, planToPlayCounter = 0, droppedCounter = 0;
            foreach (var game in userGameList)
            {
                if (game.Status == "CURRENTLY PLAYING")
                {
                    currentlyPlaayingCounter++;
                }
                else if (game.Status == "COMPLETED")
                {
                    completedCounter++;
                }
                else if (game.Status == "ON HOLD")
                {
                    onHoldCounter++;
                }
                else if (game.Status == "PLAN TO PLAY")
                {
                    planToPlayCounter++;
                }
                else if (game.Status == "DROPPED")
                {
                    droppedCounter++;
                }
            }
            PlayingTextBlock.Text = currentlyPlaayingCounter.ToString();
            CompletedTextBlock.Text = completedCounter.ToString();
            OnHoldTextBlock.Text = onHoldCounter.ToString();
            PlanToPlayTextBlock.Text = planToPlayCounter.ToString();
            DroppedTextBlock.Text = droppedCounter.ToString();
            MeanScoreTextBlock.Text = MainWindow.client.GetAccountAverageScore(account.Id).ToString("F2");
            TotalEntriesTextBlock.Text = userGameList.Length.ToString();
        }
        private void GetFriendsInfo()
        {
            int maxFriends = 0;
            FriendsWrapPanel.Children.Clear();
            friends = MainWindow.client.GetFriendListByAccountId(account.Id);
            NumberOfFriendsTextBlock.Text = friends.Length.ToString();
            foreach (var friend in friends)
            {
                if (maxFriends++ < 6)
                {
                    if (friend.IsAcceptedByBoth)
                    {
                        Account friendAccount = MainWindow.client.GetAccountById(friend.Friend_Id);
                        FriendsWrapPanel.Children.Add(GetInfoOverlay(friendAccount));
                    }
                }
                else
                {
                    break;
                }
            }
        }
        private InfoOverlay GetInfoOverlay(Account account)
        {
            InfoOverlay infoOverlay = new InfoOverlay();
            infoOverlay.HeaderTextBox.Text = account.Nickname;
            infoOverlay.HeaderTextBox.Width = 100;
            infoOverlay.CoverImage.Width = 100;
            infoOverlay.CoverImage.Height = 100;
            infoOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(account.Avatar != null ? account.Avatar.ToArray() : null);
            infoOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => Overlay_Clicked(sender, e, account));
            return infoOverlay;
        }
        void Overlay_Clicked(object sender, RoutedEventArgs e, Account account)
        {
            NavigationService.Navigate(new AccountPage(account));
        }

        private void EditProfile_Clicked(object sender, RoutedEventArgs e)
        {
            EditAccountWindow editAccountWindow = new EditAccountWindow();
            editAccountWindow.ShowDialog();
        }

        private void GameHistory_Clicked(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new HistoryPage(account));
        }

        private void GameListButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GameListPage(account));
        }

        private void AllFriends_Clicked(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new FriendsPage(account));
        }

        private void AddFriendButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (friend == null)
            {
                if (oneSideFriend == null)
                {
                    AddingFriend();
                    AddFriendImage.Source = (BitmapImage)EverythingAboutImages.Convert(Properties.Resources.friendRequestWaiting);
                    AddFriendButton.ToolTip = "Cancel Friend Request";
                    AlreadyFriends();
                }
                else
                {
                    AcceptFriendRequest();
                    AddFriendImage.Source = (BitmapImage)EverythingAboutImages.Convert(Properties.Resources.removeFriend);
                    AddFriendButton.ToolTip = "Remove Friend";
                    AlreadyFriends();
                }
            }
            else if (friend.IsAcceptedByBoth)
            {
                RemoveFriend();
                AddFriendImage.Source = (BitmapImage)EverythingAboutImages.Convert(Properties.Resources.addFriend);
                AddFriendButton.ToolTip = "Add To Friend List";
                friend = null;
                oneSideFriend = null;
            }
            else
            {
                CancelFriendRequest();
                AddFriendImage.Source = (BitmapImage)EverythingAboutImages.Convert(Properties.Resources.addFriend);
                AddFriendButton.ToolTip = "Add To Friend List";
                friend = null;
            }
        }
        private void RemoveFriend()
        {
            IsOneSideFriend();
            MainWindow.client.DeleteFriend(friend.Account_Id, friend.Friend_Id);
            MainWindow.client.DeleteFriend(oneSideFriend.Account_Id, oneSideFriend.Friend_Id);
        }
        private void CancelFriendRequest()
        {
            MainWindow.client.DeleteFriend(friend.Account_Id, friend.Friend_Id);
        }
        private void AcceptFriendRequest()
        {
            Friend newFriend = new Friend();
            newFriend.Account_Id = oneSideFriend.Friend_Id;
            newFriend.Friend_Id = oneSideFriend.Account_Id;
            newFriend.DateOfAdding = DateTime.Now;
            newFriend.IsAcceptedByBoth = true;
            oneSideFriend.IsAcceptedByBoth = true;
            MainWindow.client.UpdateFriend(oneSideFriend.Account_Id, oneSideFriend.Friend_Id, oneSideFriend);
            MainWindow.client.InsertFriend(newFriend);
            var mw = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is AppWindow) as AppWindow;
            int result = int.Parse(mw.NotificationCounter.Text) - 1;
            mw.NotificationCounter.Text = result.ToString();
            if (result == 0)
            {
                mw.NotificationCounter.Visibility = Visibility.Hidden;
            }
        }
        private void AddingFriend()
        {
            Friend newFriend = new Friend();
            newFriend.Account_Id = AppWindow.LoggedUser.Id;
            newFriend.Friend_Id = account.Id;
            newFriend.DateOfAdding = DateTime.Now;
            newFriend.IsAcceptedByBoth = false;
            MainWindow.client.InsertFriend(newFriend);
        }
    }
}
