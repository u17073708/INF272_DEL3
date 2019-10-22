using INF272_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace INF272_Project.ViewModels
{
    public class DisasterReportVM : Controller
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public Disaster disaster { get; set; }
        public List<IGrouping<string, ReportRecord>> results { get; set; }
        // GET: DisasterReportVM
        public ActionResult Index()
        {
            return View();
        }
    }
    public class ReportRecord
    {
        public string Name { get; set; }
        public string DisasterDate { get; set; }
        public int DamageLevel { get; set; }
        public int Casualties { get; set; }
        public int DisasterID { get; set; }
        public string City { get; set; }
    }
}