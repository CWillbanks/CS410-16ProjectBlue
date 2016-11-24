using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDSNCalendar_ProjectBlue.Event;
using EDSNCalendar_ProjectBlue.Property;
using EDSNCalendar_ProjectBlue.SQLData;
namespace EDSNCalendar_ProjectBlue.Controllers
{
    public class CalendarController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                List<PropertyType> liPropertyType = new List<PropertyType>();
                liPropertyType = SQLQueries.getAllPropertyTypes(true);
                List<MultiSelectList> liMultiSelect = new List<MultiSelectList>();
                foreach (PropertyType pt in liPropertyType)
                {
                    List<Property.Property> tempProp = new List<Property.Property>();
                    {
                        liMultiSelect.Add(new MultiSelectList(pt.PropertyList, "propertyId", "name"));
                    }
                }                
                ViewBag.PropertyTypes = liPropertyType;
                ViewBag.PropertyLists = liMultiSelect;
                ViewBag.PublishedEvents = Event.EventManager.ToJSONRepresentation(true);
            } catch (Exception e)
            {
                
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult PublishEvent(FormCollection form)
        {
          
            var EventTitle = Convert.ToString(form["publishEventTitle"]);
            var FirstName = Convert.ToString(form["publishFirstName"]);
            var LastName = Convert.ToString(form["publishLastName"]);
            var HostEmail = Convert.ToString(form["publishEmail"]);
            var HostPhoneNumber = Convert.ToString(form["publishPhoneNumber"]);
            var Date = Convert.ToString(form["publishDate"]);
            var StartTime = Convert.ToString(form["publishTime"]);
            var EventInformation = Convert.ToString(form["publishEventInformation"]);
            var StreetAddress = Convert.ToString(form["publishStreetAddres"]);
            var Address2 = Convert.ToString(form["publishAddressLine2"]);
            var City = Convert.ToString(form["publishCity"]);
            var State = Convert.ToString(form["publishState"]);
            var Zip = Convert.ToString(form["publishZip"]);
            var Country = Convert.ToString(form["publishCountry"]);
            bool AllDay = true;
            if (form["AllDay"] == null)
               AllDay = false;
            var VenueName = Convert.ToString(form["publishVenueName"]);
            var EndTime = Convert.ToString(form["publishEndTime"]);
            var HostURL = Convert.ToString(form["publishURL"]);
            var Cost = "Free";
            bool Fre = true;
            if (form["Free"] == null)
                Fre = false;
            if (!Fre)
                Cost = Convert.ToString(form["publishCost"]);
            var RegURL = Convert.ToString(form["publishRegisterURL"]);
            var SubFName = Convert.ToString(form["publishFirstSName"]);
            var SubLName = Convert.ToString(form["publishLastSName"]);
            var SubEmail = Convert.ToString(form["publishSEmail"]);

            string address = StreetAddress + " " + Address2 + " " + City + " " + State + " " + Zip + " " + Country;
  
            SQLData.SQLQueries.InsertSubmittedEvent(EventTitle, Date, StartTime, EndTime, AllDay, VenueName, address, EventInformation, FirstName + " " + LastName, HostEmail, HostPhoneNumber, HostURL,Cost, RegURL, SubFName + " " +SubLName, SubEmail);

            return Redirect("Index");
        }
    }
}

   