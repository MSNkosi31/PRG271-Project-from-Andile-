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

        public static (string, string) SignUp()
        {
            Console.WriteLine("===== Sign up =====");
            Console.Write("Create a username: ");
            string username = Console.ReadLine();

        passrepeat:
            Console.Write("Create password: ");
            string precheck_password = Console.ReadLine();

            Console.Write("Repeat your password: ");
            string repeat_password = Console.ReadLine();

            if (precheck_password == repeat_password)
            {
                string password = precheck_password;
                return (username, password);
            }
            else
            {
                Console.WriteLine("Passwords don't match, ensure you input the same password.");
                goto passrepeat;
            }
        }

        public static void Login(List<User> people)
        {
            Console.WriteLine("===== Login =====");

        redo_user:
            Console.Write("Enter your username: ");
            string username_check = Console.ReadLine();

        redo_pass:
            Console.Write("Enter your password: ");
            string password_check = Console.ReadLine();

            // Find the user in the list
            User foundUser = people.FirstOrDefault(user => user.Username == username_check);

            if (foundUser != null)
            {
                if (foundUser.Password == password_check)
                {
                    User loggeduser = new User();
                    loggeduser.Username = username_check;
                    loggeduser.Password = password_check;

                    Console.Clear();
                    Console.WriteLine("******** Login Successful ********");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Incorrect password, ensure you input the correct password.");
                    goto redo_pass;
                }
            }
            else
            {
                Console.WriteLine("Username does not exist, ensure you input the correct username.");
                goto redo_user;
            }
        }
    }
}


