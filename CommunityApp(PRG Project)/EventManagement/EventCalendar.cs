using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommunityApp_PRG_Project_.EventManagement
{
    public class EventCalendar
    {
        // This property is already defined correctly
        public List<Event> Events { get; private set; } = new List<Event>();

        public void AddEvent(Event newEvent)
        {
            Events.Add(newEvent);  // Use the Events property
            Console.WriteLine($"Event '{newEvent.EventName}' added for {newEvent.EventDate}.");
        }

        public void RemoveEvent(string eventName)
        {
            var eventToRemove = Events.FirstOrDefault(e => e.EventName == eventName);
            if (eventToRemove != null)
            {
                Events.Remove(eventToRemove);
                Console.WriteLine($"Event '{eventName}' removed.");
            }
            else
            {
                Console.WriteLine($"Event '{eventName}' not found.");
            }
        }

        public Event GetEvent(string eventName)
        {
            return Events.FirstOrDefault(e => e.EventName == eventName);
        }

        public void ListEvents()
        {
            if (Events.Count == 0)
            {
                Console.WriteLine("No upcoming events.");
                return;
            }

            foreach (var e in Events)
            {
                var timeUntilEvent = e.GetTimeUntilEvent();
                Console.WriteLine($"{e.EventName} - {e.EventDate} ({timeUntilEvent.Days} days, {timeUntilEvent.Hours} hours remaining)");
            }
        }

        public void LoadEventsFromFile()
        {
            if (File.Exists("events.txt"))
            {
                string[] lines = File.ReadAllLines("events.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { ", " }, StringSplitOptions.None);
                    var eventName = parts[0].Replace("Event: ", "");
                    var eventDate = DateTime.Parse(parts[1].Replace("Date: ", ""));

                    Events.Add(new Event(eventName, eventDate));
                }
            }
        }

        public void LoadRSVPsFromFile()
        {
            if (File.Exists("rsvps.txt"))
            {
                string[] lines = File.ReadAllLines("rsvps.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { ", " }, StringSplitOptions.None);
                    var eventName = parts[0].Replace("Event: ", "");
                    var rsvpName = parts[1].Replace("RSVP: ", "");

                    var existingEvent = GetEvent(eventName);
                    if (existingEvent != null)
                    {
                        existingEvent.RSVPs.Add(rsvpName);
                    }
                }
            }
        }
    }
}
