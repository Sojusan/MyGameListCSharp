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
    /// Interaction logic for EditingGameFromGameListWindow.xaml
    /// </summary>
    public partial class EditingGameFromGameListWindow : Window
    {
        private GameList gameList;
        public EditingGameFromGameListWindow(GameList gameList)
        {
            InitializeComponent();
            this.gameList = gameList;
            if (gameList.Status != "COMPLETED")
            {
                ScoreComboBox.IsEnabled = false;
                ReviewTextBox.IsEnabled = false;
                StatusComboBox.Text = gameList.Status;
            }
            else
            {
                StatusComboBox.Text = gameList.Status;
                ScoreComboBox.Text = gameList.Score.ToString();
                ReviewTextBox.Text = gameList.Review;
            }
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (StatusComboBox.Text != "")
            {
                gameList.Status = StatusComboBox.Text;
                gameList.Score = int.Parse(ScoreComboBox.Text == "" ? "0" : ScoreComboBox.Text);
                gameList.Review = ReviewTextBox.Text;
                gameList.DateOfAddition = DateTime.Now;
                MainWindow.client.UpdateGameList(gameList);
                MessageWindow messageWindow = new MessageWindow("Success !", "GameList successfully updated.");
                messageWindow.ShowDialog();
                this.Close();
            }
            else
            {
                MessageWindow messageWindow = new MessageWindow("Failed !", "Something went wrong. Are you sure you choosed valid status ?");
                messageWindow.ShowDialog();
            }
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
