using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public void AddRSVP(string username)
        {
            if (!RSVPs.Contains(username))
            {
                RSVPs.Add(username);
                Console.WriteLine($"{username} has RSVPed for {EventName}.");
            }
            else
            {
                Console.WriteLine($"{username} has already RSVPed for {EventName}.");
            }
        }

        public TimeSpan GetTimeUntilEvent()
        {
            return EventDate - DateTime.Now;
        }
    }
}
