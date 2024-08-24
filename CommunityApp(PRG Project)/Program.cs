using CommunityApp_PRG_Project_.EventManagement;
using CommunityApp_PRG_Project_.GroupChat;
using CommunityApp_PRG_Project_.UserManagement;
using System;


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
            Group_Chat,
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
                        StartGroupChat(); // Call method to start group chat
                        break;

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
            Menu(eventManager); // Re-display the menu after an action
        }

        static void StartGroupChat()
        {
            // Initialize the group chat
            HierarchicalGroupChat groupChat = new HierarchicalGroupChat();
            groupChat.AddGroup("City Group"); // Example group
            groupChat.StartChat(); // Start the group chat
        }

        static void SignUp()
        static void SignUp(List<User>people)
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
                new User(username, password);
                Console.WriteLine("********SignUp Successful********");
                Login(people);
            }
            else
            {
                Console.WriteLine("Passwords don't match, ensure you input the same password");
                goto passrepeat;
            }
        }

        public static void Login(List<User> people)
        {
            Console.WriteLine("Login not yet implemented.");
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
            redo_user:
            Console.Write("Enter your username: "); string username_check = Console.ReadLine();

            redo_pass:
            Console.Write("Enter your password: "); string password_check = Console.ReadLine();

            //// Create a new List to store names
            List<string> names = new List<string>();
            List<string> passwords = new List<string>();

            //// Populate the list with names from Person objects
            foreach (User person in people)
            {
                names.Add(person.Username);
            }

            foreach (User person in people)
            {
                passwords.Add(person.Password);
            }

            if (names.Contains(username_check))
            {
                Console.WriteLine("Username found");
                if (passwords.Contains(password_check))
                {
                    Console.WriteLine("Password correct");
                }
                else
                {
                    Console.WriteLine("Incorrect password, ensure you input the correct password");
                    goto redo_pass;
                }
               
            }
            else
            {
                Console.WriteLine("Username does not exist, ensure you input the correct username");
                goto redo_user;
            }
        }

        //// Print the list contents
        //foreach (string name in names)
        //{
        //    Console.WriteLine(name);
        //}


        static void Main(string[] args)
        {

            List<User> people = new List<User>
        {
            new User("Tumi", "adminT"),
            new User("Andile", "adminA"),
            new User("Suhil", "adminS"),
            new User("Reinhard", "adminR")
        };
            Console.WriteLine("Welcome to Retardville's Community App");
            Console.WriteLine("To sign in press 1 and to login press 2");
        dumdum:
            string choice = Console.ReadLine();
            bool isCorrect = int.TryParse(choice, out int result);

            if (isCorrect)
            {
                switch (result)
                {
                    case 1:
                        SignUp(people);
                        break;
                    case 2:
                        Login(people);
                        break;
                    default:
                        Console.WriteLine("Select an option between 1 and 2");
                        goto dumdum;
                }
            }
            else 
            {
                Console.WriteLine("Incorrect input, utilize numbers e.g'1,2,3,4,5");
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
