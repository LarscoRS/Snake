using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeLib;
using System.Collections.Generic;
using System.Threading;
namespace ServerSnake
{
    public partial class FormMain : Form
    {

        Dispath dispath;      
        private IDisposable SignalR { set; get; }
        public List<User> Users;
        public int CountPlayer=-1;
        Map map;
       

        public FormMain()
        {
            InitializeComponent();
            dispath = Dispath.MyInstance;            
            map = new Map();
            Users = new List<User>();            
            dispath.StartGame();
        }

        private void Dispath_MapTick(Map map)
        {
            throw new NotImplementedException();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            Task.Run(() => StartServer());
        }


        private void StartServer()
        {
            StartOptions so = new StartOptions();
            try
            {
                so.ServerFactory = "Microsoft.Owin.Host.HttpListener";
                string UrlConnect = "http://localhost:55555/signalr";
                // so.Urls.Add("http://192.168.1.140:55555/signalr");
                // so.Urls.Add("http://spimex24.ru:55555/signalr");
                so.Urls.Add(UrlConnect);
                SignalR = WebApp.Start(so);
                this.Invoke((Action)(() => buttonStart.Enabled = false));
                WriteToConsole("Server is started "+ UrlConnect);
                return;
            }
            catch(TargetInvocationException)
            {
                this.Invoke((Action)(() => buttonStart.Enabled = true));
                MessageBox.Show("Server start fail");
                return;
            }
           
        }

        //вывод логов
        internal void WriteToConsole(string Message)
        {
            if(richTextBox1.InvokeRequired)
            {
                this.Invoke((Action)(() => WriteToConsole(Message)));
                return;
            }
            richTextBox1.AppendText(Message + Environment.NewLine);
        }


    }


    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            HubConfiguration cnf = new HubConfiguration();
            app.MapSignalR();
        }
    }
    public static class Flag
    {
        public static bool flag;
    }
    public class SnakeHub : Hub
    {

        Dispath dispath; //= Dispath.MyInstance;
      
        public void iamStarted()
        {
            dispath = Dispath.MyInstance;
            dispath.map.createSnake();         
            dispath.MotorTick += Dispath_MotorTick; 
            
        }

        private void Dispath_MotorTick()
        {            
            Random R = new Random();            
            Clients.All.GameTick(dispath.map.Snakes, dispath.map.Food);
        }

        

      

        public override Task OnConnected()
        {
            User _user = Program.FormMain.Users.Find(C=>C.Name== Context.QueryString["Name"]);
            if (_user == null)
            {
                User user = new User();
                user.Name = Context.QueryString["Name"];
                user.ConnectionID = Context.ConnectionId;
                Program.FormMain.Users.Add(user);

                Program.FormMain.WriteToConsole(user.Name +" " + user.ConnectionID);
                Clients.Others.NewMessage(DateTime.Now.ToString() + " подключился:" + Context.QueryString["Name"]);
              
            }
            else
            {
                Program.FormMain.WriteToConsole("не удалось подключить "+ Context.QueryString["Name"] + " " + Context.ConnectionId);
                Clients.Caller.NewMessage(DateTime.Now.ToString() + "Пользователь уже существует:" + Context.QueryString["Name"]);
                Clients.Caller.Off();
            }
                        
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Program.FormMain.WriteToConsole("OnDisconnected " + Context.ConnectionId);           
            User _user = Program.FormMain.Users.Find(C => C.ConnectionID == Context.ConnectionId);
            Program.FormMain.Users.Remove(_user);
            return base.OnDisconnected(stopCalled);
        }
        
        
        public void SendMessage(string mes)
        {
            Clients.All.NewMessage(mes);
        }

        public void SendWay(int Way)
        {
            var userIndex = Program.FormMain.Users.FindIndex(C => C.ConnectionID == Context.ConnectionId);
            dispath = Dispath.MyInstance;
            dispath.pressWay(userIndex, Way);
            //Clients.All.NewMessage(userIndex +" "+Way.ToString());
        }

        public void SendMap(Map map)
        {
            Clients.All.NewMap(map);
        }

        public void FindGame(string mes)
        {
            Clients.All.NewMessage(mes);
        }


        public void SearchGame()
        {
            var user = Program.FormMain.Users.Find(C => C.ConnectionID == Context.ConnectionId);
            
            Program.FormMain.CountPlayer++;
            if (Program.FormMain.CountPlayer == 3)
            {
                Clients.All.NewMessage("До начала игры 3");
                Thread.Sleep(1000);
                Clients.All.NewMessage("До начала игры 2");
                Thread.Sleep(1000);
                Clients.All.NewMessage("До начала игры 1");
                Thread.Sleep(1000);
                Clients.All.NewMessage("До начала игры 0");
                iamStarted();
            }
        }
    }


}
