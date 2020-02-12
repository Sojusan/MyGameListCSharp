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
using MyGameList.Pages;
using WcfServiceLibrary;

namespace MyGameList.Models
{
    /// <summary>
    /// Interaction logic for InfoOverlay.xaml
    /// </summary>
    public partial class InfoOverlay : UserControl
    {
        private double oldHeight = 0.0;
        public InfoOverlay()
        {
            InitializeComponent();
        }

        private void MouseEnter_Event(object sender, MouseEventArgs e)
        {
            oldHeight = HeaderTextBox.Height;
            HeaderTextBox.Height = Double.NaN;
        }

        private void MouseLeft_Event(object sender, MouseEventArgs e)
        {
            HeaderTextBox.Height = oldHeight;
        }
    }
}
