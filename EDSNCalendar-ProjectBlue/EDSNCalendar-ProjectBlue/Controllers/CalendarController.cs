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
                Event.EventManager.updateEventManager();
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
        public ActionResult SubmitEvent(FormCollection form)
        {
            
            var EventTitle = Convert.ToString(form["submitEventTitle"]);
            var FirstName = Convert.ToString(form["submitFirstName"]);
            var LastName = Convert.ToString(form["submitLastName"]);
            var HostEmail = Convert.ToString(form["submitEmail"]);
            var HostPhoneNumber = Convert.ToString(form["submitPhoneNumber"]);
            var Date = Convert.ToString(form["submitDate"]);
            var EndDate = Convert.ToString(form["submitEndDate"]);
            var StartTime = Convert.ToString(form["submitTime"]);
            var EventInformation = Convert.ToString(form["submitEventInformation"]);
            var file = Request.Files["image"];           
            var StreetAddress = Convert.ToString(form["submitStreetAddress"]);
            var Address2 = Convert.ToString(form["submitAddressLine2"]);
            var City = Convert.ToString(form["submitCity"]);
            var State = Convert.ToString(form["submitState"]);
            var Zip = Convert.ToString(form["submitZip"]);
            var Country = Convert.ToString(form["submitCountry"]);
            bool AllDay = true;
            if (form["AllDay"] == null)
               AllDay = false;
            var VenueName = Convert.ToString(form["submitVenueName"]);
            var EndTime = Convert.ToString(form["submitEndTime"]);
            var HostURL = Convert.ToString(form["submitURL"]);
            var Cost = "Free";
            bool Fre = true;
            if (form["Free"] == null)
                Fre = false;
            if (!Fre)
                Cost = Convert.ToString(form["submitCost"]);
            var RegURL = Convert.ToString(form["submitRegisterURL"]);
            var SubFName = Convert.ToString(form["submitFirstSName"]);
            var SubLName = Convert.ToString(form["submitLastSName"]);
            var SubEmail = Convert.ToString(form["submitSEmail"]);

            string address = StreetAddress + " " + Address2 + " " + City + " " + State + " " + Zip + " " + Country;

            int iNewEventId = SQLData.SQLQueries.InsertSubmittedEvent(EventTitle, Date, EndDate, StartTime, EndTime, AllDay, VenueName, address, EventInformation, FirstName + " " + LastName, HostEmail, HostPhoneNumber, HostURL, Cost, RegURL, SubFName + " " + SubLName, SubEmail);

            if (file != null)
            {
                //MySqlComm
                byte[] fileBytes = new byte[file.ContentLength];
                file.InputStream.Read(fileBytes, 0, file.ContentLength);
                Event.Event ev = new Event.Event();
                ev.EventId = iNewEventId;
                ev.Image = fileBytes;
                SQLData.SQLQueries.UpdateEventImage(ev);
            }

            List<PropertyType> liPropertyType = new List<PropertyType>();
            liPropertyType = SQLQueries.getAllPropertyTypes(true);
            List<MultiSelectList> liMultiSelect = new List<MultiSelectList>();
            foreach (PropertyType pt in liPropertyType)
            {
                string sName = pt.Name;
                var props = Convert.ToString(form[sName]);
                if(props != null)
                {
                    string[] sProps = props.Split(',');
                    foreach(string s in sProps)
                    {
                        int iProp = int.Parse(s);
                        SQLData.SQLQueries.AddPropertyToEvent(iNewEventId, iProp);
                    }
                }
            }

            return Redirect("Index");
        }
    }
}

   