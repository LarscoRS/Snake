using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLib
{
    public class User
    {
        public string Name;
        public string ConnectionID;
        public Snake snake;

        public User(string name, string connectionID)
        {
            Name = name;
            ConnectionID = connectionID;
        }

        public User() { }
    }
}
