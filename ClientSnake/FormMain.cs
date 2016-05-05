using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR.Client;

using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using SnakeLib;
namespace ClientSnake
{
    public partial class FormMain : Form
    {
        int W = 51, H = 51, S = 10;
        int X = 0, Y = 0;
        int way = 0; // направление движения змеи: 0 - вверх, 1 - вправо, 2 - вниз, 3 - влево
       
        Map map;
        List<Snake> snakes;
        Food Food;


        public FormMain()
        {
            InitializeComponent();
            map = new Map(W,H);
      
            this.pictureBox1.Paint += new PaintEventHandler(Program_Paint);
   
            this.pictureBox1.Focus();
            this.pictureBox1.PreviewKeyDown += PictureBox1_PreviewKeyDown;

           
        }

        private void PictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Action act = () => richTextBoxChat.AppendText("Сообщение knopka:" + Environment.NewLine);
            richTextBoxChat.Invoke(act);
        }

        void Program_Paint(object sender, PaintEventArgs e)
        {
            if (snakes != null)
            {
                for (var j = 0; j < snakes.Count; j++)
                {
                    if (snakes[j].Coordinates.Count>0)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(snakes[j].Head), new Rectangle(snakes[j].Coordinates[0].X * S, snakes[j].Coordinates[0].Y * S, S, S));
                    }
                    for (var i = 1; i < snakes[j].Coordinates.Count; i++)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(snakes[j].Body), new Rectangle(snakes[j].Coordinates[i].X * S, snakes[j].Coordinates[i].Y * S, S, S));
                    }
                }              
                e.Graphics.FillEllipse(new SolidBrush(Food.Color), new Rectangle(Food.Coordinate.X * S, Food.Coordinate.Y * S, S, S));
            
              
                e.Graphics.FillRectangle(new SolidBrush(Color.Brown), new Rectangle(0 * S, 0 * S, H*S, S));
                e.Graphics.FillRectangle(new SolidBrush(Color.Brown), new Rectangle(0 * S, 0 * S, S, W*S));
                e.Graphics.FillRectangle(new SolidBrush(Color.Brown), new Rectangle((W-1) * S, 0 * S, (H-1) * S, (W - 1) * S));
                e.Graphics.FillRectangle(new SolidBrush(Color.Brown), new Rectangle(0 * S, (H-1) * S, H  * S, W*S));
            
            }
    }

        void Program_KeyDown(object sender, KeyEventArgs e)
        {
            if (Connection != null)
            {
                
                switch (e.KeyData)
                {
                    case Keys.Up:
                        if (way != 2)
                        {
                            way = 0;
                            SendWay(way);
                        }
                        break;
                    case Keys.Right:
                        if (way != 3)
                        {
                            way = 1;
                            SendWay(way);
                        }
                        break;
                    case Keys.Down:
                        if (way != 0)
                        {
                            way = 2;
                            SendWay(way);
                        }
                        break;
                    case Keys.Left:
                        if (way != 1)
                        {
                            way = 3;
                            SendWay(way);
                        }
                        break;

                }
               
            }
        }

        

        public IHubProxy HubProxy { set; get; }
        //const string ServerURI = "http://spimex24.ru:55555/signalr";
        //const string ServerURI = "http://192.168.1.140:55555/signalr";
        const string ServerURI = "http://localhost:55555/signalr";
        public HubConnection Connection { set; get; }

    
        public void ConnectAsync()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Name", textBoxName.Text);
            
            Connection = new HubConnection(ServerURI, dict);
            HubProxy = Connection.CreateHubProxy("SnakeHub");

            HubProxy.On<string>("NewMessage", (mes) =>
            {
                  Action act = () => richTextBoxChat.AppendText("Сообщение получено:" + mes+Environment.NewLine);
                  richTextBoxChat.Invoke(act);                       
            }
            );

            HubProxy.On<List<Snake>, Food>("GameTick", (r, food) =>
            {
                snakes = r;
                Food = food;
                this.pictureBox1.Invalidate();
               
            }
            );

            HubProxy.On<int, int>("AppleTick", (x, y) =>
            {
                Action act = () =>
                {
                    X = x;
                    Y = y;
                    richTextBoxChat.AppendText("apple1:" + x.ToString() + " " + y.ToString() + Environment.NewLine);
                    this.pictureBox1.Invalidate();
                };
                richTextBoxChat.Invoke(act);
            }
            );

            HubProxy.On("Off", () =>
            {
                Connection.Stop();
               // Connection.Dispose();
            }
          );

            try
            {
                Connection.Start();
               
            }
            catch(HttpRequestException)
            {

            }
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            Program_KeyDown(sender, e);
        }

        private void textBoxMes_KeyDown(object sender, KeyEventArgs e)
        {
            Program_KeyDown(sender, e);
        }

        private void richTextBoxChat_KeyDown(object sender, KeyEventArgs e)
        {
            Program_KeyDown(sender, e);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Connection!=null)
                Connection.Stop();
        }

        private void buttonSearchGame_Click(object sender, EventArgs e)
        {
            HubProxy.Invoke("SearchGame");
            buttonSearchGame.Enabled = false;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            ConnectAsync();
            buttonConnect.Enabled = false;
            buttonSend.Enabled = true;
            buttonSearchGame.Enabled = true;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            HubProxy.Invoke("SendMessage", textBoxMes.Text);         
        }

        private void SendWay(int way)
        {
            HubProxy.Invoke("SendWay", way);
        }

       
        
    }

}
