using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp_PRG_Project_.UserManagement
{
    public class User
    {
        string username;
        string password;

        public User()
        {
            
        }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
