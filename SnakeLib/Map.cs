using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SnakeLib
{
    public class Map
    {
        public int Height { set; get; }
        public int Widht { set; get; }
        public List<Snake> Snakes = new List<Snake>();
        public Food Food;

        public Byte[,] matrix = new Byte[51,51];


        public delegate void DeathSnakeDelegate(Snake snake);
        public event DeathSnakeDelegate DeathSnake;


        public Map()
        {
            
        }

        public Map(int height, int widht)
        {
            Height = height;
            Widht = widht;
            Food = new Food(new Coordinate(26,26), System.Drawing.Color.Red);
            for (var i = 0; i < Snakes.Count; i++)
            {
                for (var j = 0; j < Snakes[i].Coordinates.Count; j++)
                {
                    matrix[Snakes[i].Coordinates[j].X, Snakes[i].Coordinates[j].Y] = 1;
                }
            }
            matrix[Food.Coordinate.X, Food.Coordinate.Y] = 2;
            for(var i=0; i<matrix.GetLength(0); i++)
            {
                matrix[0, i] = 1;
                matrix[i,0] = 1;
                matrix[matrix.GetLength(0)-1, i] = 1;
                matrix[i, matrix.GetLength(0)-1] = 1;

            }
        }

        public void createSnake()
        {
            // направление движения змеи: 0 - вверх, 1 - вправо, 2 - вниз, 3 - влево
            List<Coordinate> LC0 = new List<Coordinate>();
            LC0.Add(new Coordinate(1, 3));
            LC0.Add(new Coordinate(1, 2));
            LC0.Add(new Coordinate(1, 1));
            var snake0 = new Snake(System.Drawing.Color.Orange, System.Drawing.Color.Pink, LC0);
            snake0.Way = 2;
            Snakes.Add(snake0);


            List<Coordinate> LC1 = new List<Coordinate>();
            LC1.Add(new Coordinate(Widht-4, 1));
            LC1.Add(new Coordinate(Widht-3, 1));
            LC1.Add(new Coordinate(Widht-2, 1));
            var snake1 = new Snake(System.Drawing.Color.Black, System.Drawing.Color.Brown, LC1);
            snake1.Way = 3;
            Snakes.Add(snake1);

            List<Coordinate> LC2 = new List<Coordinate>();
            LC2.Add(new Coordinate(3, Height-2));
            LC2.Add(new Coordinate(2, Height-2));
            LC2.Add(new Coordinate(1, Height-2));
            var snake2 = new Snake(System.Drawing.Color.Blue, System.Drawing.Color.Violet, LC2);
            snake2.Way = 1;
            Snakes.Add(snake2);

            List<Coordinate> LC3 = new List<Coordinate>();
            LC3.Add(new Coordinate(Widht-2, Height-4));
            LC3.Add(new Coordinate(Widht-2, Height-3));
            LC3.Add(new Coordinate(Widht-2, Height-2));
            var snake3 = new Snake(System.Drawing.Color.Yellow, System.Drawing.Color.Tan, LC3);
            snake3.Way = 0;
            Snakes.Add(snake3);                    

        }

        public void Update()
        {
            for(var i=0; i<Snakes.Count; i++)
            {               
               UpdateOne(Snakes[i]);             
            }
        }

        private void UpdateOne(Snake snake)
        {
            if (snake.Coordinates.Count > 0)
            {
                Coordinate coordHead = new Coordinate(snake.Coordinates[0].X, snake.Coordinates[0].Y);
                // запоминаем координаты головы змеи
                switch (snake.Way)
                {
                    case 0:
                        coordHead.Y--;
                        if (matrix[coordHead.Y, coordHead.X] == 1)
                            //snake.Death();
                            snake.Start();
                        break;
                    case 1:
                        coordHead.X++;
                        if (matrix[coordHead.Y, coordHead.X] == 1)
                            //snake.Death();
                            snake.Start();
                        break;
                    case 2:
                        coordHead.Y++;
                        if (matrix[coordHead.Y, coordHead.X] == 1)
                            //snake.Death();
                            snake.Start();
                        break;
                    case 3:
                        coordHead.X--;
                        if (matrix[coordHead.Y, coordHead.X] == 1)
                            //snake.Death();
                            snake.Start();
                        break;
                }
                // направление движения змеи: 0 - вверх, 1 - вправо, 2 - вниз, 3 - влево                
                try
                {
                    if (matrix[coordHead.Y, coordHead.X] == 2)
                    {
                        snake.Grow(coordHead);
                        matrix[coordHead.Y, coordHead.X] = 1;
                        Random R = new Random();
                        Food = new Food(new Coordinate(R.Next(0, 50), R.Next(0, 50)), System.Drawing.Color.Red);
                        matrix[Food.Coordinate.Y, Food.Coordinate.X] = 2;
                    }

                    if (matrix[coordHead.Y, coordHead.X] == 0)
                    {
                        matrix[snake.Coordinates[snake.Coordinates.Count - 1].Y, snake.Coordinates[snake.Coordinates.Count - 1].X] = 0;
                        snake.Move(coordHead);
                        matrix[coordHead.Y, coordHead.X] = 1;
                    }
                }
                catch { }
            }
        }
      


    }
    }

