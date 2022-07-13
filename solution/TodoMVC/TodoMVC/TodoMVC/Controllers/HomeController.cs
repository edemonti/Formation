using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TodoMVC.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous] //On peut afficher cette page sans être loggé.
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous] //On peut afficher cette page sans être loggé.
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous] //On peut afficher cette page sans être loggé.
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}