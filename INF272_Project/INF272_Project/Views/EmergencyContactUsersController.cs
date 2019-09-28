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
    public class EmergencyContactUsersController : Controller
    {
        private Entities db = new Entities();

        // GET: EmergencyContactUsers
        public ActionResult Index()
        {
            var emergencyContactUsers = db.EmergencyContactUsers.Include(e => e.AppUser).Include(e => e.EmergencyContact);
            return View(emergencyContactUsers.ToList());
        }

        // GET: EmergencyContactUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContactUser emergencyContactUser = db.EmergencyContactUsers.Find(id);
            if (emergencyContactUser == null)
            {
                return HttpNotFound();
            }
            return View(emergencyContactUser);
        }

        // GET: EmergencyContactUsers/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name");
            ViewBag.EmergencyContactID = new SelectList(db.EmergencyContacts, "ID", "Name");
            return View();
        }

        // POST: EmergencyContactUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmergencyContactID,UserID,Precautions")] EmergencyContactUser emergencyContactUser)
        {
            if (ModelState.IsValid)
            {
                db.EmergencyContactUsers.Add(emergencyContactUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", emergencyContactUser.UserID);
            ViewBag.EmergencyContactID = new SelectList(db.EmergencyContacts, "ID", "Name", emergencyContactUser.EmergencyContactID);
            return View(emergencyContactUser);
        }

        // GET: EmergencyContactUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContactUser emergencyContactUser = db.EmergencyContactUsers.Find(id);
            if (emergencyContactUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", emergencyContactUser.UserID);
            ViewBag.EmergencyContactID = new SelectList(db.EmergencyContacts, "ID", "Name", emergencyContactUser.EmergencyContactID);
            return View(emergencyContactUser);
        }

        // POST: EmergencyContactUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmergencyContactID,UserID,Precautions")] EmergencyContactUser emergencyContactUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emergencyContactUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", emergencyContactUser.UserID);
            ViewBag.EmergencyContactID = new SelectList(db.EmergencyContacts, "ID", "Name", emergencyContactUser.EmergencyContactID);
            return View(emergencyContactUser);
        }

        // GET: EmergencyContactUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContactUser emergencyContactUser = db.EmergencyContactUsers.Find(id);
            if (emergencyContactUser == null)
            {
                return HttpNotFound();
            }
            return View(emergencyContactUser);
        }

        // POST: EmergencyContactUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmergencyContactUser emergencyContactUser = db.EmergencyContactUsers.Find(id);
            db.EmergencyContactUsers.Remove(emergencyContactUser);
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
