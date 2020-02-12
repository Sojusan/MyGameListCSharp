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
using MyGameList.Utilities;
using MyGameList.Models;

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for ReviewPage.xaml
    /// </summary>
    public partial class ReviewPage : Page
    {
        private Game game;
        public ReviewPage(Game game)
        {
            InitializeComponent();
            this.game = game;
            TitleTextBlock.Text = game.Title;
            CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(game.Image != null ? game.Image.ToArray() : null);
            StudioTextBlock.Text = MainWindow.client.GetStudioName(game.Studio_Id);
            PublisherTextBlock.Text = game.Publisher;
            PremiereTextBlock.Text = game.Premiere == null ? "n/a" : ((DateTime)game.Premiere).ToString("dd-MM-yyyy");
            PlatformsTextBlock.Text = MainWindow.client.GetGamePlatforms(game.Id);
            GenresTextBlock.Text = MainWindow.client.GetGameGenres(game.Id);
            GetReviews();
        }
        private void GetReviews()
        {
            ReviewsWrapPanel.Children.Clear();
            List<GameList> gameLists = MainWindow.client.GetGameListByGameId(game.Id).ToList();
            List<GameList> reviewGameList = new List<GameList>();
            foreach (var data in gameLists)
            {
                if ((data.Review != "" || data.Review != null) && data.Score != 0 && data.Status == "COMPLETED")
                {
                    reviewGameList.Add(data);
                }
            }
            if (reviewGameList.Count != 0)
            {
                reviewGameList.Sort((o1, o2) => ((DateTime)o2.DateOfAddingReview).CompareTo((DateTime)o1.DateOfAddingReview));
                foreach (var data in reviewGameList)
                {
                    ReviewsWrapPanel.Children.Add(GetReviewElement(data));
                }
            }
        }
        private ReviewElement GetReviewElement(GameList gameList)
        {
            Account tmpAccount = MainWindow.client.GetAccountById(gameList.Account_Id);
            ReviewElement reviewElement = new ReviewElement();
            reviewElement.Width = Double.NaN;
            reviewElement.AvatarImage.Source = EverythingAboutImages.ConvertByteArrayToImage(tmpAccount.Avatar != null ? tmpAccount.Avatar.ToArray() : null);
            reviewElement.NicknameTextBlock.Text = tmpAccount.Nickname;
            reviewElement.DateTextBlock.Text = gameList.DateOfAddingReview == null ? "n/a" : ((DateTime)gameList.DateOfAddingReview).ToString("dd-MM-yyyy");
            reviewElement.ReviewTextBlock.Text = gameList.Review;
            reviewElement.MouseUp += new MouseButtonEventHandler((sender, e) => ReviewElement_Clicked(sender, e, tmpAccount));
            return reviewElement;
        }
        void ReviewElement_Clicked(object sender, RoutedEventArgs e, Account account)
        {
            NavigationService.Navigate(new AccountPage(account));
        }

    }
}
