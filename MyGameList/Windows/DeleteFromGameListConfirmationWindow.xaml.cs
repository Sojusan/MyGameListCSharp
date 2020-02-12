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
    /// Interaction logic for DeleteFromGameListConfirmationWindow.xaml
    /// </summary>
    public partial class DeleteFromGameListConfirmationWindow : Window
    {
        private GameList gameList;
        public static bool gameListDeleted = false;
        public DeleteFromGameListConfirmationWindow(GameList gameList)
        {
            InitializeComponent();
            this.gameList = gameList;
        }

        private void YesButton_Clicked(object sender, RoutedEventArgs e)
        {
            gameListDeleted = true;
            MainWindow.client.DeleteGameListEntry(gameList.Account_Id, gameList.Game_Id);
            this.Close();
        }

        private void NoButton_Clicked(object sender, RoutedEventArgs e)
        {
            gameListDeleted = false;
            this.Close();
        }
    }
}
