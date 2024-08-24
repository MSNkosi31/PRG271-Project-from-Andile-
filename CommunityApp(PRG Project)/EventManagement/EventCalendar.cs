using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp_PRG_Project_.EventManagement
{
    public class EventCalendar
    {
        private List<Event> events = new List<Event>();

        public void AddEvent(Event newEvent)
        {
            events.Add(newEvent);
            Console.WriteLine($"Event '{newEvent.EventName}' added for {newEvent.EventDate}.");
        }

        public void RemoveEvent(string eventName)
        {
            var eventToRemove = events.FirstOrDefault(e => e.EventName == eventName);
            if (eventToRemove != null)
            {
                events.Remove(eventToRemove);
                Console.WriteLine($"Event '{eventName}' removed.");
            }
            else
            {
                Console.WriteLine($"Event '{eventName}' not found.");
            }
        }

        public Event GetEvent(string eventName)
        {
            return events.FirstOrDefault(e => e.EventName == eventName);
        }

        public void ListEvents()
        {
            if (events.Count == 0)
            {
                Console.WriteLine("No upcoming events.");
                return;
            }

            foreach (var e in events)
            {
                var timeUntilEvent = e.GetTimeUntilEvent();
                Console.WriteLine($"{e.EventName} - {e.EventDate} ({timeUntilEvent.Days} days, {timeUntilEvent.Hours} hours remaining)");
            }
        }
    }
}
