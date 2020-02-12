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

namespace MyGameList.Windows
{
    /// <summary>
    /// Interaction logic for RequestStudioWindow.xaml
    /// </summary>
    public partial class RequestStudioWindow : Window
    {
        public RequestStudioWindow()
        {
            InitializeComponent();
        }

        private void NoRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            YesRadioButton.IsChecked = false;
        }

        private void YesRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            NoRadioButton.IsChecked = false;
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (StudioNameTextBox.Text != "" && StudioNameTextBox.Text != null)
            {
                if (!CheckIfStudioExist(StudioNameTextBox.Text.Trim()))
                {
                    Studio newStudio = new Studio();
                    if (NoRadioButton.IsChecked == true)
                    {
                        newStudio.Indie = false;
                    }
                    else
                    {
                        newStudio.Indie = true;
                    }
                    newStudio.IsAccepted = false;
                    newStudio.Studio1 = StudioNameTextBox.Text.Trim();
                    MainWindow.client.InsertNewStudio(newStudio);
                    MessageWindow messageWindow = new MessageWindow("Studio added !", "Studio successfully added. Now administration need to accept this studio. Please be patient.");
                    messageWindow.ShowDialog();
                    this.Close();
                }
                else
                {
                    StudioNameErrorTextBlock.Text = "This Studio already in database !";
                    StudioNameErrorTextBlock.Visibility = Visibility.Visible;
                    StudioNameTextBox.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                StudioNameErrorTextBlock.Text = "This can't be empty !";
                StudioNameErrorTextBlock.Visibility = Visibility.Visible;
                StudioNameTextBox.BorderBrush = Brushes.Red;
            }
        }
        private bool CheckIfStudioExist(string name)
        {
            List<Studio> studios = MainWindow.client.GetStudioList().ToList();
            foreach (var studio in studios)
            {
                if (studio.Studio1.ToLower().Equals(name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
