using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp_PRG_Project_
{
    internal class Program
    {
        enum MainMenu
        {
            UserManagement = 1,
            Events,
            Neighbourhood_Watch,
            Job_Finder,
            Exit

        }
        static void Menu()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("Menu Main\nTo select an option below, type in the corrsponding number provided");
            Console.WriteLine("-------------------------------------");
            foreach (MainMenu MenuOption in Enum.GetValues(typeof(MainMenu)))
            {
                Console.WriteLine("To access the {0} function, press {1}", MenuOption.ToString(), (int)MenuOption);
            }

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine();
                    break;

                case 3:
                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine("Exiting...");
                    break;
            }
        }

        static void SignUp()
        {
            Console.Write("Create a username:");
            string username = Console.ReadLine();

        passrepeat:
            Console.Write("Create password: "); string precheck_password = Console.ReadLine();
            Console.Write("Repeat your password: "); string repeat_password = Console.ReadLine();
            if (precheck_password == repeat_password)
            {
                string password = precheck_password;

                
                Console.WriteLine("********SignUp Successful********");
                Menu();
            }
            else
            {
                Console.WriteLine("Passwords don't match, ensure you input the same password");
                goto passrepeat;
            }

        }

        static void Login()
        {


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Retardville's Community App");
            Console.WriteLine("To sign in press 1 and to login press 2");
        dumdum:
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    SignUp();
                    break;
                case 2:
                    Login();
                    break;
                default:
                    Console.WriteLine("Select an option between 1 and 2");
                    goto dumdum;
            }
            Console.ReadLine();
        }
    }
}
