using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp_PRG_Project_.UserManagement
{
    public class LoggedIn
    {
        string loggedname;

        public LoggedIn()
        {
           
        }
        public LoggedIn(string loggedname)
        {
            Loggedname = loggedname;
        }

        public string Loggedname { get => this.Loggedname; set => this.Loggedname = value; }
    }
}
