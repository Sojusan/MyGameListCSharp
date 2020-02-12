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
    /// Interaction logic for HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        private Account account;
        public HistoryPage(Account account)
        {
            InitializeComponent();
            this.account = account;
            NicknameTextBlock.Text = account.Nickname;
            GetHistory();
        }
        private void GetHistory()
        {
            HistoryWrapPanel.Children.Clear();
            List<GameList> userGameListL = MainWindow.client.GetGameListByAccountId(account.Id).ToList();
            userGameListL.Sort((o1, o2) => o2.DateOfAddition.CompareTo(o1.DateOfAddition));
            foreach (var game in userGameListL)
            {
                HistoryWrapPanel.Children.Add(GetHistoryElement(game));
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
            historyElement.MinWidth = 300;
            return historyElement;
        }
        void HistoryElement_Clicked(object sender, RoutedEventArgs e, Game game)
        {
            NavigationService.Navigate(new GamePage(game.Title));
        }
    }
}
