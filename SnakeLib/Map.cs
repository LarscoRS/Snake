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
        public Food Food { set; get; }
        public Byte[,] Matrix { set; get; }


       // public delegate void DeathSnakeDelegate(Snake snake);
       // public event DeathSnakeDelegate DeathSnake;

        public Map()
        {
           
        }

        public Map(int height, int widht)
        {
            Height = height;
            Widht = widht;          
            Matrix = new Byte[Height, Widht];

            Food = new Food(new Coordinate(25,25), System.Drawing.Color.Red);         
            Matrix[Food.Coordinate.X, Food.Coordinate.Y] = 3;

            // Граница
            for(var i=0; i<Matrix.GetLength(0); i++)
            {
                Matrix[0, i] = 1;
                Matrix[i, 0] = 1;
                Matrix[Matrix.GetLength(0)-1, i] = 1;
                Matrix[i, Matrix.GetLength(0)-1] = 1;
            }
        }


        public void createSnake(int CountPlayer, int CountBots, bool Bots)
        {
            // направление движения змеи: 0 - вверх, 1 - вправо, 2 - вниз, 3 - влево
            if (CountPlayer > 0)
            {
                List<Coordinate> LC0 = new List<Coordinate>();
                LC0.Add(new Coordinate(1, 3));
                LC0.Add(new Coordinate(1, 2));
                LC0.Add(new Coordinate(1, 1));
                var snake0 = new Snake(System.Drawing.Color.Orange, System.Drawing.Color.Pink, LC0);
                snake0.Way = 2;
                //if (CountBots > 0 && Bots == true)
                //{
                //    snake0.IsBot = true;
                //    CountBots--;
                //}
                Snakes.Add(snake0);
                Matrix[Snakes[0].Coordinates[0].Y, Snakes[0].Coordinates[0].X] = 2;
                Matrix[Snakes[0].Coordinates[1].Y, Snakes[0].Coordinates[1].X] = 1;
                Matrix[Snakes[0].Coordinates[2].Y, Snakes[0].Coordinates[2].X] = 1;
                CountPlayer--;
            }

            if (CountPlayer > 0)
            {
                List<Coordinate> LC1 = new List<Coordinate>();
                LC1.Add(new Coordinate(Widht - 4, 1));
                LC1.Add(new Coordinate(Widht - 3, 1));
                LC1.Add(new Coordinate(Widht - 2, 1));
                var snake1 = new Snake(System.Drawing.Color.Black, System.Drawing.Color.Brown, LC1);
                snake1.Way = 3;
                //if (CountBots > 0 && Bots == true)
                //{
                //    snake1.IsBot = true;
                //    CountBots--;
                //}
                Snakes.Add(snake1);
                Matrix[Snakes[1].Coordinates[0].Y, Snakes[1].Coordinates[0].X] = 2;
                Matrix[Snakes[1].Coordinates[1].Y, Snakes[1].Coordinates[1].X] = 1;
                Matrix[Snakes[1].Coordinates[2].Y, Snakes[1].Coordinates[2].X] = 1;
                CountPlayer--;
            }
         


            if (CountPlayer > 0)
            {
                List<Coordinate> LC2 = new List<Coordinate>();
                LC2.Add(new Coordinate(3, Height - 2));
                LC2.Add(new Coordinate(2, Height - 2));
                LC2.Add(new Coordinate(1, Height - 2));
                var snake2 = new Snake(System.Drawing.Color.Blue, System.Drawing.Color.Violet, LC2);
                snake2.Way = 1;
                //if (CountBots > 0 && Bots == true)
                //{
                //    snake2.IsBot = true;
                //    CountBots--;
                //}
                Snakes.Add(snake2);
                Matrix[Snakes[2].Coordinates[0].Y, Snakes[2].Coordinates[0].X] = 2;
                Matrix[Snakes[2].Coordinates[1].Y, Snakes[2].Coordinates[1].X] = 1;
                Matrix[Snakes[2].Coordinates[2].Y, Snakes[2].Coordinates[2].X] = 1;
                CountPlayer--;
            }

            if (CountPlayer > 0)
            {
                List<Coordinate> LC3 = new List<Coordinate>();
                LC3.Add(new Coordinate(Widht - 2, Height - 4));
                LC3.Add(new Coordinate(Widht - 2, Height - 3));
                LC3.Add(new Coordinate(Widht - 2, Height - 2));
                var snake3 = new Snake(System.Drawing.Color.Yellow, System.Drawing.Color.Tan, LC3);
                snake3.Way = 0;
                //if (CountBots > 0 && Bots == true)
                //{
                //    snake3.IsBot = true;
                //    CountBots--;
                //}

                Snakes.Add(snake3);
                Matrix[Snakes[3].Coordinates[0].Y, Snakes[3].Coordinates[0].X] = 2;
                Matrix[Snakes[3].Coordinates[1].Y, Snakes[3].Coordinates[1].X] = 1;
                Matrix[Snakes[3].Coordinates[2].Y, Snakes[3].Coordinates[2].X] = 1;
                CountPlayer--;
            }

            for(var i=0; i<Snakes.Count;i++)
            {
                if (CountBots > 0 && Bots == true)
                {
                    Snakes[Snakes.Count-1-i].IsBot = true;
                    CountBots--;
                }
            }

        }

        public void Update()
        {
            Parallel.For(0, Snakes.Count, i =>
            {
                if (Snakes[i].IsBot == true)
                {
                    SnakeBotCommand(Snakes[i]);
                    UpdateOne(Snakes[i]);
                }
                else
                {
                    UpdateOne(Snakes[i]);
                }
                
            });
            //for(var i=0; i<Snakes.Count; i++)
            //{               
            //   UpdateOne(Snakes[i]);             
            //}
            for(var i=0; i<Snakes.Count; i++)
            {
                if(Snakes[i].IsVita == false)
                {
                    SnakeDeath(Snakes[i]);
                }
            }
        }

        private void SnakeDeath(Snake snake)
        {
            bool IsBot = snake.IsBot;
            for(var i=0; i<snake.lenght; i++)
            {
                Matrix[snake.Coordinates[i].Y, snake.Coordinates[i].X] = 0;
            }           
            Task.Run(()=> snake.Start(IsBot));
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
                        if (Matrix[coordHead.Y, coordHead.X] == 1)
                        {
                            snake.IsVita = false;
                            //SnakeDeath(snake);                                                     
                        }   
                        break;
                    case 1:
                        coordHead.X++;
                        if (Matrix[coordHead.Y, coordHead.X] == 1)
                        {
                            snake.IsVita = false;
                            //SnakeDeath(snake);
                        }
                        break;
                    case 2:
                        coordHead.Y++;
                        if (Matrix[coordHead.Y, coordHead.X] == 1)
                        {
                            snake.IsVita = false;
                            //SnakeDeath(snake);
                        }
                        break;
                    case 3:
                        coordHead.X--;
                        if (Matrix[coordHead.Y, coordHead.X] == 1)
                        {
                            snake.IsVita = false;
                            //SnakeDeath(snake);
                        }
                        break;
                }
                // направление движения змеи: 0 - вверх, 1 - вправо, 2 - вниз, 3 - влево                
                try
                {
                    if (Matrix[coordHead.Y, coordHead.X] == 3)
                    {
                        snake.Grow(coordHead);
                        Matrix[coordHead.Y, coordHead.X] = 1;
                        Random R = new Random();
                        Food = new Food(new Coordinate(R.Next(2, 49), R.Next(2, 49)), System.Drawing.Color.Red);
                        Matrix[Food.Coordinate.Y, Food.Coordinate.X] = 3;
                        snake.IsEmptyWay = true;
                    }

                    if (Matrix[coordHead.Y, coordHead.X] == 0)
                    {
                        Matrix[snake.Coordinates[snake.Coordinates.Count - 1].Y, snake.Coordinates[snake.Coordinates.Count - 1].X] = 0;
                        snake.Move(coordHead);
                        Matrix[coordHead.Y, coordHead.X] = 1;
                        snake.IsEmptyWay = true;
                    }
                }
                catch { }
            }
        }


        public void SnakeBotCommand(Snake snake)
        {
            
           
            List<int> Ways = new List<int>();
            List<double> distances = new List<double>() ;
            Random R = new Random();
            int Way; 
            
            var distanceX = (snake.Coordinates[0].X - Food.Coordinate.X);
            var distanceY = (snake.Coordinates[0].Y - Food.Coordinate.Y );
            var distance0 = Math.Sqrt(Convert.ToDouble((distanceX)  * (distanceX) + (distanceY-1) * (distanceY-1)));
            var distance1 = Math.Sqrt(Convert.ToDouble((distanceX+1) * (distanceX+1) + (distanceY) * (distanceY)));
            var distance2 = Math.Sqrt(Convert.ToDouble((distanceX) * (distanceX) + (distanceY+1) * (distanceY+1)));
            var distance3 = Math.Sqrt(Convert.ToDouble((distanceX-1) * (distanceX-1) + (distanceY) * (distanceY)));

            distances.Add(distance0);
            distances.Add(distance1);
            distances.Add(distance2);
            distances.Add(distance3);
            // направление движения змеи: 0 - вверх, 1 - вправо, 2 - вниз, 3 - влево  
            var min = distances.Min();
            var ti = distances.FindIndex(C=>C==min);
            
            if (Matrix[snake.Coordinates[0].Y+1, snake.Coordinates[0].X] != 1)
            {
                Ways.Add(2);
            }
            if (Matrix[snake.Coordinates[0].Y, snake.Coordinates[0].X+1] != 1)
            {
               Ways.Add(1);
            }
            if (Matrix[snake.Coordinates[0].Y - 1, snake.Coordinates[0].X] != 1)
            {
               Ways.Add(0);
            }
            if (Matrix[snake.Coordinates[0].Y, snake.Coordinates[0].X - 1] != 1)
            {
                Ways.Add(3);
            }

            if (ti == Ways.Find(C => C == ti))
            {
                Way = ti;
                if (snake.Way == 0 && ti == 2)
                {
                    snake.Way = Way = Ways[R.Next(0, Ways.Count)];
                }
                if (snake.Way == 1 && ti == 3)
                {
                    snake.Way = Way = Ways[R.Next(0, Ways.Count)];
                }
                if (snake.Way == 3 && ti == 1)
                {
                    snake.Way = Way = Ways[R.Next(0, Ways.Count)];
                }
                if (snake.Way == 2 && ti == 0)
                {
                    snake.Way = Way = Ways[R.Next(0, Ways.Count)];
                }

            }
            else
            {
                try
                {

                    Way = Ways[R.Next(0, Ways.Count)];
                }
                catch
                {
                    Way = 0;
                }
            }
            
           
            switch (Way)
            {
                case 0:
                    if (snake.Way != 2)
                    {
                        snake.Way = 0;
                    }
                    break;
                case 1:
                    if (snake.Way != 3)
                    {
                        snake.Way = 1;
                    }
                    break;
                case 2:
                    if (snake.Way != 0)
                    {
                        snake.Way = 2;
                    }
                    break;
                case 3:
                    if (snake.Way != 1)
                    {
                        snake.Way = 3;
                    }
                break;

            }

            }
    }
}

