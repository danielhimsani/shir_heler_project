using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace shir_heler_project
{
    class GameObject
    {
        protected int x_position { get; set;}
        protected int y_position { get; set; }
        protected int width { get; set; }
        protected int height { get; set; }
        public GameObject(int x_position, int y_position, int width, int height)
        {
            this.x_position = x_position;
            this.y_position = y_position;
            this.width = width;
            this.height = height;
        }

        //Check if the current object is collapse with another object
        public bool IsBounceOtherObject(GameObject other_object)
        {
            return (Math.Abs(this.x_position - other_object.x_position) * 2 < (this.width + other_object.width) &&
                Math.Abs(this.y_position - other_object.y_position) * 2 < (this.height + other_object.height));
        }
    }
}
