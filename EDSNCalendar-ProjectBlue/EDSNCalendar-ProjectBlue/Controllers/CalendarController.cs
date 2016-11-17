using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDSNCalendar_ProjectBlue.Event;
namespace EDSNCalendar_ProjectBlue.Controllers
{
    public class CalendarController : Controller
    {
        public ActionResult Index()
        {
            try
            {
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
        public void PublishEvent(FormCollection form)
        {
          
            var EventTitle = Convert.ToString(form["publishEventTitle"]);
            var FirstName = Convert.ToString(form["publishFirstName"]);
            var LastName = Convert.ToString(form["publishLastName"]);
            var HostEmail = Convert.ToString(form["publishEmail"]);
            var HostPhoneNumber = Convert.ToString(form["publishPhoneNumber"]);
            var Date = Convert.ToString(form["publishDate"]);
            var Time = Convert.ToString(form["publishTime"]);
            var EventInformation = Convert.ToString(form["publishEventInformation"]);
            var StreetAddress = Convert.ToString(form["publishStreetAddres"]);
            var Addres2 = Convert.ToString(form["publishAddressLine2"]);
            var City = Convert.ToString(form["publishCity"]);
            var State = Convert.ToString(form["publishState"]);
            var Zip = Convert.ToString(form["publishZip"]);
            var Country = Convert.ToString(form["publishCountry"]);
            string adress = StreetAddress + " " + Addres2 + " " + City + " " + State + " " + Zip + " " + Country;
            //Event.Event ev = new Event.Event(EventTitle, FirstName, HostEmail, HostPhoneNumber, "", "", EventInformation, "", "", "", Date, "", "", true);
            SQLData.SQLQueries.InsertSubmittedEvent(EventTitle, Date, "", "", true, "", adress, EventInformation, FirstName + " " + LastName, HostEmail, HostPhoneNumber, "", "", "", "", "");
            
            
        }
    }
}

   