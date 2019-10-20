using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INF272_Project.ViewModels;
using INF272_Project.Views;
using INF272_Project.Models;


namespace INF272_Project.Views.Report
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
        public ActionResult DisasterReports(DisasterReportVM vm)
        {
            using (DisasterDB db = new DisasterDB())
            {
                db.Configuration.ProxyCreationEnabled = false;

                //Retrieve a list of vendors so that it can be used to populate the dropdown on the View
                //The ID of the currently selected item is passed through so that the returned list has that item preselected
            

                //Get all supplier orders that adheres to the entered criteria
                //For each of the results, load data into a new ReportRecord object
                var list = db.PurchaseOrderHeaders.Include("ShipMethod").Where(pp => pp.VendorID == vm.vendor.BusinessEntityID && pp.OrderDate >= vm.DateFrom && pp.OrderDate <= vm.DateTo).ToList().Select(rr => new ReportRecord
                {
                    OrderDate = rr.OrderDate.ToString("dd-MMM-yyyy"),
                    Amount = Convert.ToDouble(rr.TotalDue),
                    ShipMethod = rr.ShipMethod.Name,
                    Employee = db.People.Where(pp => pp.BusinessEntityID == rr.EmployeeID).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault(),
                    VendorID = rr.VendorID
                });

                //Load the list of ReportRecords returned by the above query into a new list grouped by Shipment Method
                vm.results = list.GroupBy(g => g.ShipMethod).ToList();

                //Load the list of ReportRecords returned by the above query into a new dictionary grouped by Employee
                //This will be used to generate the chart on the View through the MicroSoft Charts helper
                vm.chartData = list.GroupBy(g => g.Employee).ToDictionary(g => g.Key, g => g.Sum(v => v.Amount));

                //Store the chartData dictionary in temporary data so that it can be accessed by the EmployeeOrdersChart action resonsible for generating the chart
                TempData["chartData"] = vm.chartData;
                TempData["records"] = list.ToList();
                TempData["vendor"] = vm.vendor;
                return View(vm);
            }

        }













    }

}