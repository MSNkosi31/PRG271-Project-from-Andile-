using CommunityApp_PRG_Project_.EventManagement;
using CommunityApp_PRG_Project_.GroupChat;
using CommunityApp_PRG_Project_.UserManagement;
using System;
using System.Collections.Generic;
using System.Threading;



namespace CommunityApp_PRG_Project_
{
    internal class Program
    {
        enum MainMenu
        {
            Events = 1,
            Neighbourhood_Watch,
            Job_Finder,
            Group_Chat,
            Profile_Management,
            Exit
        }

        enum UserMenu
        {
            View_profile_details = 1,
            Change_password,
            Change_username,
        }

        static void UserManage()
        {
            Console.WriteLine("===== Profile Management =====");

            Console.WriteLine("To select an option below, type in the corresponding number provided");

            foreach (UserMenu MenuOption in Enum.GetValues(typeof(UserMenu)))
            {
                string[] splitName = MenuOption.ToString().Split('_');

                string formattedName = string.Join(" ", splitName);

                Console.WriteLine("To {0} function, press {1}", formattedName, (int)MenuOption);
            }
            Console.ReadLine();
        }
        static void Menu(EventManager eventManager)
        {

            Console.WriteLine("===== Main Menu =====");
            Console.WriteLine("To select an option below, type in the corresponding number provided");


            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;

            // Display ASCII art at the start
            DisplayAsciiArt();
            Console.WriteLine("=====================================");
            Console.WriteLine("Main Menu\nTo select an option below, type in the corresponding number provided");
            Console.WriteLine("-------------------------------------");

            foreach (MainMenu MenuOption in Enum.GetValues(typeof(MainMenu)))
            {
                string[] splitName = MenuOption.ToString().Split('_');

                string formattedName = string.Join(" ", splitName);

                Console.WriteLine("To access the {0} function, press {1}", formattedName, (int)MenuOption);
            }

            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        eventManager.EventMenu();
                        break;

                    case 2:
                        Console.WriteLine("Neighbourhood Watch not yet implemented.");
                        break;

                    case 3:
                        Console.WriteLine("Job Finder not yet implemented.");
                        break;

                    case 4:
                        StartGroupChat(); // Call method to start group chat
                        break;

                    case 5:
                        UserManage();
                        return;

                    case 6:
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
            Menu(eventManager);
        }

        static void StartGroupChat()
        {
            // Initialize the group chat
            HierarchicalGroupChat groupChat = new HierarchicalGroupChat();
            groupChat.AddGroup("City Group"); // Example group
            groupChat.StartChat(); // Start the group chat
        }
        static void SignUp()
        {
            User newUser = new User();
            newUser.UserSignUp();
        }

        static void Login()
        {
            User user = new User();
            user.UserLogin();
        }





        static void DisplayAsciiArt()
        {
            Console.WriteLine(@"
    __  ___         ______                                      _ __       
   /  |/  /_  __   / ____/___  ____ ___  ____ ___  __  ______  (_) /___  __
  / /|_/ / / / /  / /   / __ \/ __ `__ \/ __ `__ \/ / / / __ \/ / __/ / / /
 / /  / / /_/ /  / /___/ /_/ / / / / / / / / / / / /_/ / / / / / /_/ /_/ / 
/_/  /_/\__, /   \____/\____/_/ /_/ /_/_/ /_/ /_/\__,_/_/ /_/_/\__/\__, /  
       /____/                                                     /____/   ");

        }

        static void Main(string[] args)
        {
            DisplayAsciiArt();
            Console.WriteLine("Welcome to My Community App");
            Console.WriteLine("To sign in press 1 and to login press 2");

        login:
            string choice = Console.ReadLine();
            bool isCorrect = int.TryParse(choice, out int result);

            if (isCorrect)
            {
                switch (result)
                {
                    case 1:
                        SignUp();
                        break;
                    case 2:
                        Login();
                        break;
                    default:
                        Console.WriteLine("Select an option between 1 and 2");
                        goto login;
                }
            }
            else
            {
                Console.WriteLine("Incorrect input, utilize numbers e.g'1,2,3,4,5");
                goto login;
            }





            // Initialize EventManager with EventCalendar
            EventCalendar calendar = new EventCalendar();
            calendar.LoadEventsFromFile();  // Load events from file
            calendar.LoadRSVPsFromFile();   // Load RSVPs from file
            EventManager eventManager = new EventManager(calendar);

            // Subscribe to the EventAdded event
            eventManager.EventAdded += OnEventAdded;

            // Start the main menu loop
            Menu(eventManager);
        }

        static void OnEventAdded(Event newEvent)
        {
            // Example action when a new event is added
            Console.WriteLine($"[Notification] New event added: {newEvent.EventName} on {newEvent.EventDate}");
        }
    }
}
