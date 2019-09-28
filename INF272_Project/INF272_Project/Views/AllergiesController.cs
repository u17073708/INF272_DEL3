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
    public class AllergiesController : Controller
    {
        private Entities db = new Entities();

        // GET: Allergies
        public ActionResult Index()
        {
            return View(db.Allergies.ToList());
        }

        // GET: Allergies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allergy allergy = db.Allergies.Find(id);
            if (allergy == null)
            {
                return HttpNotFound();
            }
            return View(allergy);
        }

        // GET: Allergies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Allergies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Allergy1,AllergyDescription,Remedy")] Allergy allergy)
        {
            if (ModelState.IsValid)
            {
                db.Allergies.Add(allergy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allergy);
        }

        // GET: Allergies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allergy allergy = db.Allergies.Find(id);
            if (allergy == null)
            {
                return HttpNotFound();
            }
            return View(allergy);
        }

        // POST: Allergies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Allergy1,AllergyDescription,Remedy")] Allergy allergy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allergy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allergy);
        }

        // GET: Allergies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allergy allergy = db.Allergies.Find(id);
            if (allergy == null)
            {
                return HttpNotFound();
            }
            return View(allergy);
        }

        // POST: Allergies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Allergy allergy = db.Allergies.Find(id);
            db.Allergies.Remove(allergy);
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
