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
    /// Interaction logic for AddNewGenreWindow.xaml
    /// </summary>
    public partial class AddNewGenreWindow : Window
    {
        public AddNewGenreWindow()
        {
            InitializeComponent();
            var genres = MainWindow.client.GetAllGenres();
            foreach (var genre in genres)
            {
                AvailableGenresTextBlock.Text += genre.Genre1 + " ";
            }
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (GenreTextBox.Text != "" && GenreTextBox.Text != null)
            {
                if (!GenreAlreadyInBase(GenreTextBox.Text.Trim()))
                {
                    Genre newGenre = new Genre();
                    newGenre.Genre1 = GenreTextBox.Text.Trim();
                    MainWindow.client.InsertNewGenre(newGenre);
                    MessageWindow messageWindow = new MessageWindow("Platform added !", "Platform was successfully added to database.");
                    messageWindow.ShowDialog();
                    this.Close();
                }
                else
                {
                    GenreErrorTextBlock.Text = "Platform already in base !";
                    GenreErrorTextBlock.Visibility = Visibility.Visible;
                    GenreTextBox.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                GenreErrorTextBlock.Text = "This can't be empty !";
                GenreErrorTextBlock.Visibility = Visibility.Visible;
                GenreTextBox.BorderBrush = Brushes.Red;
            }
        }
        private bool GenreAlreadyInBase(string name)
        {
            int genre = MainWindow.client.GetGenreId(name);
            if (genre == -1)
            {
                return false;
            }
            else if (genre >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
