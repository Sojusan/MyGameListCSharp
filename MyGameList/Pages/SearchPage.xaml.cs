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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        private Game[] listOfGames;
        private Account[] listOfAccounts;
        private List<TopGame> topGames = new List<TopGame>();
        public SearchPage()
        {
            InitializeComponent();
            SearchByComboBox.IsEnabled = false;
        }

        private void SearchButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (!SearchForComboBox.Text.Equals("") && !SearchByComboBox.Text.Equals(""))
            {
                SearchWrapPanel.Children.Clear();
                DoSearch();
            }
        }
        private void DoSearch()
        {
            if (SearchForComboBox.Text == "Games")
            {
                listOfGames = MainWindow.client.GetAllGamesByDateOfAddiction();
                if (SearchByComboBox.Text == "Get all")
                {
                    foreach (var game in listOfGames)
                    {
                        SearchWrapPanel.Children.Add(GetInfoOverlay(game));
                    }
                }
                else if (SearchByComboBox.Text == "Title")
                {
                    foreach (var game in listOfGames)
                    {
                        if (game.Title.ToLower().Contains(InputTextBox.Text.ToLower()))
                        {
                            SearchWrapPanel.Children.Add(GetInfoOverlay(game));
                        }
                    }
                }
                else if (SearchByComboBox.Text == "Studio")
                {
                    foreach (var game in listOfGames)
                    {
                        if (MainWindow.client.GetStudioName(game.Studio_Id).ToLower().Contains(InputTextBox.Text.ToLower()))
                        {
                            SearchWrapPanel.Children.Add(GetInfoOverlay(game));
                        }
                    }
                }
                else if (SearchByComboBox.Text == "Publisher")
                {
                    foreach (var game in listOfGames)
                    {
                        if (game.Publisher.ToLower().Contains(InputTextBox.Text.ToLower()))
                        {
                            SearchWrapPanel.Children.Add(GetInfoOverlay(game));
                        }
                    }
                }
                else if (SearchByComboBox.Text == "Top")
                {
                    foreach (var game in listOfGames)
                    {
                        TopGame topGame = new TopGame(game);
                        topGames.Add(topGame);
                    }
                    topGames.Sort((o1, o2) => o2.score.CompareTo(o1.score));
                    foreach (var game in topGames)
                    {
                        SearchWrapPanel.Children.Add(GetInfoOverlay(game));
                    }
                }
            }
            else
            {
                listOfAccounts = MainWindow.client.GetAllAccounts();
                if (SearchByComboBox.Text == "Get all")
                {
                    foreach (var account in listOfAccounts)
                    {
                        SearchWrapPanel.Children.Add(GetAccountInfoOverlay(account));
                    }
                }
                else if (SearchByComboBox.Text == "Nickname")
                {
                    foreach (var account in listOfAccounts)
                    {
                        if (account.Nickname.ToLower().Contains(InputTextBox.Text.ToLower()))
                        {
                            SearchWrapPanel.Children.Add(GetAccountInfoOverlay(account));
                        }
                    }
                }
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
        private InfoOverlay GetAccountInfoOverlay(Account account)
        {
            InfoOverlay infoOverlay = new InfoOverlay();
            infoOverlay.HeaderTextBox.Text = account.Nickname;
            infoOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(account.Avatar != null ? account.Avatar.ToArray() : null);
            infoOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => AccountOverlay_Clicked(sender, e, account));
            return infoOverlay;
        }
        void Overlay_Clicked(object sender, RoutedEventArgs e, Game game)
        {
            NavigationService.Navigate(new GamePage(game.Title));
        }
        void AccountOverlay_Clicked(object sender, RoutedEventArgs e, Account account)
        {
            NavigationService.Navigate(new AccountPage(account));
        }

        private void MouseLeave_Event(object sender, MouseEventArgs e)
        {
            SearchByComboBox.Items.Clear();
            if (SearchForComboBox.Text.Equals("Games"))
            {
                SearchByComboBox.Items.Add("Get all");
                SearchByComboBox.Items.Add("Title");
                SearchByComboBox.Items.Add("Studio");
                SearchByComboBox.Items.Add("Publisher");
                SearchByComboBox.Items.Add("Top");
                SearchByComboBox.IsEnabled = true;
            }
            else if (SearchForComboBox.Text.Equals("Users"))
            {
                SearchByComboBox.Items.Add("Get all");
                SearchByComboBox.Items.Add("Nickname");
                SearchByComboBox.IsEnabled = true;
            }
            else
            {
                SearchByComboBox.IsEnabled = false;
            }
        }
    }
}
