using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EDSNCalendar_ProjectBlue.SQLData;
using System.Data;

namespace EDSNCalendar_ProjectBlue.SQLData
{
    public static class SQLQueries
    {
        //Example Usage of SQLDataAdapter to run Queries
        public static string ExampleQuery1(int iCategoryId)
        {
            string sSpecificCategory;
            sSpecificCategory = SQLDataAdapter.Query4String("SELECT vCategory FROM categories WHERE iCategoryId = 1");
            return sSpecificCategory;
        }
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

        //Creates a new submitted event in DB
        public static int InsertSubmittedEvent(string sEventTitle, DateTime dEventDate, string sStartTime, string sEndTime, bool bAllDay, string sVenueName, string sAddress, string sDescription, string sOrganizerName,
                                string sOrganizerEmail, string sOrganizerPhoneNumber, string sOrganizerURL, string sCost, string sRegistrationURL, string sSubmitterName, string sSubmitterEmail)
        {

            int iRowsAffected = 0; 
            string sQuery = "INSERT INTO calendarevent(vEventTitle, dEventDate, vStartTime, vEndTime, bAllDay, vVenueName, vAddress, vDescription, vOrganizerName, vOrganizerEmail, vOrganizerPhoneNumber," +
                                                                        "vOrganizerURL, vCost, vRegistrationURL, vSubmitterName, vSubmitterEmail)" +
                            "VALUES('" + sEventTitle + "','" + dEventDate.Date.Year +"/"+ dEventDate.Date.Month+"/"+dEventDate.Date.Day + "','" + sStartTime + "','" + sEndTime + "'," + Convert.ToInt32(bAllDay) + ",'" + sVenueName + "','" + sAddress + "','" +
                                         sDescription + "','" + sOrganizerName + "','" + sOrganizerEmail + "','" + sOrganizerPhoneNumber + "','" + sOrganizerURL + "','" + sCost + "','" + sRegistrationURL + "','" + sSubmitterName + "','" + sSubmitterEmail + "')";
            iRowsAffected = SQLDataAdapter.QueryExecute(sQuery);
            return iRowsAffected;
        }

        //Publishes an existing submitted event in DB
        public static int PublishEvent(int iEventId)
        {
            int iRowsAffected = 0;
            String sQuery = "UPDATE calendarevent SET bPublished = 1 WHERE iCalendarEvent = " + iEventId;
            iRowsAffected = SQLDataAdapter.QueryExecute(sQuery);
            return iRowsAffected;
        }

        //Returns a table of events. returns all events by default but parameters can be used to get only active/published events
        public static DataTable GetEventTable(bool bPublishedOnly = false, bool bActiveOnly = false)
        {
            DataTable dtEvents = new DataTable();
            string sQuery = "SELECT * FROM calendarevent WHERE (bPublished = 1 OR bPublished = " + Convert.ToInt32(bPublishedOnly) + ") AND (bActive = 1 OR bActive = " + Convert.ToInt32(bActiveOnly) + ")";
            dtEvents = SQLDataAdapter.Query4DataTable(sQuery);
            return dtEvents;
        }
    }
}