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
using MyGameList.Windows;
using MyGameList.Utilities;

namespace MyGameList.Windows
{
    /// <summary>
    /// Interaction logic for RequestGameWindow.xaml
    /// </summary>
    public partial class RequestGameWindow : Window
    {
        private BitmapImage previewImage = null;
        private bool isAcceptedTitle = false, isAcceptedStudio = false, isAccepedPublisher = false, isAcceptedPlatforms = false, isAcceptedGenres = false;
        private List<Platform> platforms;
        private List<Genre> genres;
        private Studio studio;
        public RequestGameWindow()
        {
            InitializeComponent();
            platforms = MainWindow.client.GetAllPlatforms().ToList();
            List<string> allPlatforms = new List<string>();
            foreach (var platform in platforms)
            {
                allPlatforms.Add(platform.Platform1);
            }
            PlatformsComboBoxAdv.ItemsSource = allPlatforms;
            PlatformsComboBoxAdv.DefaultText = "Choose Platforms ...";
            genres = MainWindow.client.GetAllGenres().ToList();
            List<string> allGenres = new List<string>();
            foreach (var genre in genres)
            {
                allGenres.Add(genre.Genre1);
            }
            GenresComboBoxAdv.ItemsSource = allGenres;
            GenresComboBoxAdv.DefaultText = "Choose Genres ...";
        }

        private void SelectFileButton_Clicked(object sender, RoutedEventArgs e)
        {
            previewImage = EverythingAboutImages.GetImageFromFile();
            PreviewImage.Source = previewImage;
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {
            VerifyFields();
            if (isAcceptedTitle && isAcceptedStudio && isAccepedPublisher && isAcceptedPlatforms && isAcceptedGenres)
            {
                Game newGame = new Game();
                newGame.Title = TitleTextBox.Text.Trim();
                newGame.Studio_Id = studio.Id;
                newGame.Publisher = PublisherTestBox.Text.Trim();
                DateTime? date = null;
                DateTime result;
                bool success = DateTime.TryParse(PremiereDatePicker.Text.Trim(), out result);
                if (success)
                {
                    date = result;
                }
                newGame.Premiere = date;
                newGame.IsAccepted = false;
                newGame.Image = previewImage != null ? EverythingAboutImages.ConvertImageToByteArray(previewImage) : null;
                newGame.Description = DescriptionTextBox.Text;
                newGame.DateOfAddiction = DateTime.Now;
                MainWindow.client.InsertNewGame(newGame);
                foreach (var item in PlatformsComboBoxAdv.SelectedItems)
                {
                    foreach (var platform in platforms)
                    {
                        if (platform.Platform1 == item.ToString())
                        {
                            Game_platform newGamePlatform = new Game_platform();
                            newGamePlatform.Game_Id = MainWindow.client.GetGameId(newGame.Title);
                            newGamePlatform.Platform_Id = MainWindow.client.GetPlatformId(item.ToString());
                            MainWindow.client.InsertNewGamePlatform(newGamePlatform);
                        }
                    }
                }
                foreach (var item in GenresComboBoxAdv.SelectedItems)
                {
                    foreach (var genre in genres)
                    {
                        if (genre.Genre1 == item.ToString())
                        {
                            Game_genre newGameGenre = new Game_genre();
                            newGameGenre.Game_Id = MainWindow.client.GetGameId(newGame.Title);
                            newGameGenre.Genre_Id = MainWindow.client.GetGenreId(item.ToString());
                            MainWindow.client.InsertNewGameGenre(newGameGenre);
                        }
                    }
                }
                MessageWindow messageWindow = new MessageWindow("Game added !", "Game successfully added. Now administration need to accept this game. Please be patient.");
                messageWindow.ShowDialog();
                this.Close();
            }
        }
        private void VerifyFields()
        {
            if (TitleTextBox.Text != "" && TitleTextBox.Text != null)
            {
                if (!MainWindow.client.IsGameAlreadyExist(TitleTextBox.Text.Trim().ToLower()))
                {
                    TitleTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                    TitleErrorTextBlock.Visibility = Visibility.Hidden;
                    isAcceptedTitle = true;
                }
                else
                {
                    TitleTextBox.BorderBrush = Brushes.Red;
                    TitleErrorTextBlock.Text = "Game already in database !";
                    TitleErrorTextBlock.Visibility = Visibility.Visible;
                    isAcceptedTitle = false;
                }
            }
            else
            {
                TitleTextBox.BorderBrush = Brushes.Red;
                TitleErrorTextBlock.Text = "This can't be empty !";
                TitleErrorTextBlock.Visibility = Visibility.Visible;
                isAcceptedTitle = false;
            }
            if (StudioTextBox.Text != "" && StudioTextBox.Text != null)
            {
                studio = MainWindow.client.GetStudioByName(StudioTextBox.Text.Trim().ToLower());
                if (studio != null)
                {
                    StudioTextBox.Text = studio.Studio1;
                    StudioTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                    StudioErrorTextBlock.Visibility = Visibility.Hidden;
                    isAcceptedStudio = true;
                }
                else
                {
                    StudioTextBox.BorderBrush = Brushes.Red;
                    StudioErrorTextBlock.Text = "Add Studio first !";
                    StudioErrorTextBlock.Visibility = Visibility.Visible;
                    isAcceptedStudio = false;
                }
            }
            else
            {
                StudioTextBox.BorderBrush = Brushes.Red;
                StudioErrorTextBlock.Text = "This can't be empty !";
                StudioErrorTextBlock.Visibility = Visibility.Visible;
                isAcceptedStudio = false;
            }
            if (PublisherTestBox.Text != "" && PublisherTestBox.Text != null)
            {
                PublisherTestBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                PublisherErrorTextBlock.Visibility = Visibility.Hidden;
                isAccepedPublisher = true;
            }
            else
            {
                PublisherTestBox.BorderBrush = Brushes.Red;
                PublisherErrorTextBlock.Text = "This can't be empty !";
                PublisherErrorTextBlock.Visibility = Visibility.Visible;
                isAccepedPublisher = false;
            }
            if (PlatformsComboBoxAdv.SelectedItems != null)
            {
                PlatformsErrorTextBlock.Visibility = Visibility.Hidden;
                isAcceptedPlatforms = true;
            }
            else
            {
                PlatformsErrorTextBlock.Text = "This can't be empty !";
                PlatformsErrorTextBlock.Visibility = Visibility.Visible;
                isAcceptedPlatforms = false;
            }
            if (GenresComboBoxAdv.SelectedItems != null)
            {
                GenresErrorTextBlock.Visibility = Visibility.Hidden;
                isAcceptedGenres = true;
            }
            else
            {
                GenresErrorTextBlock.Text = "This can't be empty !";
                GenresErrorTextBlock.Visibility = Visibility.Visible;
                isAcceptedGenres = false;
            }
        }
    }
}
