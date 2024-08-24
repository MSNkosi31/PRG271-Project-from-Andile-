using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp_PRG_Project_.EventManagement
{
    public class EventManager
    {
        private EventCalendar eventCalendar;

        public EventManager(EventCalendar calendar)
        {
            eventCalendar = calendar;
        }

        public void EventMenu()
        {
            Console.WriteLine("===== Event Management =====");
            Console.WriteLine("1. Create Event");
            Console.WriteLine("2. List Events");
            Console.WriteLine("3. RSVP to Event");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Choose an option: ");

            int eventOption;
            if (int.TryParse(Console.ReadLine(), out eventOption))
            {
                switch (eventOption)
                {
                    case 1:
                        CreateEvent();
                        break;

                    case 2:
                        eventCalendar.ListEvents();
                        break;

                    case 3:
                        RSVPToEvent();
                        break;

                    case 4:
                        return;  // Go back to the main menu
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }

            // Loop back to the event menu
            EventMenu();
        }

        private void CreateEvent()
        {
            Console.Write("Enter event name: ");
            string eventName = Console.ReadLine();

            Console.Write("Enter event date and time (yyyy-mm-dd hh:mm): ");
            DateTime eventDate;
            if (DateTime.TryParse(Console.ReadLine(), out eventDate))
            {
                Event newEvent = new Event(eventName, eventDate);
                eventCalendar.AddEvent(newEvent);
            }
            else
            {
                Console.WriteLine("Invalid date and time format.");
            }
        }

        private void RSVPToEvent()
        {
            if (eventCalendar.Events.Count == 0)
            {
                Console.WriteLine("No events available to RSVP.");
                return;
            }

            Console.WriteLine("Available Events:");
            for (int i = 0; i < eventCalendar.Events.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {eventCalendar.Events[i].EventName} - {eventCalendar.Events[i].EventDate}");
            }

            Console.Write("Enter the number of the event you want to RSVP to: ");
            int eventChoice;
            if (int.TryParse(Console.ReadLine(), out eventChoice) && eventChoice > 0 && eventChoice <= eventCalendar.Events.Count)
            {
                Event selectedEvent = eventCalendar.Events[eventChoice - 1];
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                selectedEvent.AddRSVP(username);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
