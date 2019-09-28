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
    public class AllergyUsersController : Controller
    {
        private Entities db = new Entities();

        // GET: AllergyUsers
        public ActionResult Index()
        {
            var allergyUsers = db.AllergyUsers.Include(a => a.Allergy).Include(a => a.AppUser);
            return View(allergyUsers.ToList());
        }

        // GET: AllergyUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllergyUser allergyUser = db.AllergyUsers.Find(id);
            if (allergyUser == null)
            {
                return HttpNotFound();
            }
            return View(allergyUser);
        }

        // GET: AllergyUsers/Create
        public ActionResult Create()
        {
            ViewBag.AllergyID = new SelectList(db.Allergies, "ID", "Allergy1");
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name");
            return View();
        }

        // POST: AllergyUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AllergyID,UserID,Precautions")] AllergyUser allergyUser)
        {
            if (ModelState.IsValid)
            {
                db.AllergyUsers.Add(allergyUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllergyID = new SelectList(db.Allergies, "ID", "Allergy1", allergyUser.AllergyID);
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", allergyUser.UserID);
            return View(allergyUser);
        }

        // GET: AllergyUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllergyUser allergyUser = db.AllergyUsers.Find(id);
            if (allergyUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllergyID = new SelectList(db.Allergies, "ID", "Allergy1", allergyUser.AllergyID);
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", allergyUser.UserID);
            return View(allergyUser);
        }

        // POST: AllergyUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AllergyID,UserID,Precautions")] AllergyUser allergyUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allergyUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllergyID = new SelectList(db.Allergies, "ID", "Allergy1", allergyUser.AllergyID);
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", allergyUser.UserID);
            return View(allergyUser);
        }

        // GET: AllergyUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllergyUser allergyUser = db.AllergyUsers.Find(id);
            if (allergyUser == null)
            {
                return HttpNotFound();
            }
            return View(allergyUser);
        }

        // POST: AllergyUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllergyUser allergyUser = db.AllergyUsers.Find(id);
            db.AllergyUsers.Remove(allergyUser);
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
