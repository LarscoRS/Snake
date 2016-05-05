using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace SnakeLib
{
    public class Food:Block
    {
        public Food(Coordinate coord, Color color)
        {
            this.Coordinate = coord;
            Color = color;
        }

        
    }
}
