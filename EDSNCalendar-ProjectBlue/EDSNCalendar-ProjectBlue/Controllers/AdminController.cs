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

        public ActionResult Events()
        {
            Event.Event ev = SQLQueries.GetLastEvent();
            //if (student == null)
            //{
            //    return HttpNotFound();
            //}
            return View(ev);
        }
    }
}