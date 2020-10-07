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

namespace shir_heler_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            Dictionary<string, string> properties = new Dictionary<string, string>();

            //default car color
            properties.Add("car_color", "red");

            DBWrapper.ExecuteSqlCommand("users.sqlite", "select * from users");
        }

        private void play_button_clicked(object sender, RoutedEventArgs e)
        {
            GameWindow game_window = new GameWindow();
            game_window.Show();
            this.Close();
        }

        private void leaderboard_click(object sender, RoutedEventArgs e)
        {
            LeaderboardWindow leaderboard_window = new LeaderboardWindow();
            leaderboard_window.Show();
            this.Close();
        }

        private void sign_in_button(object sender, RoutedEventArgs e)
        {
            SignInWindow sign_in_window = new SignInWindow();
            sign_in_window.Show();
            this.Close();
        }
    }
}
