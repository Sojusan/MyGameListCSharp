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
using MyGameList.Windows;
using MyGameList.Models;
using MyGameList.Utilities;

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for AdministrativePanelModeratorPage.xaml
    /// </summary>
    public partial class AdministrativePanelModeratorPage : Page
    {
        public AdministrativePanelModeratorPage()
        {
            InitializeComponent();
        }

        private void ModeratorsButton_Clicked(object sender, RoutedEventArgs e)
        {
            AccountsWrapPanel.Children.Clear();
            List<Account> accounts = MainWindow.client.GetAllAccounts().ToList();
            foreach (var account in accounts)
            {
                if (account.IsModerator && !account.IsAdmin)
                {
                    AccountsWrapPanel.Children.Add(GetModeratorInfoOverlay(account));
                }
            }
        }

        private void UsersButton_Clicked(object sender, RoutedEventArgs e)
        {
            AccountsWrapPanel.Children.Clear();
            List<Account> accounts = MainWindow.client.GetAllAccounts().ToList();
            foreach (var account in accounts)
            {
                if (!account.IsAdmin && !account.IsModerator)
                {
                    AccountsWrapPanel.Children.Add(GetUserInfoOverlay(account));
                }
            }
        }
        private InfoOverlay GetModeratorInfoOverlay(Account account)
        {
            InfoOverlay infoOverlay = new InfoOverlay();
            infoOverlay.HeaderTextBox.Text = account.Nickname;
            infoOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(account.Avatar != null ? account.Avatar.ToArray() : null);
            infoOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => DemoteOverlay_Clicked(sender, e, account));
            return infoOverlay;
        }
        private InfoOverlay GetUserInfoOverlay(Account account)
        {
            InfoOverlay infoOverlay = new InfoOverlay();
            infoOverlay.HeaderTextBox.Text = account.Nickname;
            infoOverlay.CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(account.Avatar != null ? account.Avatar.ToArray() : null);
            infoOverlay.MouseUp += new MouseButtonEventHandler((sender, e) => PromoteOverlay_Clicked(sender, e, account));
            return infoOverlay;
        }
        void DemoteOverlay_Clicked(object sender, RoutedEventArgs e, Account account)
        {
            DemoteToNormalWindow demoteToNormalWindow = new DemoteToNormalWindow(account);
            demoteToNormalWindow.ShowDialog();
        }
        void PromoteOverlay_Clicked(object sender, RoutedEventArgs e, Account account)
        {
            PromoteToModeratorWindow promoteToModeratorWindow = new PromoteToModeratorWindow(account);
            promoteToModeratorWindow.ShowDialog();
        }
    }
}
