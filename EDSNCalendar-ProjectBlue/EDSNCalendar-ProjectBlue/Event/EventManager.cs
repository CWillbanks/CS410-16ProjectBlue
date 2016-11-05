using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDSNCalendar_ProjectBlue.Event
{
    /// <summary>
    /// The EventManager is a static class that handles all functionality 
    /// of events that exist in the calendar system.
    /// </summary>
    public static class EventManager
    {

        /// <summary>
        /// Collection of events that are ready to be reviewed by an administrator.
        /// </summary>
        private static List<Event> submittedEvents = new List<Event>();

        public static List<Event> SubmittedEvents
        {
            get
            {
                return submittedEvents;
            }
        }

        /// <summary>
        /// Collection of events that are ready to be reviewed by an administrator.
        /// </summary>
        private static List<Event> publishedEvents = new List<Event>();

        public static List<Event> PublishedEvents
        {
            get
            {
                return publishedEvents;
            }
        }

        static EventManager()
        {
            /// TODO: Query through the database and populate all submitted/published events to their appropriate collection.
        }

    }
}