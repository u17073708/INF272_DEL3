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
    public class DisabilitiesController : Controller
    {
        private Entities db = new Entities();

        // GET: Disabilities
        public ActionResult Index()
        {
            return View(db.Disabilities.ToList());
        }

        // GET: Disabilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disability disability = db.Disabilities.Find(id);
            if (disability == null)
            {
                return HttpNotFound();
            }
            return View(disability);
        }

        // GET: Disabilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Disability1,DisabilityDescription,Remedies")] Disability disability)
        {
            if (ModelState.IsValid)
            {
                db.Disabilities.Add(disability);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disability);
        }

        // GET: Disabilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disability disability = db.Disabilities.Find(id);
            if (disability == null)
            {
                return HttpNotFound();
            }
            return View(disability);
        }

        // POST: Disabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Disability1,DisabilityDescription,Remedies")] Disability disability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disability);
        }

        // GET: Disabilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disability disability = db.Disabilities.Find(id);
            if (disability == null)
            {
                return HttpNotFound();
            }
            return View(disability);
        }

        // POST: Disabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disability disability = db.Disabilities.Find(id);
            db.Disabilities.Remove(disability);
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
