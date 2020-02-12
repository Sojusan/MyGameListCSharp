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
using System.Windows.Shapes;
using WcfServiceLibrary;

namespace MyGameList.Windows
{
    /// <summary>
    /// Interaction logic for DeleteFromFollowConfirmationWindow.xaml
    /// </summary>
    public partial class DeleteFromFollowConfirmationWindow : Window
    {
        private Follow follow;
        public static bool followDeleted = false;
        public DeleteFromFollowConfirmationWindow(Follow follow)
        {
            InitializeComponent();
            this.follow = follow;
        }

        private void NoButton_Clicked(object sender, RoutedEventArgs e)
        {
            followDeleted = false;
            this.Close();
        }

        private void YesButton_Clcikced(object sender, RoutedEventArgs e)
        {
            followDeleted = true;
            MainWindow.client.DeleteFollowEntry(follow.Account_Id, follow.Game_Id);
            this.Close();
        }
    }
}
