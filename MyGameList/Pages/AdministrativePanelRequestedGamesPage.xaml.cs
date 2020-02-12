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
using MyGameList.Windows;
using MyGameList.Utilities;

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for AdministrativePanelRequestedGamesPage.xaml
    /// </summary>
    public partial class AdministrativePanelRequestedGamesPage : Page
    {
        public AdministrativePanelRequestedGamesPage()
        {
            InitializeComponent();
            List<Game> requestedGames = MainWindow.client.GetRequestedGames().ToList();
            foreach (var game in requestedGames)
            {
                RequestedGamesWrapPanel.Children.Add(GetInfoOverlay(game));
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
            AdministrativePanelGameWindow administrativePanelGameWindow = new AdministrativePanelGameWindow(game);
            administrativePanelGameWindow.ShowDialog();
        }
    }
}
