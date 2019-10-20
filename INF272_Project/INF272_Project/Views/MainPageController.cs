using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INF272_Project.ViewModels;

namespace INF272_Project.Views
{
    public class MainPageController : Controller
    {
        
        // GET: MainPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetInputDetails()
        {

        }
        [HttpPost]
        public ActionResult Login (string Username, string Password)
        {
            
        }

        //public ActionResult GetHelp()
        //{
        //    return View("~/Views/Default/GetHelp.cshtml");
        //}
        //public ActionResult GiveHelp()
        //{
        //    return View("~/Views/Default/LoginGiveHelp.cshtml");
        //}
        //public ActionResult CreateDisaster()
        //{
        //    return View("~/Views/Default/LoginCreateDisaster.cshtml");
        //}
       
    }
}