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
using MyGameList.Windows;

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for AdministrativePanelPage.xaml
    /// </summary>
    public partial class AdministrativePanelPage : Page
    {
        public AdministrativePanelPage()
        {
            InitializeComponent();
            if (AppWindow.LoggedUser.IsAdmin)
            {
                PromoteToModeratorButton.Visibility = Visibility.Visible;
            }
            else
            {
                PromoteToModeratorButton.Visibility = Visibility.Hidden;
            }
        }

        private void PromoteToModeratorButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdministrativePanelModeratorPage());
        }

        private void AddNewGenreButton_Clicked(object sender, RoutedEventArgs e)
        {
            AddNewGenreWindow addNewGenreWindow = new AddNewGenreWindow();
            addNewGenreWindow.ShowDialog();
        }

        private void AddNewPlatformButton_Clicked(object sender, RoutedEventArgs e)
        {
            AddNewPlatformWindow addNewPlatformWindow = new AddNewPlatformWindow();
            addNewPlatformWindow.ShowDialog();
        }

        private void RequestedStudiosButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdministrativePanelRequestedStudiosPage());
        }

        private void RequestedGamesButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdministrativePanelRequestedGamesPage());
        }
    }
}
