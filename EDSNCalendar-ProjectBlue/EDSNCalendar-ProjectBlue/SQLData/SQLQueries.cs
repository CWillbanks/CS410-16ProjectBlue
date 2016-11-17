using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EDSNCalendar_ProjectBlue.SQLData;
using EDSNCalendar_ProjectBlue.Event;
using System.Data;

namespace EDSNCalendar_ProjectBlue.SQLData
{
    /// <summary>
    /// A library of queries that can be run with parameters/returns similar to functions
    /// </summary>
    public static class SQLQueries
    {
        //Example Usage of SQLDataAdapter to run Queries
        public static void ExampleQuery2()
        {
            string sQuery = "INSERT INTO categories(vCategory) VALUES('Whatever')";
            SQLDataAdapter.QueryExecute(sQuery);
        }
        //Example Usage of SQLDataAdapter to run Queries
        public static DataTable ExampleQuery3()
        {
            DataTable dtAllCategories;
            dtAllCategories = SQLDataAdapter.Query4DataTable("SELECT * FROM categories");
            return dtAllCategories;
        }

        /// <summary>
        /// Creates a new submitted event in DB
        /// </summary>
        /// <param name="sEventTitle">Event Title</param>
        /// <param name="dEventDate">Date of Event</param>
        /// <param name="sStartTime">Event Start Time(optional)</param>
        /// <param name="sEndTime">Event End Time(optional)</param>
        /// <param name="bAllDay">All Day Event(optional)</param>
        /// <param name="sVenueName">Venue Name</param>
        /// <param name="sAddress">Address</param>
        /// <param name="sDescription">Description</param>
        /// <param name="sOrganizerName">Organizer's Name</param>
        /// <param name="sOrganizerEmail">Organizer's Email</param>
        /// <param name="sOrganizerPhoneNumber">Organizer's Phone Number</param>
        /// <param name="sOrganizerURL">Organizer's URL(optional)</param>
        /// <param name="sCost">Cost(optional)</param>
        /// <param name="sRegistrationURL">Registration URL(optional)</param>
        /// <param name="sSubmitterName">Submitter's Name(optional)</param>
        /// <param name="sSubmitterEmail">Submitter's Email(optional)</param>
        /// <returns></returns>
        public static int InsertSubmittedEvent(string sEventTitle, string dEventDate, string sStartTime, string sEndTime, bool bAllDay, string sVenueName, string sAddress, string sDescription, string sOrganizerName,
                                string sOrganizerEmail, string sOrganizerPhoneNumber, string sOrganizerURL, string sCost, string sRegistrationURL, string sSubmitterName, string sSubmitterEmail)
        {

            int iRowsAffected = 0; 
            string sQuery = "INSERT INTO calendarevent(vEventTitle, dEventDate, vStartTime, vEndTime, bAllDay, vVenueName, vAddress, vDescription, vOrganizerName, vOrganizerEmail, vOrganizerPhoneNumber," +
                                                                        "vOrganizerURL, vCost, vRegistrationURL, vSubmitterName, vSubmitterEmail)" +
                            "VALUES('" + sEventTitle + "','" + dEventDate + "','" + sStartTime + "','" + sEndTime + "'," + Convert.ToInt32(bAllDay) + ",'" + sVenueName + "','" + sAddress + "','" +
                                         sDescription + "','" + sOrganizerName + "','" + sOrganizerEmail + "','" + sOrganizerPhoneNumber + "','" + sOrganizerURL + "','" + sCost + "','" + sRegistrationURL + "','" + sSubmitterName + "','" + sSubmitterEmail + "')";
            iRowsAffected = SQLDataAdapter.QueryExecute(sQuery);
            return iRowsAffected;
        }

        /// <summary>
        /// Publishes an existing submitted event in DB
        /// </summary>
        /// <param name="iEventId">id# of event to publish</param>
        /// <returns>Number of rows affected, signifying if the creation was successful.</returns>
        public static int PublishEvent(int iEventId)
        {
            int iRowsAffected = 0;
            String sQuery = "UPDATE calendarevent SET bPublished = 1, dtPublishDate = NOW() WHERE iEventId = " + iEventId;
            iRowsAffected = SQLDataAdapter.QueryExecute(sQuery);
            return iRowsAffected;
        }

        /// <summary>
        /// Returns a table of events. returns all events by default but parameters can be used to get only active/published events
        /// </summary>
        /// <param name="iPublishStatus">Determines the published status of the list to be returned 0: all events, 1: Submitted only, 2: Published only</param>
        /// <param name="bActiveOnly">Determines whether only active events are returned. Default: false</param>
        /// <returns>Multi rowed table with each row holding an event's attributes.</returns>
        public static DataTable GetAllEvents(int iPublishStatus = 0, bool bActiveOnly = false)
        {
            DataTable dtEvents = new DataTable();
            string sQuery = string.Empty;
            switch(iPublishStatus)
            {
                case (0):   //All Events
                    sQuery = "SELECT * FROM calendarevent WHERE (bActive = 1 OR bActive = " + Convert.ToInt32(bActiveOnly) + ")";
                    break;
                case (1):   //Submitted Events Only
                    sQuery = "SELECT * FROM calendarevent WHERE (bActive = 1 OR bActive = " + Convert.ToInt32(bActiveOnly) + ") AND bPublished = 0";
                    break;
                case (2):   //Published Events Only
                    sQuery = "SELECT * FROM calendarevent WHERE (bActive = 1 OR bActive = " + Convert.ToInt32(bActiveOnly) + ") AND bPublished = 1";
                    break;
            }
            dtEvents = SQLDataAdapter.Query4DataTable(sQuery);
            return dtEvents;
        }

        public static List<Event.Event> getAllEventsList(int iPublishStatus = 0, bool bActiveOnly = false)
        {
            DataTable dtEvents = new DataTable();
            string sQuery = string.Empty;
            switch (iPublishStatus)
            {
                case (0):   //All Events
                    sQuery = "SELECT iEventId FROM calendarevent WHERE (bActive = 1 OR bActive = " + Convert.ToInt32(bActiveOnly) + ")";
                    break;
                case (1):   //Submitted Events Only
                    sQuery = "SELECT iEventId FROM calendarevent WHERE (bActive = 1 OR bActive = " + Convert.ToInt32(bActiveOnly) + ") AND bPublished = 0";
                    break;
                case (2):   //Published Events Only
                    sQuery = "SELECT iEventId FROM calendarevent WHERE (bActive = 1 OR bActive = " + Convert.ToInt32(bActiveOnly) + ") AND bPublished = 1";
                    break;
            }
            dtEvents = SQLDataAdapter.Query4DataTable(sQuery);
            List<Event.Event> list = new List<Event.Event>();
            foreach(DataRow row in dtEvents.Rows)
            {
                int iEventId = (int)row[0];
                Event.Event e = new Event.Event(iEventId);
                list.Add(e);
            }
            return list;
        }

        /// <summary>
        /// Returns a table of events. returns all events by default but parameters can be used to get only active/published events
        /// </summary>
        /// <param name="bPublishedOnly">Determines whether only published events are returned. Default: false</param>
        /// <param name="bActiveOnly">Determines whether only active events are returned. Default: false</param>
        /// <returns>Multi rowed table with each row holding an event's attributes.</returns>
        public static DataTable GetSubmittedEvents()
        {
            DataTable dtEvents = new DataTable();
            string sQuery = "SELECT * FROM calendarevent WHERE bPublished = 0 AND bActive = 1";
            dtEvents = SQLDataAdapter.Query4DataTable(sQuery);
            return dtEvents;
        }

        /// <summary>
        /// Returns an event object representing the last submitted event.
        /// </summary>
        /// <returns>Returns a populated event object</returns>
        public static Event.Event GetLastEvent()
        {
            int iEventId;
            string sQuery = "SELECT iEventId FROM calendarevent ORDER BY iEventId DESC LIMIT 1";
            iEventId = SQLDataAdapter.Query4Int(sQuery);

            Event.Event ev = new Event.Event(iEventId);
            return ev;
        }

        /// <summary>
        /// Returns a single rowed table which has all of that event's data.
        /// </summary>
        /// <param name="iEventId">Event to Query for</param>
        /// <returns>Single rowed Datatable with all event attributes.</returns>
        public static DataTable GetEvent(int? iEventId)
        {
            DataTable dtEvents = new DataTable();
            string sQuery = "SELECT * FROM calendarevent WHERE iEventId = " + iEventId;
            dtEvents = SQLDataAdapter.Query4DataTable(sQuery);
            return dtEvents;
        }

        /// <summary>
        /// Deactives an event by Event Id
        /// </summary>
        /// <param name="iEventId"></param>
        /// <returns>Number of rows affected, ideally 1</returns>
        public static int DeactivateEvent(int iEventId)
        {
            int iRowsAffected = 0;
            string sQuery = "UPDATE calendarevent SET bActive = 0 WHERE iEventId = " + iEventId;
            iRowsAffected = SQLDataAdapter.QueryExecute(sQuery);
            return iRowsAffected;
        }
    }
}