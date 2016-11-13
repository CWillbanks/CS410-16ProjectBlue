using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDSNCalendar_ProjectBlue.Event;
using EDSNCalendar_ProjectBlue.SQLData;

namespace EDSNCalendar_ProjectBlue.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EventList(int? Published)
        {
            List<Event.Event> list = new List<Event.Event>();
            //list = SQLQueries.getAllEventsList(Published, true);
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "All", Value = "0" });
            items.Add(new SelectListItem { Text = "Submitted", Value = "1" });
            items.Add(new SelectListItem { Text = "Published", Value = "2" });
            ViewBag.SelectedItem = "All";
            ViewBag.PublishedStatusList = items;

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

    }
}