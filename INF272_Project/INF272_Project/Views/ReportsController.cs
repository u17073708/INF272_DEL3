using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INF272_Project.Models;
using INF272_Project.ViewModels;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;



namespace INF272_Project.Views
{
    public class ReportController : Controller
    {

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult DisasterReport(DisasterReportVM vm)
        {
          
                using (Entities db = new Entities())
                {
                    db.Configuration.ProxyCreationEnabled = false;


                    List<Disaster> disasters = db.Disasters.ToList();

                    var list = db.Disasters.Include("City").Include("DisasterType").Where(pp => pp.DisasterDate >= vm.DateFrom && pp.DisasterDate <= vm.DateTo).ToList().Select(rr => new ReportRecord
                    {

                        Name = rr.DisasterType.Name,
                        DisasterDate = rr.DisasterDate.ToString(),
                        DamageLevel = Convert.ToInt32(rr.DamageLevel),
                        Casualties = Convert.ToInt32(rr.Casualties),
                        City = rr.City.Name,
                    });


                    TempData["records"] = disasters.ToList();

                    return View(vm);
                }

            }
           

        


    }
}