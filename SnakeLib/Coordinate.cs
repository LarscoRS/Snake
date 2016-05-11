using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLib
{
    public class Coordinate
    {
        public int X { set; get; }
        public int Y { set; get; }
        public Coordinate(int x, int y)
        {
            X = x; Y = y;
        }
    }
}
