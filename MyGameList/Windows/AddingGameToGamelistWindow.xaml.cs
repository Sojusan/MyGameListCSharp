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
    /// Interaction logic for AddingGameToGamelistWindow.xaml
    /// </summary>
    public partial class AddingGameToGamelistWindow : Window
    {
        private GameList gameList;
        public static bool gameListAdded = false;
        public AddingGameToGamelistWindow(GameList gameList)
        {
            InitializeComponent();
            this.gameList = gameList;
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (StatusComboBox.Text != "")
            {
                gameList.Status = StatusComboBox.Text;
                gameList.Score = ScoreComboBox.Text != "" ? int.Parse(ScoreComboBox.Text) : 0;
                gameList.Review = ReviewTextBox.Text;
                gameList.DateOfAddition = DateTime.Now;
                MainWindow.client.InsertNewGameList(gameList);
                gameListAdded = true;
                MessageWindow messageWindow = new MessageWindow("Success !", "GameList successfully added.");
                messageWindow.ShowDialog();
                this.Close();
            }
            else
            {
                MessageWindow messageWindow = new MessageWindow("Failed !", "Something went wrong. Are you sure you choosed valid status ?");
                messageWindow.ShowDialog();
            }
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MouseLeave_Event(object sender, MouseEventArgs e)
        {
            if (StatusComboBox.Text == "COMPLETED")
            {
                ScoreComboBox.IsEnabled = true;
                ReviewTextBox.IsEnabled = true;
            }
            else
            {
                ScoreComboBox.IsEnabled = false;
                ReviewTextBox.IsEnabled = false;
            }
        }
    }
}
