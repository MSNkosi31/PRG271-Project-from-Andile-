﻿using System;
using CommunityApp_PRG_Project_.EventManagement; // Import the EventManagement namespace

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

        static void Menu(EventManager eventManager)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("Main Menu\nTo select an option below, type in the corresponding number provided");
            Console.WriteLine("-------------------------------------");
            foreach (MainMenu MenuOption in Enum.GetValues(typeof(MainMenu)))
            {
                Console.WriteLine("To access the {0} function, press {1}", MenuOption.ToString(), (int)MenuOption);
            }

            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        Console.WriteLine("User Management not yet implemented.");
                        break;

                    case 2:
                        eventManager.EventMenu();
                        break;

                    case 3:
                        Console.WriteLine("Neighbourhood Watch not yet implemented.");
                        break;

                    case 4:
                        Console.WriteLine("Job Finder not yet implemented.");
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
            Menu(eventManager); // Re-display the menu after an action
        }

        static void SignUp()
        {
            Console.Write("Create a username:");
            string username = Console.ReadLine();

        passrepeat:
            Console.Write("Create password: ");
            string precheck_password = Console.ReadLine();
            Console.Write("Repeat your password: ");
            string repeat_password = Console.ReadLine();
            if (precheck_password == repeat_password)
            {
                string password = precheck_password;
                Console.WriteLine("********SignUp Successful********");
            }
            else
            {
                Console.WriteLine("Passwords don't match, ensure you input the same password");
                goto passrepeat;
            }
        }

        static void Login()
        {
            Console.WriteLine("Login not yet implemented.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Retardville's Community App");
            Console.WriteLine("To sign in press 1 and to login press 2");
        dumdum:
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
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
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
                goto dumdum;
            }

            // Initialize EventManager with EventCalendar
            EventCalendar calendar = new EventCalendar();
            EventManager eventManager = new EventManager(calendar);

            // Start the main menu loop
            Menu(eventManager);
        }
    }
}
