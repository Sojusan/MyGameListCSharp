using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
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
using MyGameList.ServiceReference;
using MyGameList.Utilities;
using WcfServiceLibrary;
using MyGameList.Windows;

namespace MyGameList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Service1Client client = new Service1Client();
        public static MyGameListEventLog myGameListEventLog = new MyGameListEventLog();
        public MainWindow()
        {
            InitializeComponent();
            if (ServiceController.GetServices().Any(ServiceController => ServiceController.ServiceName.Equals("MyGameList")) == false || new ServiceController("MyGameList").Status == ServiceControllerStatus.Stopped)
            {
                myGameListEventLog.WriteEntry("Problem with service 'MyGameList'.", "Error");
                MessageWindow messageWindow = new MessageWindow("Problem dedected !", "Service 'MyGameList' not exist or is disabled. Run it before starting a application.");
                messageWindow.ShowDialog();
                this.Close();
            }
            MainFrame.Navigate(new LoginPage());
            myGameListEventLog.WriteEntry("Application started.", "Info");
        }

        private void WindowClosing_Event(object sender, CancelEventArgs e)
        {
            myGameListEventLog.WriteEntry("Application closed.", "Info");
            Application.Current.Shutdown();
        }
    }
}
