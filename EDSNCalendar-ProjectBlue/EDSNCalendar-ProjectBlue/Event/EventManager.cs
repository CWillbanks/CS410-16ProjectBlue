using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

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
            /// 
            publishedEvents.Clear();
            DataTable dtPublishedActiveEvents = SQLData.SQLQueries.GetAllEvents(true, true);
            foreach(DataRow publishedRow in dtPublishedActiveEvents.Rows)
            {
                int iEventId = (int)publishedRow["iEventId"];
                Event publishedEvent = new Event(iEventId);
                publishedEvents.Add(publishedEvent);
            }

            submittedEvents.Clear();
            DataTable dtSubmittedActiveEvents = SQLData.SQLQueries.GetSubmittedEvents();
            foreach(DataRow submittedRow in dtSubmittedActiveEvents.Rows)
            {
                int iEventId = (int)submittedRow["iEventId"];
                Event submittedEvent = new Event(iEventId);
                submittedEvents.Add(submittedEvent);
            }
        }

    }
}