using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elements.MVC.Controllers
{
    public class HomeController : Controller
    {
        /*
         * http://localhost/Home/
         */
        public ActionResult Index()
        {
            return View();
        }

        /*
         * http://localhost/Home/About/ 
         */
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Test = "Un petit test";
            ViewBag.Number = 1;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}