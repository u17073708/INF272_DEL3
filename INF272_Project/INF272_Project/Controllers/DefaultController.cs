using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INF272_Project.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult AboutUs()
        {
            return View("~/Views/Default/AboutUs.cshtml");
        }

        public ActionResult Login()
        {
            return View("~/Views/Default/Login.cshtml");
        }
        public ActionResult News()
        {
            return View("~/Views/Default/News.cshtml");
        }
        public ActionResult Admin()
        {
            return View("~/Views/Default/Admin.cshtml");
        }
        public ActionResult ControlPage()
        {
            return View("~/Views/Default/ControlPage.cshtml");
        }
    }
}