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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WcfServiceLibrary;
using MyGameList.Windows;

namespace MyGameList.Pages
{
    /// <summary>
    /// Interaction logic for AdministrativePanelRequestedStudiosPage.xaml
    /// </summary>
    public partial class AdministrativePanelRequestedStudiosPage : Page
    {
        public AdministrativePanelRequestedStudiosPage()
        {
            InitializeComponent();
            List<Studio> studios = MainWindow.client.GetRequestedStudios().ToList();
            foreach (var studio in studios)
            {
                RequestedStudiosWrapPanel.Children.Add(GetRequestedStudioTextBlock(studio));
            }
        }
        private TextBlock GetRequestedStudioTextBlock(Studio studio)
        {
            TextBlock studioTextBlock = new TextBlock();
            studioTextBlock.Text = studio.Studio1;
            studioTextBlock.Cursor = Cursors.Hand;
            studioTextBlock.TextTrimming = TextTrimming.CharacterEllipsis;
            studioTextBlock.FontSize = 36;
            studioTextBlock.FontWeight = FontWeights.Bold;
            studioTextBlock.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0FB200"));
            studioTextBlock.Margin = new Thickness(15,0,0,15);
            studioTextBlock.MouseUp += new MouseButtonEventHandler((sender, e) => StudioElement_Clicked(sender, e, studio));
            return studioTextBlock;
        }
        void StudioElement_Clicked(object sender, RoutedEventArgs e, Studio studio)
        {
            AdministrativePanelStudioWindow administrativePanelStudioWindow = new AdministrativePanelStudioWindow(studio);
            administrativePanelStudioWindow.ShowDialog();
        }

        private void StudiosButton_Clicked(object sender, RoutedEventArgs e)
        {
            RequestedStudiosWrapPanel.Children.Clear();
            List<Studio> studios = MainWindow.client.GetStudioList().ToList();
            foreach (var studio in studios)
            {
                RequestedStudiosWrapPanel.Children.Add(GetRequestedStudioTextBlock(studio));
            }
        }

        private void RequestedStudiosButton_Clicked(object sender, RoutedEventArgs e)
        {
            RequestedStudiosWrapPanel.Children.Clear();
            List<Studio> studios = MainWindow.client.GetRequestedStudios().ToList();
            foreach (var studio in studios)
            {
                RequestedStudiosWrapPanel.Children.Add(GetRequestedStudioTextBlock(studio));
            }
        }
    }
}
