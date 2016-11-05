using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EDSNCalendar_ProjectBlue.SQLData;
using System.Data;

namespace EDSNCalendar_ProjectBlue.SQLData
{
    public class SQLQueries
    {
        SQLDataAdapter sql = new SQLDataAdapter();

        //Example Usage of SQLDataAdapter to run Queries
        public string ExampleQuery1(int iCategoryId)
        {
            string sSpecificCategory;
            sSpecificCategory = sql.Query4String("SELECT vCategory FROM categories WHERE iCategoryId = 1");
            return sSpecificCategory;
        }
        //Example Usage of SQLDataAdapter to run Queries
        public void ExampleQuery2()
        {
            string sQuery = "INSERT INTO categories(vCategory) VALUES('Whatever')";
            sql.QueryExecute(sQuery);
        }
        //Example Usage of SQLDataAdapter to run Queries
        public DataTable ExampleQuery3()
        {
            DataTable dtAllCategories;
            dtAllCategories = sql.Query4DataTable("SELECT * FROM categories");
            return dtAllCategories;
        }

    }
}