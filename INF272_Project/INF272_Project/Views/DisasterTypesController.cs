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
    public class DisasterTypesController : Controller
    {
        private Entities db = new Entities();

        // GET: DisasterTypes
        public ActionResult Index()
        {
            return View(db.DisasterTypes.ToList());
        }

        // GET: DisasterTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterType disasterType = db.DisasterTypes.Find(id);
            if (disasterType == null)
            {
                return HttpNotFound();
            }
            return View(disasterType);
        }

        // GET: DisasterTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisasterTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Destructiveness")] DisasterType disasterType)
        {
            if (ModelState.IsValid)
            {
                db.DisasterTypes.Add(disasterType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disasterType);
        }

        // GET: DisasterTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterType disasterType = db.DisasterTypes.Find(id);
            if (disasterType == null)
            {
                return HttpNotFound();
            }
            return View(disasterType);
        }

        // POST: DisasterTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Destructiveness")] DisasterType disasterType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disasterType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disasterType);
        }

        // GET: DisasterTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterType disasterType = db.DisasterTypes.Find(id);
            if (disasterType == null)
            {
                return HttpNotFound();
            }
            return View(disasterType);
        }

        // POST: DisasterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DisasterType disasterType = db.DisasterTypes.Find(id);
            db.DisasterTypes.Remove(disasterType);
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
