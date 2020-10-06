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
        protected const int MIDDLE_POSITION = 400;
        protected const int LEFT_POSITION = 185;
        protected const int RIGHT_POSITION = 590;

        const string MIDDLE_POSITION_SIGN = "m";
        const string LEFT_POSITION_SIGN = "l";
        const string RIGHT_POSITION_SIGN = "r";


        private string position;


        protected Image current_car_image;
        public CarObject(Image car_image) : base(400, 340, 50, 100)
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
                Canvas.SetLeft(this.current_car_image, MIDDLE_POSITION);
                this.x_position = MIDDLE_POSITION;
            }
            else if (this.position == MIDDLE_POSITION_SIGN)
            {
                this.position = RIGHT_POSITION_SIGN;
                Canvas.SetLeft(this.current_car_image, RIGHT_POSITION);
                this.x_position = RIGHT_POSITION;
            }
        }


        //Move the player car left
        public void ModeLeft()
        {
            if (this.position == RIGHT_POSITION_SIGN)
            {
                this.position = MIDDLE_POSITION_SIGN;
                Canvas.SetLeft(this.current_car_image, MIDDLE_POSITION);
                this.x_position = MIDDLE_POSITION;
            }
            else if (this.position == MIDDLE_POSITION_SIGN)
            {
                this.position = LEFT_POSITION_SIGN;
                Canvas.SetLeft(this.current_car_image, LEFT_POSITION);
                this.x_position = LEFT_POSITION;
            }
        }

        
    }
}
