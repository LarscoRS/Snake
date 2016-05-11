using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace SnakeLib
{
    public class Food
    {
        public Coordinate Coordinate { set; get; }
        public Color Color { set; get; }
        public Food(Coordinate coord, Color color)
        {
            Coordinate = coord;
            Color = color;
        }

        public Food() { }
        
    }
}
