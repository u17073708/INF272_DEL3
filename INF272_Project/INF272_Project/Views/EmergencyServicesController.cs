using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INF272_Project.Models;

namespace INF272_Project.Views
{
    public class EmergencyServicesController : Controller
    {
        private Entities db = new Entities();

        // GET: EmergencyServices
        public ActionResult Index()
        {
            return View(db.EmergencyServices.ToList());
        }

        // GET: EmergencyServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyService emergencyService = db.EmergencyServices.Find(id);
            if (emergencyService == null)
            {
                return HttpNotFound();
            }
            return View(emergencyService);
        }

        // GET: EmergencyServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmergencyServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Number")] EmergencyService emergencyService)
        {
            if (ModelState.IsValid)
            {
                db.EmergencyServices.Add(emergencyService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emergencyService);
        }

        // GET: EmergencyServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyService emergencyService = db.EmergencyServices.Find(id);
            if (emergencyService == null)
            {
                return HttpNotFound();
            }
            return View(emergencyService);
        }

        // POST: EmergencyServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Number")] EmergencyService emergencyService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emergencyService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emergencyService);
        }

        // GET: EmergencyServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyService emergencyService = db.EmergencyServices.Find(id);
            if (emergencyService == null)
            {
                return HttpNotFound();
            }
            return View(emergencyService);
        }

        // POST: EmergencyServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmergencyService emergencyService = db.EmergencyServices.Find(id);
            db.EmergencyServices.Remove(emergencyService);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
