using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace CommunityApp_PRG_Project_.UserManagement
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Username: {Username}, Password: {Password}");
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
                SaveUserToFile(username, password);
                return (username, password);
            }
            else
            {
                Console.WriteLine("Passwords don't match, ensure you input the same password.");
                goto passrepeat;
            }
        }

        private static void SaveUserToFile(string username, string password)
        {
            using (StreamWriter sw = new StreamWriter("login.txt", true)) // Append mode
            {
                sw.WriteLine(username);
                sw.WriteLine(password);
            }
        }

        public static (string, string) Login(List<User> people)
        {
            // Load users from the file
            List<User> usersFromFile = LoadUsersFromFile();
            if (usersFromFile != null)
            {
                people.AddRange(usersFromFile);
            }

            Console.WriteLine("===== Login =====");

        redo_user:
            Console.Write("Enter your username: ");
            string username_check = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password_check = Console.ReadLine();

            User foundUser = people.FirstOrDefault(user => user.Username == username_check);

            if (foundUser != null && foundUser.Password == password_check)
            {
                Console.Clear();
                Console.WriteLine("******** Login Successful ********");
                Thread.Sleep(2000);
                Console.Clear();
                return (username_check, password_check);
            }
            else
            {
                Console.WriteLine("Incorrect username or password, ensure you input the correct details.");
                goto redo_user;
            }
        }

        private static List<User> LoadUsersFromFile()
        {
            List<User> users = new List<User>();

            if (File.Exists("login.txt"))
            {
                using (StreamReader sr = new StreamReader("login.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string username = sr.ReadLine();
                        string password = sr.ReadLine();
                        if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                        {
                            users.Add(new User(username, password));
                        }
                    }
                }
            }
            return users;
        }
    }
}
