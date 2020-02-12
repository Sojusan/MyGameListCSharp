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
    /// Interaction logic for AddNewPlatformWindow.xaml
    /// </summary>
    public partial class AddNewPlatformWindow : Window
    {
        public AddNewPlatformWindow()
        {
            InitializeComponent();
            var platforms = MainWindow.client.GetAllPlatforms();
            foreach (var platform in platforms)
            {
                AvailablePlatfromsTextBlock.Text += platform.Platform1 + " ";
            }
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (PlatformTextBox.Text != "" && PlatformTextBox.Text != null)
            {
                if (!PlatformAlreadyInBase(PlatformTextBox.Text.Trim()))
                {
                    Platform newPlatform = new Platform();
                    newPlatform.Platform1 = PlatformTextBox.Text.Trim();
                    MainWindow.client.InsertNewPlatform(newPlatform);
                    MessageWindow messageWindow = new MessageWindow("Platform added !", "Platform was successfully added to database.");
                    messageWindow.ShowDialog();
                    this.Close();
                }
                else
                {
                    PlatformErrorTextBlock.Text = "Platform already in base !";
                    PlatformErrorTextBlock.Visibility = Visibility.Visible;
                    PlatformTextBox.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                PlatformErrorTextBlock.Text = "This can't be empty !";
                PlatformErrorTextBlock.Visibility = Visibility.Visible;
                PlatformTextBox.BorderBrush = Brushes.Red;
            }
        }
        private bool PlatformAlreadyInBase(string name)
        {
            int platform = MainWindow.client.GetPlatformId(name);
            if (platform == -1)
            {
                return false;
            }
            else if (platform >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
