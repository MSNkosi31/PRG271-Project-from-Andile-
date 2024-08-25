using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp_PRG_Project_.UserManagement
{
    public class User:IMethods
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

        public void ShowDetails()
        { 
            
        }
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


        public static void UserManage()
        {
            Console.WriteLine("===== Profile Management =====");

            Console.WriteLine("To select an option below, type in the corresponding number provided");

            foreach (UserMenu MenuOption in Enum.GetValues(typeof(UserMenu)))
            {
                string[] splitName = MenuOption.ToString().Replace('_', ' ');

                Console.WriteLine("To {0} function, press {1}", splitName, (int)MenuOption);
            }
            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        User.ShowDetails();
                        break;

                    case 2:
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine();
                        break;

                    case 4:
                        return;
                }
            }
        }

        public static (string,string) Login(List<User> people)
        {
            Console.WriteLine("===== Login =====");

        redo_user:
            Console.Write("Enter your username: ");
            string username_check = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password_check = Console.ReadLine();

           
            User foundUser = people.FirstOrDefault(user => user.Username == username_check);//Searching for the inputted sername from the list, creates an obj based on my User class using the username found through the search

            if (foundUser != null && foundUser.Password == password_check) //Cheacking if the found user obj is empty and if the password of the found user corrolates to the inputted password
            {
                Console.Clear();
                Console.WriteLine("******** Login Successful ********");
                Thread.Sleep(2000);
                Console.Clear();
                return (username_check, password_check);
            }
            else
            {
                Console.WriteLine("Incorrect username or password , ensure you input the correct details.");
                goto redo_pass;
                }
            }
        }
    }


