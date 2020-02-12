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
    /// Interaction logic for GameListPage.xaml
    /// </summary>
    public partial class GameListPage : Page
    {
        private Account account;
        private GameList[] gameLists;
        private List<Game> games = new List<Game>();
        public GameListPage(Account account)
        {
            InitializeComponent();
            this.account = account;
            NicknameTextBlock.Text = account.Nickname;
            GetGameList();
        }
        private void GetGameList()
        {
            gameLists = MainWindow.client.GetGameListByAccountId(account.Id);
            foreach (var data in gameLists)
            {
                Game tmpGame = MainWindow.client.GetGameById(data.Game_Id);
                games.Add(tmpGame);
            }
        }
        private InfoOverlay GetInfoOverlay(Game game)
        {
            InfoOverlay infoOverlay = new InfoOverlay();
            infoOverlay.HeaderTextBox.Text = game.Title;
            infoOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(game.Image != null ? game.Image.ToArray() : null);
            infoOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => Overlay_Clicked(sender, e, game));
            return infoOverlay;
        }
        void Overlay_Clicked(object sender, RoutedEventArgs e, Game game)
        {
            NavigationService.Navigate(new GamePage(game.Title));
        }

        private void AllGamesButton_Clicked(object sender, RoutedEventArgs e)
        {
            games.Clear();
            GetGameList();
            ImagesWrapPanel.Children.Clear();
            StatusTextBlock.Text = "All Games";
            foreach (var data in games)
            {
                ImagesWrapPanel.Children.Add(GetInfoOverlay(data));
            }
        }

        private void CurrentlyPlayingButton_Clicked(object sender, RoutedEventArgs e)
        {
            GetGameList();
            ImagesWrapPanel.Children.Clear();
            StatusTextBlock.Text = "Currently Playing";
            foreach (var data in gameLists)
            {
                if (data.Status == "CURRENTLY PLAYING")
                {
                    ImagesWrapPanel.Children.Add(GetInfoOverlay(MainWindow.client.GetGameById(data.Game_Id)));
                }
            }
        }

        private void CompletedButton_Clicked(object sender, RoutedEventArgs e)
        {
            GetGameList();
            ImagesWrapPanel.Children.Clear();
            StatusTextBlock.Text = "Completed";
            foreach (var data in gameLists)
            {
                if (data.Status == "COMPLETED")
                {
                    ImagesWrapPanel.Children.Add(GetInfoOverlay(MainWindow.client.GetGameById(data.Game_Id)));
                }
            }
        }

        private void OnHoldButton_Clicked(object sender, RoutedEventArgs e)
        {
            GetGameList();
            ImagesWrapPanel.Children.Clear();
            StatusTextBlock.Text = "On Hold";
            foreach (var data in gameLists)
            {
                if (data.Status == "ON HOLD")
                {
                    ImagesWrapPanel.Children.Add(GetInfoOverlay(MainWindow.client.GetGameById(data.Game_Id)));
                }
            }
        }

        private void DroppedButton_Clicked(object sender, RoutedEventArgs e)
        {
            GetGameList();
            ImagesWrapPanel.Children.Clear();
            StatusTextBlock.Text = "Dropped";
            foreach (var data in gameLists)
            {
                if (data.Status == "DROPPED")
                {
                    ImagesWrapPanel.Children.Add(GetInfoOverlay(MainWindow.client.GetGameById(data.Game_Id)));
                }
            }
        }

        private void PlanToPlayButton_Clicked(object sender, RoutedEventArgs e)
        {
            GetGameList();
            ImagesWrapPanel.Children.Clear();
            StatusTextBlock.Text = "Plan To Play";
            foreach (var data in gameLists)
            {
                if (data.Status == "PLAN TO PLAY")
                {
                    ImagesWrapPanel.Children.Add(GetInfoOverlay(MainWindow.client.GetGameById(data.Game_Id)));
                }
            }
        }
    }
}
