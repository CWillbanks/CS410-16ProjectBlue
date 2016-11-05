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
        //SQLDataAdapter sql = new SQLDataAdapter();

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

        public static int InsertEvent(string sEventTitle, DateTime dEventDate, string sStartTime, string sEndTime, bool bAllDay, string sVenueName, string sAddress, string sDescription, string sOrganizerName,
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

    }
}