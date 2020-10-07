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

namespace shir_heler_project
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void sign_in_button_click(object sender, RoutedEventArgs e)
        {
            SignInWindow sign_in_window = new SignInWindow();
            sign_in_window.Show();
            this.Close();
        }

        private void sign_up_button_click(object sender, RoutedEventArgs e)
        {
            SignInWindow sign_in_window = new SignInWindow();
            sign_in_window.Show();
            this.Close();
        }
    }
}
