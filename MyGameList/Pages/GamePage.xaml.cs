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
using Syncfusion.Windows.Primitives;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WcfServiceLibrary;
using MyGameList.Windows;
using MyGameList.Utilities;

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private Follow follow;
        private GameList gameList;
        private GameList[] loggedUserGameList;
        private Follow[] loggedUserFollowList;
        private Game[] games;
        private List<TopGame> topGames = new List<TopGame>();
        private List<PopularityGame> popularityGames = new List<PopularityGame>();
        private Game game;
        public GamePage(string title)
        {
            InitializeComponent();
            this.game = MainWindow.client.GetGameByTitle(title);
            TitleTextBlock.Text = game.Title;
            CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(game.Image != null ? game.Image.ToArray() : null);
            StudioTextBlock.Text = MainWindow.client.GetStudioName(game.Studio_Id);
            PublisherTextBlock.Text = game.Publisher;
            PremiereTextBlock.Text = game.Premiere == null ? "n/a" : ((DateTime)game.Premiere).ToString("dd-MM-yyyy");
            PlatformsTextBlock.Text = MainWindow.client.GetGamePlatforms(game.Id);
            GenresTextBlock.Text = MainWindow.client.GetGameGenres(game.Id);
            if (!AppWindow.LoggedUser.IsAdmin && !AppWindow.LoggedUser.IsModerator )
            {
                EditGameButton.Visibility = Visibility.Hidden;
            }
            double score = MainWindow.client.GetGameScore(game.Id);
            ScoreTextBlock.Text = score.ToString("F2");
            Raiting.Value = score / 2;
            NumberOfUsersForScoreTextBlock.Text = "" + MainWindow.client.GetNumberOfScores(game.Id);
            games = MainWindow.client.GetAllGamesByDateOfAddiction();
            RankedTextBlock.Text = "" + GetPositionInTopGames();
            PopularityTextBlock.Text = "" + GetPositionInPopularityGames();
            MembersTextBlock.Text = "" + MainWindow.client.GetGameMembers(game.Id);
            DescriptionTextBox.Text = game.Description;

            if (GameInUserGameList())
            {
                EditGameListButton.Visibility = Visibility.Visible;
                AddToGameListButton.Background = Brushes.White;
                AddToGameListButton.Foreground = Brushes.Black;
                AddToGameListButton.Content = "Delete From GameList";
                AddToFollowButton.Visibility = Visibility.Hidden;
            }
            if (GameInUserFollowList())
            {
                AddToFollowButton.Background = Brushes.White;
                AddToFollowButton.Foreground = Brushes.Black;
                AddToFollowButton.Content = "Delete From FollowList";
                AddToGameListButton.Visibility = Visibility.Hidden;
            }
            GetReview();
        }
        private void GetReview()
        {
            List<GameList> gameGameList = MainWindow.client.GetGameListByGameId(game.Id).ToList();
            List<GameList> reviewsGameList = new List<GameList>();
            foreach (var game in gameGameList)
            {
                if ((game.Review != "" || game.Review != null) && game.Score != 0 && game.Status == "COMPLETED")
                {
                    reviewsGameList.Add(game);
                }
            }
            if (reviewsGameList.Count != 0)
            {
                reviewsGameList.Sort((o1, o2) => ((DateTime)o2.DateOfAddingReview).CompareTo((DateTime)o1.DateOfAddingReview));
                Account reviewAccount = MainWindow.client.GetAccountById(reviewsGameList[0].Account_Id);
                ReviewThing.AvatarImage.Source = EverythingAboutImages.ConvertByteArrayToImage(reviewAccount.Avatar != null ? reviewAccount.Avatar.ToArray() : null);
                ReviewThing.NicknameTextBlock.Text = reviewAccount.Nickname;
                ReviewThing.DateTextBlock.Text = reviewsGameList[0].DateOfAddingReview == null ? "n/a" : ((DateTime)reviewsGameList[0].DateOfAddingReview).ToString("dd-MM-yyyy");
                ReviewThing.ReviewTextBlock.Text = reviewsGameList[0].Review;
            }
            else
            {
                ReviewThing.Visibility = Visibility.Hidden;
            }
        }
        private bool GameInUserGameList()
        {
            loggedUserGameList = MainWindow.client.GetGameListByAccountId(AppWindow.LoggedUser.Id);
            foreach (var data in loggedUserGameList)
            {
                Game tmpGame = MainWindow.client.GetGameById(data.Game_Id);
                if (tmpGame.Id == game.Id)
                {
                    gameList = data;
                    return true;
                }
            }
            return false;
        }
        private bool GameInUserFollowList()
        {
            loggedUserFollowList = MainWindow.client.GetFollowListByAccountId(AppWindow.LoggedUser.Id);
            foreach (var data in loggedUserFollowList)
            {
                Game tmpGame = MainWindow.client.GetGameById(data.Game_Id);
                if (tmpGame.Id == game.Id)
                {
                    follow = data;
                    return true;
                }
            }
            return false;
        }
        private int GetPositionInTopGames()
        {
            foreach (var game in games)
            {
                TopGame topGame = new TopGame(game);
                topGames.Add(topGame);
            }
            topGames.Sort((o1, o2) => o2.score.CompareTo(o1.score));
            for (int i = 0; i < topGames.Count; i++)
            {
                if (topGames[i].Id == game.Id)
                    return i + 1;
            }
            return 0;
        }
        private int GetPositionInPopularityGames()
        {
            foreach (var game in games)
            {
                PopularityGame popularityGame = new PopularityGame(game);
                popularityGames.Add(popularityGame);
            }
            popularityGames.Sort((o1, o2) => o2.members.CompareTo(o1.members));
            for (int i = 0; i < popularityGames.Count; i++)
            {
                if (popularityGames[i].Id == game.Id)
                    return i + 1;
            }
            return 0;
        }

        private void EditGameButton_Clicked(object sender, RoutedEventArgs e)
        {
            AdministrativePanelGameWindow administrativePanelGameWindow = new AdministrativePanelGameWindow(game);
            administrativePanelGameWindow.ShowDialog();
        }

        private void AddToFollowButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (GameInUserFollowList())
            {
                DeleteFromFollowConfirmationWindow deleteFromFollowConfirmationWindow = new DeleteFromFollowConfirmationWindow(follow);
                deleteFromFollowConfirmationWindow.ShowDialog();
                if (DeleteFromFollowConfirmationWindow.followDeleted)
                {
                    DeleteFromFollowConfirmationWindow.followDeleted = false;
                    AddToFollowButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                    AddToFollowButton.Foreground = Brushes.White;
                    AddToFollowButton.Content = "Add To Follow";
                    AddToGameListButton.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Follow newFollow = new Follow();
                newFollow.Account_Id = AppWindow.LoggedUser.Id;
                newFollow.Game_Id = game.Id;
                newFollow.DateOfFollowing = DateTime.Now;
                MainWindow.client.InsertNewFollow(newFollow);
                AddToFollowButton.Content = "Delete From Follow";
                AddToFollowButton.Background = Brushes.White;
                AddToFollowButton.Foreground = Brushes.Black;
                AddToGameListButton.Visibility = Visibility.Hidden;
            }
        }

        private void AddToGameListButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (GameInUserGameList())
            {
                DeleteFromGameListConfirmationWindow deleteFromGameListConfirmationWindow = new DeleteFromGameListConfirmationWindow(gameList);
                deleteFromGameListConfirmationWindow.ShowDialog();
                if (DeleteFromGameListConfirmationWindow.gameListDeleted)
                {
                    DeleteFromGameListConfirmationWindow.gameListDeleted = false;
                    AddToGameListButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                    AddToGameListButton.Foreground = Brushes.White;
                    AddToGameListButton.Content = "Add To GameList";
                    EditGameListButton.Visibility = Visibility.Hidden;
                    AddToFollowButton.Visibility = Visibility.Visible;
                }
            }
            else
            {
                GameList newGameList = new GameList();
                newGameList.Account_Id = AppWindow.LoggedUser.Id;
                newGameList.Game_Id = game.Id;
                AddingGameToGamelistWindow addingGameToGamelistWindow = new AddingGameToGamelistWindow(newGameList);
                addingGameToGamelistWindow.ShowDialog();
                if (AddingGameToGamelistWindow.gameListAdded)
                {
                    AddingGameToGamelistWindow.gameListAdded = false;
                    AddToGameListButton.Background = Brushes.White;
                    AddToGameListButton.Foreground = Brushes.Black;
                    EditGameListButton.Visibility = Visibility.Visible;
                    AddToFollowButton.Visibility = Visibility.Hidden;
                }
            }
        }

        private void EditGameListButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (GameInUserGameList())
            {
                EditingGameFromGameListWindow editingGameFromGameListWindow = new EditingGameFromGameListWindow(gameList);
                editingGameFromGameListWindow.ShowDialog();
            }
        }

        private void MoreReviews_Clicked(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ReviewPage(game));
        }
    }
}
