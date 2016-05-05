using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLib
{
    public class Snake
    {
        public List<Coordinate> Coordinates { set; get; }
        public int lenght { get { return Coordinates.Count; }}     
        public int Way { set; get; }  // направление движения змеи: 0 - вверх, 1 - вправо, 2 - вниз, 3 - влево
        public Color Head { set; get; }
        public Color Body { set; get; }               

        public Snake(Color head, Color body, List<Coordinate> coordinates)
        {
            Head = head;
            Body = body;
            Coordinates = coordinates;           
        }



        public void Start()
        {
            Random R = new Random();
            int x=R.Next(4, 46);
            int y= R.Next(4, 46);
            List<Coordinate> LC2 = new List<Coordinate>();
            LC2.Add(new Coordinate(x, y));
            LC2.Add(new Coordinate(x-1, y));
            LC2.Add(new Coordinate(x-2, y));
            Coordinates = LC2;
            Way = 1;          
        }

        public void Grow(Coordinate newPosition)
        {
            var newBlock = newPosition;
            Coordinates.Insert(0, newBlock);
            
        }
        public void Move(Coordinate newPosition)
        {
            var newBlock = newPosition;
            Coordinates.Insert(0, newBlock);            
            Coordinates.RemoveAt(Coordinates.Count-1);
        }
        public void Death()
        {            
            Coordinates = new List<Coordinate>();            
        }


    }
}
