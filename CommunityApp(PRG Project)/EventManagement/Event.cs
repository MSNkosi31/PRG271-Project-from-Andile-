using System;
using System.Collections.Generic;
using System.IO;

namespace CommunityApp_PRG_Project_.EventManagement
{
    public class Event
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public List<string> RSVPs { get; set; } = new List<string>();

        public Event(string eventName, DateTime eventDate)
        {
            EventName = eventName;
            EventDate = eventDate;
            SaveEventToFile();  // Save the event to the file when it's created
        }

        public void AddRSVP(string username)
        {
            if (!RSVPs.Contains(username))
            {
                RSVPs.Add(username);
                Console.WriteLine($"{username} has RSVPed for {EventName}.");
                SaveRSVPToFile(username);  // Save the RSVP to the file when added
            }
            else
            {
                Console.WriteLine($"{username} has already RSVPed for {EventName}.");
            }
        }

        private void SaveEventToFile()
        {
            using (StreamWriter sw = new StreamWriter("events.txt", true))
            {
                sw.WriteLine($"Event: {EventName}, Date: {EventDate}");
            }
        }

        private void SaveRSVPToFile(string username)
        {
            using (StreamWriter sw = new StreamWriter("rsvps.txt", true))
            {
                sw.WriteLine($"Event: {EventName}, RSVP: {username}");
            }
        }

        public TimeSpan GetTimeUntilEvent()
        {
            return EventDate - DateTime.Now;
        }
    }
}
