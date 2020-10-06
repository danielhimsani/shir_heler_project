using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace shir_heler_project
{
    class EnemyCar : CarObject
    {
        const int NUMBERS_OF_CARS = 8;

        int[] positions = new int[] { MIDDLE_POSITION, LEFT_POSITION, RIGHT_POSITION };
        private int car_top = -100;
        private bool is_alive;
        Canvas current_canvas;

        public EnemyCar(Image car_image, Canvas current_canvas): base(car_image)
        {
            this.current_canvas = current_canvas;
            int selected_car_index = new Random().Next(1, NUMBERS_OF_CARS + 1);
            int random_lane_index = new Random().Next(0, positions.Length);

            BitmapImage car_image_url = new BitmapImage();
            car_image_url.BeginInit();
            car_image_url.UriSource = new Uri("pack://application:,,,/images/random_road_cars/"+ selected_car_index + ".png");
            car_image_url.EndInit();
            car_image.Source = car_image_url;

            this.is_alive = true;

            current_car_image.Width = 50;
            current_car_image.Height = 100;
            Canvas.SetLeft(current_car_image, positions[random_lane_index]);
            Canvas.SetTop(current_car_image, this.car_top);

            this.x_position = positions[random_lane_index];
            this.y_position = this.car_top;
            current_canvas.Children.Add(current_car_image);

            drive_car();


        }

        public void drive_car()
        {
            Task.Run(() =>{
                while (true)
                {
                    this.car_top += 1;
                    if (this.car_top >= 500)
                    {
                        this.is_alive = false;
                        break;
                    }
                    System.Threading.Thread.Sleep(6);
                    if (Application.Current != null)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Canvas.SetTop(this.current_car_image, this.car_top);
                            this.y_position = this.car_top;

                        });
                    }
                    else
                    {
                        break;
                    }
                }
            });
        }

        public bool IsAlive()
        {
            return this.is_alive;
        }






    }
}
