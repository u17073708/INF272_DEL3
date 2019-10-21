using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INF272_Project.Models;
using INF272_Project.ViewModels;


namespace INF272_Project.Views
{
    public class ReportController : Controller
    {
       
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisasterReport()
        {
            DisasterReportVM vm = new DisasterReportVM();

            

            //Set default values for the FROM and TO dates
            vm.DateFrom = new DateTime(2014, 12, 1);
            vm.DateTo = new DateTime(2014, 12, 31);


            return View(vm);


        }

        [HttpPost]
        public ActionResult DisasterReport(DisasterReportVM vm)
        {
            using (Entities db = new Entities())
            {
                db.Configuration.ProxyCreationEnabled = false;




                 0                     List<Disaster> disasters = db.Disasters.ToList();

                

                
                
                TempData["records"] = disasters.ToList();
                
                return View(vm);
            }

        }
    }
}