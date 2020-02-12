﻿using System;
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
    /// Interaction logic for PromoteToModeratorWindow.xaml
    /// </summary>
    public partial class PromoteToModeratorWindow : Window
    {
        private Account account;
        public PromoteToModeratorWindow(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void YesButton_Clicked(object sender, RoutedEventArgs e)
        {
            account.IsModerator = true;
            MainWindow.client.UpdateAccount(account.Id, account);
            this.Close();
        }

        private void NoButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
