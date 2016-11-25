using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDSNCalendar_ProjectBlue.Event;
using EDSNCalendar_ProjectBlue.SQLData;
using EDSNCalendar_ProjectBlue.Property;

namespace EDSNCalendar_ProjectBlue.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.PublishedEvents = EventManager.PublishedEvents.Values.Count;
            ViewBag.SubmittedEvents = EventManager.SubmittedEvents.Values.Count;

            return View();
        }

        public ActionResult EventList(int? Published)
        {
            //Get Number of Published Events
            int publishedCount = EventManager.PublishedEvents.Values.Count;
            ViewBag.PublishedEvents = publishedCount;

            //Get Number of Submitted Events
            int submittedCount = EventManager.SubmittedEvents.Values.Count;
            ViewBag.SubmittedEvents = submittedCount;

            //Get Number of Total Events
            ViewBag.TotalEvents = submittedCount + publishedCount;

            ////list = SQLQueries.getAllEventsList(Published, true);
            //List<SelectListItem> items = new List<SelectListItem>();
            //items.Add(new SelectListItem { Text = "All", Value = "0" });
            //items.Add(new SelectListItem { Text = "Submitted", Value = "1" });
            //items.Add(new SelectListItem { Text = "Published", Value = "2" });
            //ViewBag.SelectedItem = "All";
            //ViewBag.PublishedStatusList = items;

            //Based on optional parameter get a list of events to display to user
            List<Event.Event> list = new List<Event.Event>();            
            switch (Published)
            {
                case null:
                case (0):    //All Events
                    list = SQLQueries.getAllEventsList(0, true);
                    break;
                case (1):       //Submitted Events Only
                    list = SQLQueries.getAllEventsList(1, true);
                    break;
                case (2):       //Published Events Only
                    list = SQLQueries.getAllEventsList(2, true);
                    break;
            }

            return View(list);
        }

        public ActionResult EventDetails(int id)
        {
            Event.Event ev;
            ev = new Event.Event(id);
            return View(ev);
        }

        public ActionResult ConfirmDelete(int id)
        {
            Event.Event ev;
            ev = new Event.Event(id);
            return View(ev);
        }

        public ActionResult DeleteEvent(int id)
        {
            Event.Event ev;
            ev = new Event.Event(id);
            SQLQueries.DeactivateEvent(id);
            if (ev.IsPublished)
                EventManager.PublishedEvents.Remove(id);
            else
                EventManager.SubmittedEvents.Remove(id);
            return View(ev);
        }

        public ActionResult ConfirmPublish(int id)
        {
            Event.Event ev;
            ev = new Event.Event(id);
            return View(ev);
        }

        public ActionResult PublishEvent(int id)
        {
            Event.Event ev;           
            ev = new Event.Event(id);
            SQLQueries.PublishEvent(id);
            return View(ev);
        }

        public ActionResult WidgetCreator()
        {
            return View();
        }

        public ActionResult Properties(int? id)
        {
            List<PropertyType> liPropertyType = new List<PropertyType>();
            liPropertyType = SQLQueries.getAllPropertyTypes(true);
            ViewBag.PropertyTypes = liPropertyType;
            ViewBag.SelectedPropertyType = id;

            List<Property.Property> liProperty = new List<Property.Property>();
            foreach (PropertyType pt in liPropertyType)
            {
                if (id == pt.PropertyTypeId)
                {
                    liProperty = pt.PropertyList;
                }
            }

            return View(liProperty);
        }
        public ActionResult EditEvent(int id)
        {
            Event.Event ev;
            ev = new Event.Event(id);
            return View(ev);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEvent(Event.Event ev)
        {           
            return View(ev);
        }

    }
}