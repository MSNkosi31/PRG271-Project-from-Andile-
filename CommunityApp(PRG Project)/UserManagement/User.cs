using System;
using System.Collections.Generic;
using System.IO;
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

        public void UserSignUp()
        {
            Console.WriteLine("Create a username: ");
            username = Console.ReadLine();
            Console.WriteLine("Create a password: ");
            password = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(File.Create("login.txt")))
            {
                sw.WriteLine(username);
                sw.WriteLine(password);
                sw.Close();
            }

            Console.WriteLine("Welcome.....");
            Console.Read();
        }

        public void UserLogin()
        {
            Console.WriteLine("Enter username: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            password = Console.ReadLine();

            using (StreamReader sr = new StreamReader(File.Open("login.txt", FileMode.Open)))
            {
                username = sr.ReadLine();
                password = sr.ReadLine();
                sr.Close();
            }

            if (username != null && password != null)
            {
                Console.WriteLine("Login succeful");
            }
            else
            {
                Console.WriteLine("Login Failed");
            }

            Console.Read();
        }
    }
}


