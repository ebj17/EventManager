using System.Collections.Generic;
using System.Linq;

namespace MyEvents
{
    public class EventManager
    {
        private List<Event> events = new();

        public void AddEvent(Event newEvent)
        {
            events.Add(newEvent);
        }

        public Event GetEvent(string name)
        {
            return events.FirstOrDefault(e => e.Name == name);
            //FirstOrDefault -> returns first object in the List that matches the name parameter
            //(e => e.Name == name)
            //This is a lambda expression used as a predicate to filter the elements of the sequence. 
            //It checks if the Name property of each element e in the events list is equal to the provided name.
        }

        public bool CancelEvent(string name)
        {
            var evnt = GetEvent(name);
            if (evnt != null && evnt.IsActive)
            {
                evnt.Cancel();
                return true;
            }
            return false;
        }
    }
}