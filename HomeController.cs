using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneShack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Staff()
        {
            ViewBag.Message = "Staff Home Page.";

            return View();
        }

        public ActionResult Terms()
        {
            ViewBag.Message = "Terms & Conditions";

            return View();
        }
    }
}