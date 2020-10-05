using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        const string LEFT_KEY = "Left";
        const string RIGHT_KEY = "Right";

        CarObject player_car_object;
        public GameWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.player_car_object = new CarObject(player_car);
            

            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
        }

        //Event listener for keyboard clicking
        //Used to moving the car from lane to lane
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == LEFT_KEY)
            {
                this.player_car_object.ModeLeft();
            }
            else if (e.Key.ToString() == RIGHT_KEY)
            {
                this.player_car_object.MoveRight();
            }
                
        }
    }
}
