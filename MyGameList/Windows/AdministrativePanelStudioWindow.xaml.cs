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
    /// Interaction logic for AdministrativePanelStudioWindow.xaml
    /// </summary>
    public partial class AdministrativePanelStudioWindow : Window
    {
        private Studio studio;
        public AdministrativePanelStudioWindow(Studio studio)
        {
            InitializeComponent();
            this.studio = studio;
            if (studio.Indie)
            {
                YesRadioButton.IsChecked = true;
            }
            else
            {
                NoRadioButton.IsChecked = true;
            }
            StudioNameTextBox.Text = studio.Studio1;
        }

        private void NoRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            YesRadioButton.IsChecked = false;
        }

        private void YesRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            NoRadioButton.IsChecked = false;
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (StudioNameTextBox.Text != "" && StudioNameTextBox.Text != null)
            {
                studio.Studio1 = StudioNameTextBox.Text.Trim();
                if (YesRadioButton.IsChecked == true)
                {
                    studio.Indie = true;
                }
                else
                {
                    studio.Indie = false;
                }
                studio.IsAccepted = true;
                MainWindow.client.UpdateStudio(studio.Id, studio);
                MessageWindow messageWindow = new MessageWindow("Studio Updated !", "Studio was successfully updated.");
                messageWindow.ShowDialog();
                this.Close();
            }
            else
            {
                StudioNameErrorTextBlock.Visibility = Visibility.Visible;
                StudioNameTextBox.BorderBrush = Brushes.Red;
            }
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteButton_Clicked(object sender, RoutedEventArgs e)
        {
            MainWindow.client.DeleteStudio(studio.Id);
            MessageWindow messageWindow = new MessageWindow("Studio deleted !", "Studio was successfully deleted.");
            messageWindow.ShowDialog();
            this.Close();
        }
    }
}
