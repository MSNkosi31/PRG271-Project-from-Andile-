using CommunityApp_PRG_Project_.EventManagement;
using CommunityApp_PRG_Project_.GroupChat;
using CommunityApp_PRG_Project_.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Show_profile_details,
            Exit
        }

        public static void Menu(EventManager eventManager)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            DisplayAsciiArt();

            Console.WriteLine("===== Main Menu =====");
            Console.WriteLine("To select an option below, type in the corresponding number provided");

            foreach (MainMenu MenuOption in Enum.GetValues(typeof(MainMenu)))
            {
                string splitName = MenuOption.ToString().Replace('_', ' ');
                Console.WriteLine("To access the {0} function, press {1}", splitName, (int)MenuOption);
            }

            if (int.TryParse(Console.ReadLine(), out int option))
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
                        StartGroupChat();
                        break;
                    case 5:
                        User.UserManage();
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
            HierarchicalGroupChat groupChat = new HierarchicalGroupChat();
            groupChat.AddGroup("City Group");
            groupChat.StartChat();
        }

        static void DisplayAsciiArt()
        {
            Console.WriteLine(@"
    __  ___         ______                                      _ __       
   /  |/  /_  __   / ____/___  ____ ___  ____ ___  __  ______  (_) /___  __
  / /|_/ / / / /  / /   / __ \/ __ `__ \/ __ `__ \/ / / / __ \/ / __/ / / /
 / /  / / /_/ /  / /___/ /_/ / / / / / / / / / / / /_/ / / / / / /_/ /_/ / 
/_/  /_/\__, /   \____/\____/_/ /_/ /_/_/ /_/ /_/\__,_/_/ /_/_/\__/\__, /  
       /____/                                                     /____/   
 ");
        }

        static void Main(string[] args)
        {
            List<User> people = new List<User>
            {
                new User("Tumi", "adminT"),
                new User("Andile", "adminA"),
                new User("Suhil", "adminS"),
                new User("Reinhard", "adminR"),
                new User("1", "1")
            };

            Console.WriteLine("Welcome to Retardville's Community App");
            Console.WriteLine("To sign in press 1 and to login press 2");

            int result;
            string choice;
            do
            {
                choice = Console.ReadLine();
            } while (!int.TryParse(choice, out result) || (result != 1 && result != 2));

            if (result == 1)
            {
                var signedUser = User.SignUp();
                User newUser = new User(signedUser.Item1, signedUser.Item2);
                people.Add(newUser);
                Console.Clear();
                Console.WriteLine("******** Sign Up Successful ********");
                Thread.Sleep(2000);
                Console.Clear();
                Login(people);
            }
            else if (result == 2)
            {
                Login(people);
            }

            EventCalendar calendar = new EventCalendar();
            calendar.LoadEventsFromFile();
            calendar.LoadRSVPsFromFile();
            EventManager eventManager = new EventManager(calendar);

            eventManager.EventAdded += OnEventAdded;
            Menu(eventManager);
        }

        static (string, string) Login(List<User> people)
        {
            return User.Login(people);
        }

        static void OnEventAdded(Event newEvent)
        {
            Console.WriteLine($"[Notification] New event added: {newEvent.EventName} on {newEvent.EventDate}");
        }
    }
}
