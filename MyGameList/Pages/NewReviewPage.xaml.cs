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
using MyGameList.Windows;

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for NewReviewPage.xaml
    /// </summary>
    public partial class NewReviewPage : Page
    {
        public NewReviewPage()
        {
            InitializeComponent();
            NicknameTextBlock.Text = AppWindow.LoggedUser.Nickname;
            GetNewReviews();
        }
        private void GetNewReviews()
        {
            NewReviewsWrapPanel.Children.Clear();
            List<Follow> follows = MainWindow.client.GetFollowListByAccountId(AppWindow.LoggedUser.Id).ToList();
            follows.Sort((o1, o2) => o2.NewReview.CompareTo(o1.NewReview));
            foreach (var follow in follows)
            {
                NewReviewsWrapPanel.Children.Add(GetNewReviewElement(follow));
            }
        }
        private NewReviewElement GetNewReviewElement(Follow follow)
        {
            NewReviewElement newReviewElement = new NewReviewElement();
            Game game = MainWindow.client.GetGameById(follow.Game_Id);
            newReviewElement.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(game.Image != null ? game.Image.ToArray() : null);
            newReviewElement.NewReviewsCounterTextBlock.Text = follow.NewReview.ToString();
            newReviewElement.CoverImage.MouseUp += new MouseButtonEventHandler((sender, e) => CoverImage_Clicked(sender, e, game));
            newReviewElement.MarkReviewsAsReadedButton.Click += new RoutedEventHandler((sender, e) => MarkReviewsAsReadedButton_Clicked(sender, e, follow, newReviewElement));
            return newReviewElement;
        }
        void CoverImage_Clicked(object sender, RoutedEventArgs e, Game game)
        {
            NavigationService.Navigate(new GamePage(game.Title));
        }
        void MarkReviewsAsReadedButton_Clicked(object sender, RoutedEventArgs e, Follow follow, NewReviewElement newReviewElement)
        {
            MarkAsReadedConfirmationWindow markAsReadedConfirmationWindow = new MarkAsReadedConfirmationWindow();
            markAsReadedConfirmationWindow.ShowDialog();
            if (MarkAsReadedConfirmationWindow.isAccepted)
            {
                MarkAsReadedConfirmationWindow.isAccepted = false;
                var mw = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is AppWindow) as AppWindow;
                int result = int.Parse(mw.NotificationCounter.Text) - int.Parse(newReviewElement.NewReviewsCounterTextBlock.Text);
                mw.NotificationCounter.Text = result.ToString();
                if (result == 0)
                {
                    mw.NotificationCounter.Visibility = Visibility.Hidden;
                }
                newReviewElement.NewReviewsCounterTextBlock.Text = "0";
                MainWindow.client.UpdateFollow(follow.Account_Id, follow.Game_Id);
            }
        }
    }
}
