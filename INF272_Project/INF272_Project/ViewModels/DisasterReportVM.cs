
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INF272_Project.Models;

namespace INF272_Project.ViewModels
{
    public class DisasterReportVM : Controller
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        // GET: DisasterReportVM
        public ActionResult Index()
        {
            return View();
        }
    }
}