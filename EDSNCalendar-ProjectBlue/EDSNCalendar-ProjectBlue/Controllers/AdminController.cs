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

        public ActionResult EventList()
        {
            List <Event.Event> list = SQLQueries.getAllEventsList();

            return View(list);
        }

        public ActionResult EventDetails(int id)
        {
            Event.Event ev;
            ev = new Event.Event(id);
            return View(ev);
        }
    }
}