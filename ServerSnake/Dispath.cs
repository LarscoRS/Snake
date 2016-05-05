using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using SnakeLib;

namespace ServerSnake
{
    public class Dispath
    {
        #region Constructors
        static readonly Dispath myInstance = new Dispath();
        static Dispath() { }
        Dispath() { }

        public static Dispath MyInstance
        {
            get
            {
                return myInstance;
            }
        }
        #endregion
   

        public Map map;
        public int time=0;

        Timer Motor = new Timer();
        public delegate void MapTickDelegate();
        public event MapTickDelegate MotorTick;

        public void StartGame()
        {
            map  = new Map(51, 51);
       
            if (Motor.Enabled==false)
            {
                Motor.Enabled = true;
                Motor.Interval = 200;
                Motor.Elapsed += Motor_Elapsed;
                Motor.Start();
                
            }          
        }             

        private void Motor_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (MotorTick != null)
            {
                Motor.Enabled = false;
                map.Update();
                MotorTick();
                Motor.Enabled = true;
                time++;
            }
            if (time == 600)
            {
                Motor.Stop();
                map.Snakes.RemoveRange(0, map.Snakes.Count);                
            }
        }               

        public void pressWay(int userIndex, int Way)
        {
            map.Snakes[userIndex].Way = Way;
        }     
    }
}
