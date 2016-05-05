using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SnakeLib
{
    public class Block
    {
        public Coordinate Coordinate { set; get; }
        public Color Color { set; get; }

        public Block(Coordinate newCoordinate, Color newColor)
        {
            Coordinate = newCoordinate;
            Color = newColor;
        }

        public Block() { }
    }
}
