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
            Profile_Management,
            Exit
        }

        enum UserMenu
        {
            View_profile_details = 1,
            Change_password,
            Change_username,
            Back_to_menu,
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
            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
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
                        return;
                }
            }
        }
                static void Menu(EventManager eventManager)
                {
                    // Set the console text color to green
                    Console.ForegroundColor = ConsoleColor.Green;
                    DisplayAsciiArt();

                    Console.WriteLine("===== Main Menu =====");
                    Console.WriteLine("To select an option below, type in the corresponding number provided");

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
                                UserManage(eventManager);
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

                static (string, string) SignUp()
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
                            LoggedIn loggeduser = new LoggedIn();
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
                dumdum:
                    string choice = Console.ReadLine();
                    bool isCorrect = int.TryParse(choice, out int result);

                    if (isCorrect)
                    {
                        switch (result)
                        {
                            case 1:
                                var SignedUser = SignUp();

                                User newUser = new User(SignedUser.Item1, SignedUser.Item2);
                                people.Add(newUser);

                                Console.Clear();
                                //foreach (User user in people)
                                //{
                                //    Console.WriteLine("Username: " + user.Username);
                                //    Console.WriteLine("Password: " + user.Password);
                                //    Console.WriteLine(); // Adding a blank line for readability
                                //}
                                //Console.WriteLine(newUser.Username+" "+newUser.Password);
                                Console.WriteLine("******** Sign Up Successful ********");
                                Thread.Sleep(2000);
                                Console.Clear();

                                Login(people);
                                break;
                            case 2:
                                //Console.WriteLine(newUser.Username+" "+newUser.Password);
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
