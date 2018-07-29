using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResWebsite.UI.Areas.Staff.Controllers
{
    public class HomeController : Controller
    {
        // GET: Staff/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ConfirmReservation()
        {
            return View();
        }
        public ActionResult Calendar()
        {
            return View();
        }
        public ActionResult Report()
        {
            return View();
        }
       
    }
}