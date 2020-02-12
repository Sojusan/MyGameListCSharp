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
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using WpfAnimatedGif;
using MyGameList.Utilities;
using WcfServiceLibrary;
using MyGameList.Models;

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private Game[] games;
        private List<TopGame> topGames = new List<TopGame>();
        public MenuPage()
        {
            InitializeComponent();
            games = MainWindow.client.GetAllGamesByDateOfAddiction();
            foreach (var game in games)
            {
                TopGame topGame = new TopGame(game);
                topGames.Add(topGame);
            }
            topGames.Sort((o1, o2) => o2.score.CompareTo(o1.score));

            GetTopGamesOverlays();
            GetNewestEntryOverlays();
            GetRecentFriendsUpdates();
        }
        private void GetRecentFriendsUpdates()
        {
            RecentFriendsUpdatesWrapPanel.Children.Clear();
            List<Friend> friends = MainWindow.client.GetFriendListBothAcceptedByAccountId(AppWindow.LoggedUser.Id).ToList();
            List<GameList> friendsGameLists = new List<GameList>();
            foreach (var friend in friends)
            {
                GameList[] gameList = MainWindow.client.GetGameListByAccountId(friend.Friend_Id);
                foreach (var data in gameList)
                {
                    friendsGameLists.Add(data);
                }
            }
            friendsGameLists.Sort((o1, o2) => o2.DateOfAddition.CompareTo(o1.DateOfAddition));
            int maxRecentFriendUpdates = 0;
            foreach (var data in friendsGameLists)
            {
                if (maxRecentFriendUpdates++ < 5)
                {
                    RecentFriendsUpdatesWrapPanel.Children.Add(GetRecentFriendUpdate(data));
                }
                else
                {
                    break;
                }
            }
        }
        private RecentFriendUpdate GetRecentFriendUpdate(GameList gameList)
        {
            RecentFriendUpdate recentFriendUpdate = new RecentFriendUpdate();
            Game tmpGame = MainWindow.client.GetGameById(gameList.Game_Id);
            Account tmpAccount = MainWindow.client.GetAccountById(gameList.Account_Id);
            recentFriendUpdate.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(tmpGame.Image != null ? tmpGame.Image.ToArray() : null);
            recentFriendUpdate.TitleTextBlock.Text = tmpGame.Title;
            recentFriendUpdate.StatusTextBlock.Text = gameList.Status;
            recentFriendUpdate.ScoreTextBlock.Text = gameList.Score.ToString();
            recentFriendUpdate.DateTextBlock.Text = gameList.DateOfAddition.ToString("dd-MM-yyyy");
            recentFriendUpdate.NicknameTextBlock.Text = tmpAccount.Nickname;
            recentFriendUpdate.NicknameTextBlock.MouseUp += new MouseButtonEventHandler((sender, e) => NicknameTextBlock_Clicked(sender, e, tmpAccount));
            recentFriendUpdate.CoverImage.MouseUp += new MouseButtonEventHandler((sender, e) => CoverImage_Clicked(sender, e, tmpGame));
            return recentFriendUpdate;
        }
        void NicknameTextBlock_Clicked(object sender, RoutedEventArgs e, Account account)
        {
            NavigationService.Navigate(new AccountPage(account));
        }
        void CoverImage_Clicked(object sender, RoutedEventArgs e, Game game)
        {
            NavigationService.Navigate(new GamePage(game.Title));
        }
        private void GetNewestEntryOverlays()
        {
            FirstNewestEntryOverlay.HeaderTextBox.Text = games[0].Title;
            if (games[0].Image != null)
            {
                FirstNewestEntryOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(games[0].Image.ToArray());
            }
            FirstNewestEntryOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => Overlay_Clicked(sender, e, games[0]));
            FirstNewestEntryCoverRectangle.Visibility = Visibility.Hidden;
            FirstNewestEntryCoverImage.Visibility = Visibility.Hidden;
            SecondNewestEntryOverlay.HeaderTextBox.Text = games[1].Title;
            if (games[1].Image != null)
            {
                SecondNewestEntryOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(games[1].Image.ToArray());
            }
            SecondNewestEntryOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => Overlay_Clicked(sender, e, games[1]));
            SecondNewestEntryCoverRectangle.Visibility = Visibility.Hidden;
            SecondNewestEntryCoverImage.Visibility = Visibility.Hidden;
            ThirdNewestEntryOverlay.HeaderTextBox.Text = games[2].Title;
            if (games[2].Image != null)
            {
                ThirdNewestEntryOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(games[2].Image.ToArray());
            }
            ThirdNewestEntryOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => Overlay_Clicked(sender, e, games[2]));
            ThirdNewestEntryCoverRectangle.Visibility = Visibility.Hidden;
            ThirdNewestEntryCoverImage.Visibility = Visibility.Hidden;
            FourthNewestEntryOverlay.HeaderTextBox.Text = games[3].Title;
            if (games[3].Image != null)
            {
                FourthNewestEntryOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(games[3].Image.ToArray());
            }
            FourthNewestEntryOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => Overlay_Clicked(sender, e, games[3]));
            FourthNewestEntryCoverRectangle.Visibility = Visibility.Hidden;
            FourthNewestEntryCoverImage.Visibility = Visibility.Hidden;
        }
        private void GetTopGamesOverlays()
        {
            FirstTopGameOverlay.HeaderTextBox.Text = topGames[0].Title;
            if (topGames[0].Image != null)
            {
                FirstTopGameOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(topGames[0].Image.ToArray());
            }
            FirstTopGameOverlay.MouseUp += new MouseButtonEventHandler((sender, e)=> Overlay_Clicked(sender, e, topGames[0]));
            FirstTopGamesCoverRectangle.Visibility = Visibility.Hidden;
            FirstTopGamesCoverImage.Visibility = Visibility.Hidden;
            SecondTopGamesOverlay.HeaderTextBox.Text = topGames[1].Title;
            if (topGames[1].Image != null)
            {
                SecondTopGamesOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(topGames[1].Image.ToArray());
            }
            SecondTopGamesOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => Overlay_Clicked(sender, e, topGames[1]));
            SecondTopGamesCoverRectangle.Visibility = Visibility.Hidden;
            SecondTopGamesCoverImage.Visibility = Visibility.Hidden;
            ThirdTopGamesOverlay.HeaderTextBox.Text = topGames[2].Title;
            if (topGames[2].Image != null)
            {
                ThirdTopGamesOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(topGames[2].Image.ToArray());
            }
            ThirdTopGamesOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => Overlay_Clicked(sender, e, topGames[2]));
            ThirdTopGamesCoverRectangle.Visibility = Visibility.Hidden;
            ThirdTopGamesCoverImage.Visibility = Visibility.Hidden;
            FourthTopGamesOverlay.HeaderTextBox.Text = topGames[3].Title;
            if (topGames[3].Image != null)
            {
                FourthTopGamesOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(topGames[3].Image.ToArray());
            }
            FourthTopGamesOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => Overlay_Clicked(sender, e, topGames[3]));
            FourthTopGamesCoverRectangle.Visibility = Visibility.Hidden;
            FourthTopGamesCoverImage.Visibility = Visibility.Hidden;
        }
        void Overlay_Clicked(object sender, RoutedEventArgs e, Game game)
        {
            NavigationService.Navigate(new GamePage(game.Title));
        }
    }
}
