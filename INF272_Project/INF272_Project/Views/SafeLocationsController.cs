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
    public class SafeLocationsController : Controller
    {
        private Entities db = new Entities();

        // GET: SafeLocations
        public ActionResult Index()
        {
            var safeLocations = db.SafeLocations.Include(s => s.City);
            return View(safeLocations.ToList());
        }

        // GET: SafeLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SafeLocation safeLocation = db.SafeLocations.Find(id);
            if (safeLocation == null)
            {
                return HttpNotFound();
            }
            return View(safeLocation);
        }

        // GET: SafeLocations/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name");
            return View();
        }

        // POST: SafeLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Coordinates,CityID")] SafeLocation safeLocation)
        {
            if (ModelState.IsValid)
            {
                db.SafeLocations.Add(safeLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", safeLocation.CityID);
            return View(safeLocation);
        }

        // GET: SafeLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SafeLocation safeLocation = db.SafeLocations.Find(id);
            if (safeLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", safeLocation.CityID);
            return View(safeLocation);
        }

        // POST: SafeLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Coordinates,CityID")] SafeLocation safeLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(safeLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", safeLocation.CityID);
            return View(safeLocation);
        }

        // GET: SafeLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SafeLocation safeLocation = db.SafeLocations.Find(id);
            if (safeLocation == null)
            {
                return HttpNotFound();
            }
            return View(safeLocation);
        }

        // POST: SafeLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SafeLocation safeLocation = db.SafeLocations.Find(id);
            db.SafeLocations.Remove(safeLocation);
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
