using System;
using System.Collections.Generic;

namespace CommunityApp_PRG_Project_.EventManagement
{
    public class EventManager
    {
        private EventCalendar eventCalendar;

        // Define a delegate for event added notification
        public delegate void EventAddedHandler(Event newEvent);

        // Define an event based on the delegate
        public event EventAddedHandler EventAdded;

        public EventManager(EventCalendar calendar)
        {
            eventCalendar = calendar;
        }

        public void EventMenu()
        {
            Console.WriteLine("\n===== Event Management =====");
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

                // Trigger the EventAdded event
                OnEventAdded(newEvent);
            }
            else
            {
                Console.WriteLine("Invalid date and time format.");
            }
        }

        private void RSVPToEvent()
        {
            Console.Write("Enter the name of the event you want to RSVP to: ");
            string eventName = Console.ReadLine();
            Event selectedEvent = eventCalendar.GetEvent(eventName);

            if (selectedEvent != null)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                selectedEvent.AddRSVP(username);
            }
            else
            {
                Console.WriteLine("Event not found.");
            }
        }

        protected virtual void OnEventAdded(Event newEvent)
        {
            // Check if there are any subscribers
            if (EventAdded != null)
            {
                EventAdded.Invoke(newEvent);
            }
        }
    }
}
