using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafeEats.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Spin()
        {
            ViewBag.Title = "Spinner";
            ViewBag.Message = "Spin away your hunger!";

            return View();
        }

        public ActionResult Profile()
        {
            ViewBag.Title = "Profile";
            ViewBag.Message = "Your profile!";

            return View();
        }
    }
}