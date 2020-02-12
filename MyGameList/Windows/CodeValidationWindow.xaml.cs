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

namespace MyGameList.Windows
{
    /// <summary>
    /// Interaction logic for CodeValidationWindow.xaml
    /// </summary>
    public partial class CodeValidationWindow : Window
    {
        public static bool codeIsCorrect = false;
        private int code;
        public CodeValidationWindow(int code)
        {
            InitializeComponent();
            this.code = code;
        }

        private void AcceptButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (!CodeTextBox.Text.Trim().Equals(""))
            {
                if (String.Equals(CodeTextBox.Text.Trim(), code.ToString()))
                {
                    codeIsCorrect = true;
                    this.Close();
                }
                else
                {
                    CodeTextBox.BorderBrush = Brushes.Red;
                    CodeErrorTextBlock.Text = "Wrong code !";
                    CodeErrorTextBlock.Visibility = Visibility.Visible;
                    codeIsCorrect = false;
                }
            }
            else
            {
                CodeTextBox.BorderBrush = Brushes.Red;
                CodeErrorTextBlock.Text = "This can't be empty !";
                CodeErrorTextBlock.Visibility = Visibility.Visible;
                codeIsCorrect = false;
            }
        }

        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
