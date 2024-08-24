using System;
using System.Collections.Generic;
using System.Linq;

namespace CommunityApp_PRG_Project_.EventManagement
{
    public class EventCalendar
    {
        // This property is already defined correctly
        public List<Event> Events { get; private set; } = new List<Event>();

        public void AddEvent(Event newEvent)
        {
            Events.Add(newEvent);  // Use the Events property instead of events
            Console.WriteLine($"Event '{newEvent.EventName}' added for {newEvent.EventDate}.");
        }

        public void RemoveEvent(string eventName)
        {
            var eventToRemove = Events.FirstOrDefault(e => e.EventName == eventName);  // Use the Events property instead of events
            if (eventToRemove != null)
            {
                Events.Remove(eventToRemove);  // Use the Events property instead of events
                Console.WriteLine($"Event '{eventName}' removed.");
            }
            else
            {
                Console.WriteLine($"Event '{eventName}' not found.");
            }
        }

        public Event GetEvent(string eventName)
        {
            return Events.FirstOrDefault(e => e.EventName == eventName);  // Use the Events property instead of events
        }

        public void ListEvents()
        {
            if (Events.Count == 0)  // Use the Events property instead of events
            {
                Console.WriteLine("No upcoming events.");
                return;
            }

            foreach (var e in Events)  // Use the Events property instead of events
            {
                var timeUntilEvent = e.GetTimeUntilEvent();
                Console.WriteLine($"{e.EventName} - {e.EventDate} ({timeUntilEvent.Days} days, {timeUntilEvent.Hours} hours remaining)");
            }
        }
    }
}
