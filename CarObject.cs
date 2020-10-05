using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace shir_heler_project
{
    class CarObject : GameObject
    {
        Thickness MIDDLE_POSITION = new Thickness(390, 296, 352, 23);
        Thickness LEFT_POSITION = new Thickness(184, 300, 558, 19);
        Thickness RIGHT_POSITION = new Thickness(582, 302, 160, 17);

        const string MIDDLE_POSITION_SIGN = "m";
        const string LEFT_POSITION_SIGN = "l";
        const string RIGHT_POSITION_SIGN = "r";


        private string position;


        private Image current_car_image;
        public CarObject(Image car_image) : base(390, 296, 50, 100)
        {
            this.current_car_image = car_image;
            this.position = MIDDLE_POSITION_SIGN;
        }

        //Move the player car right
        public void MoveRight()
        {
            if (this.position == LEFT_POSITION_SIGN)
            {
                this.position = MIDDLE_POSITION_SIGN;
                this.current_car_image.Margin = MIDDLE_POSITION;
            }
            else if (this.position == MIDDLE_POSITION_SIGN)
            {
                this.position = RIGHT_POSITION_SIGN;
                this.current_car_image.Margin = RIGHT_POSITION;
            }
        }


        //Move the player car left
        public void ModeLeft()
        {
            if (this.position == RIGHT_POSITION_SIGN)
            {
                this.position = MIDDLE_POSITION_SIGN;
                this.current_car_image.Margin = MIDDLE_POSITION;
            }
            else if (this.position == MIDDLE_POSITION_SIGN)
            {
                this.position = LEFT_POSITION_SIGN;
                this.current_car_image.Margin = LEFT_POSITION;
            }
        }

        
    }
}
