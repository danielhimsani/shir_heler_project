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
using System.ComponentModel;

namespace shir_heler_project
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        const string LEFT_KEY = "Left";
        const string RIGHT_KEY = "Right";
        const int BACKGROUND_START_TOP = -1030; 

        CarObject player_car_object;

        private int background_top;

        private List<EnemyCar> enemys = new List<EnemyCar>();

        public GameWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            this.background_top = BACKGROUND_START_TOP;
            this.player_car_object = new CarObject(player_car);
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);

            //the background scorller thread
            ScrollBackground();

            

            //the random cars spawn thread
            SpawnEnemysCarsThread();

            //the thread that handle the deleting to the dead cars
            HandleDeadCars();


            //the thread that check everytime if the player car crashed with other cars
            CheckForCrush();

        }



        private void CheckForCrush()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    lock (this.enemys)
                    {
                        for (int i = 0; i < this.enemys.Count && this.enemys.Count != 0; i++)
                        {
                            if (this.player_car_object.IsBounceOtherObject(this.enemys[i]))
                            {
                                //Well excpet an TaksCancledExeption is case the window were closed -> so we want to end the task
                                try
                                {
                                    Dispatcher.Invoke(() =>
                                    {
                                        this.Close();
                                    });
                                }
                                catch (TaskCanceledException)
                                {
                                    break;
                                }
                                
                            }
                        }
                    }
                }
            });
        }

        //Spawn the enemys cars on the road thread
        private void SpawnEnemysCarsThread()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    EnemyCar temp_enemy = null;
                    Dispatcher.Invoke(() =>
                    {
                        temp_enemy = new EnemyCar(new Image(), this.game_canvas);
                    });
                    //lock this variable because number of threads trying to get accsess this object
                    lock(this.enemys)
                    {
                        this.enemys.Add(temp_enemy);
                    }
                    System.Threading.Thread.Sleep(1800);
                }
            });
        }

        //This thread check the cars and if any car dead -> she delete its object from the enemys list 
        private void HandleDeadCars()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    //lock this variable because number of threads trying to get accsess this object
                    lock (this.enemys)
                    {
                        for (int i = 0; i < this.enemys.Count && this.enemys.Count != 0; i++)
                        {
                            if (!this.enemys[i].IsAlive())// if the car is dead (out of window frame)
                            {
                                this.enemys.Remove(this.enemys[i]);

                            }
                        }
                        System.Threading.Thread.Sleep(200);
                    }
                }
            });
        }

        //This thread just scrool the background for the driving animation
        private void ScrollBackground()
        {
            Task.Run(() => {
                while (true)
                {
                    this.background_top += 1;
                    if (this.background_top >= -30)
                    {
                        this.background_top = BACKGROUND_START_TOP;
                    }
                    System.Threading.Thread.Sleep(6);

                    //Well excpet an TaksCancledExeption is case the window were closed -> so we want to end the task
                    try
                    {
                        Dispatcher.Invoke(() =>
                        {
                            Canvas.SetTop(window_background, this.background_top);
                        });
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
                    
                }
            });
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
