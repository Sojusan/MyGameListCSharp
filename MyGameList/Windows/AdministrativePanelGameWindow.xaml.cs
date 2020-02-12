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
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WcfServiceLibrary;
using MyGameList.Utilities;
using Syncfusion;

namespace MyGameList.Windows
{
    /// <summary>
    /// Interaction logic for AdministrativePanelGameWindow.xaml
    /// </summary>
    public partial class AdministrativePanelGameWindow : Window
    {
        private Game game;
        private BitmapImage coverImage = null;
        private bool isAcceptedTitle = false, isAcceptedStudio = false, isAccepedPublisher = false, isAcceptedPremiere = false, isAcceptedPlatforms = false, isAcceptedGenres = false, isAcceptedCoverImage = false, isAcceptedDescription = false;
        private List<Platform> platforms;
        private List<Genre> genres;
        private Studio studio;
        public AdministrativePanelGameWindow(Game game)
        {
            InitializeComponent();
            this.game = game;
            platforms = MainWindow.client.GetAllPlatforms().ToList();
            List<string> allPlatforms = new List<string>();
            foreach (var platform in platforms)
            {
                allPlatforms.Add(platform.Platform1);
            }
            PlatformsComboBoxAdv.ItemsSource = allPlatforms;
            var alreadySelectedPlatforms = MainWindow.client.GetGamePlatformsList(game.Id);
            ObservableCollection<string> selectionPlatforms = new ObservableCollection<string>();
            foreach (var item in alreadySelectedPlatforms)
            {
                selectionPlatforms.Add(item);
            }
            PlatformsComboBoxAdv.SelectedItems = selectionPlatforms;
            genres = MainWindow.client.GetAllGenres().ToList();
            List<string> allGenres = new List<string>();
            foreach (var genre in genres)
            {
                allGenres.Add(genre.Genre1);
            }
            GenresComboBoxAdv.ItemsSource = allGenres;
            var alreadySelectedGenres = MainWindow.client.GetGameGenresList(game.Id);
            ObservableCollection<string> selectionGenres = new ObservableCollection<string>();
            foreach (var item in alreadySelectedGenres)
            {
                selectionGenres.Add(item);
            }
            GenresComboBoxAdv.SelectedItems = selectionGenres;
            TitleTextBox.Text = game.Title;
            StudioTextBox.Text = MainWindow.client.GetStudioName(game.Studio_Id);
            PublisherTextBox.Text = game.Publisher;
            PremiereDatePicker.Text = game.Premiere == null ? "n/a" : ((DateTime)game.Premiere).ToString("dd-MM-yyyy");
            DescriptionTextBox.Text = game.Description;
            CoverImage.Source = EverythingAboutImages.ConvertByteArrayToImage(game.Image != null ? game.Image.ToArray() : null);
            if (game.Image != null)
            {
                coverImage = EverythingAboutImages.ConvertByteArrayToImage(game.Image.ToArray());
            }
        }

        private void SelectFileButton_Clicked(object sender, RoutedEventArgs e)
        {
            coverImage = EverythingAboutImages.GetImageFromFile();
            CoverImage.Source = coverImage;
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {
            VerifyFields();
            if (isAcceptedTitle && isAcceptedStudio && isAccepedPublisher && isAcceptedPremiere && isAcceptedPlatforms && isAcceptedGenres && isAcceptedCoverImage && isAcceptedDescription)
            {
                game.Title = TitleTextBox.Text;
                game.Studio_Id = studio.Id;
                game.Publisher = PublisherTextBox.Text;
                DateTime? date = null;
                DateTime result;
                bool success = DateTime.TryParse(PremiereDatePicker.Text.Trim(), out result);
                if (success)
                {
                    date = result;
                }
                game.Premiere = date;
                game.Image = coverImage != null ? EverythingAboutImages.ConvertImageToByteArray(coverImage) : null;
                game.Description = DescriptionTextBox.Text;
                MainWindow.client.DeleteAllGamePlatforms(game.Id);
                MainWindow.client.DeleteAllGameGenres(game.Id);
                foreach (var item in PlatformsComboBoxAdv.SelectedItems)
                {
                    foreach (var platform in platforms)
                    {
                        if (platform.Platform1 == item.ToString())
                        {
                            Game_platform newGamePlatform = new Game_platform();
                            newGamePlatform.Game_Id = MainWindow.client.GetGameId(game.Title);
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
                            newGameGenre.Game_Id = MainWindow.client.GetGameId(game.Title);
                            newGameGenre.Genre_Id = MainWindow.client.GetGenreId(item.ToString());
                            MainWindow.client.InsertNewGameGenre(newGameGenre);
                        }
                    }
                }
                game.IsAccepted = true;
                MainWindow.client.UpdateGame(game.Id, game);
                MessageWindow messageWindow = new MessageWindow("Information updated !", "Informations was successfully edited.");
                messageWindow.ShowDialog();
                this.Close();
            }
        }
        private void VerifyFields()
        {
            if (TitleTextBox.Text != "" && TitleTextBox.Text != null)
            {
                TitleTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                TitleErrorTextBlock.Visibility = Visibility.Hidden;
                isAcceptedTitle = true;
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
            if (PublisherTextBox.Text != "" && PublisherTextBox.Text != null)
            {
                PublisherTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                PublisherErrorTextBlock.Visibility = Visibility.Hidden;
                isAccepedPublisher = true;
            }
            else
            {
                PublisherTextBox.BorderBrush = Brushes.Red;
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
            if (PremiereDatePicker.Text != null && PremiereDatePicker.Text != "")
            {
                PremiereErrorTextBlock.Visibility = Visibility.Hidden;
                isAcceptedPremiere = true;
            }
            else
            {
                PremiereErrorTextBlock.Text = "This can't be empty !";
                PremiereErrorTextBlock.Visibility = Visibility.Visible;
                isAcceptedPremiere = false;
            }
            if (coverImage != null)
            {
                CoverImageBorder.BorderBrush = Brushes.Black;
                CoverErrorTextBlock.Visibility = Visibility.Hidden;
                isAcceptedCoverImage = true;
            }
            else
            {
                CoverImageBorder.BorderBrush = Brushes.Red;
                CoverErrorTextBlock.Text = "This can't be empty !";
                CoverErrorTextBlock.Visibility = Visibility.Visible;
                isAcceptedCoverImage = false;
            }
            if (DescriptionTextBox.Text != "" && DescriptionTextBox.Text != null)
            {
                DescriptionErrorTextBlock.Visibility = Visibility.Hidden;
                DescriptionTextBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
                isAcceptedDescription = true;
            }
            else
            {
                DescriptionErrorTextBlock.Text = "This can't be empty !";
                DescriptionErrorTextBlock.Visibility = Visibility.Visible;
                DescriptionTextBox.BorderBrush = Brushes.Red;
                isAcceptedDescription = false;
            }
        }

        private void DeleteButton_Clicked(object sender, RoutedEventArgs e)
        {
            DeleteGameWindow deleteGameWindow = new DeleteGameWindow();
            deleteGameWindow.ShowDialog();
            if (DeleteGameWindow.isAccepted)
            {
                DeleteGameWindow.isAccepted = false;
                MainWindow.client.DeleteGameEntry(game.Id);
                MessageWindow messageWindow = new MessageWindow("Game deleted !", "Game was successfully deleted from database.");
                messageWindow.ShowDialog();
                this.Close();
            }
        }
    }
}
