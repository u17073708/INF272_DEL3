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
    public class DisasterUsersController : Controller
    {
        private Entities db = new Entities();

        // GET: DisasterUsers
        public ActionResult Index()
        {
            var disasterUsers = db.DisasterUsers.Include(d => d.AppUser).Include(d => d.Disaster);
            return View(disasterUsers.ToList());
        }

        // GET: DisasterUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterUser disasterUser = db.DisasterUsers.Find(id);
            if (disasterUser == null)
            {
                return HttpNotFound();
            }
            return View(disasterUser);
        }

        // GET: DisasterUsers/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name");
            ViewBag.DisasterID = new SelectList(db.Disasters, "ID", "ID");
            return View();
        }

        // POST: DisasterUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DisasterID,UserID,DisasterUserDate,Urgency")] DisasterUser disasterUser)
        {
            if (ModelState.IsValid)
            {
                db.DisasterUsers.Add(disasterUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", disasterUser.UserID);
            ViewBag.DisasterID = new SelectList(db.Disasters, "ID", "ID", disasterUser.DisasterID);
            return View(disasterUser);
        }

        // GET: DisasterUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterUser disasterUser = db.DisasterUsers.Find(id);
            if (disasterUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", disasterUser.UserID);
            ViewBag.DisasterID = new SelectList(db.Disasters, "ID", "ID", disasterUser.DisasterID);
            return View(disasterUser);
        }

        // POST: DisasterUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DisasterID,UserID,DisasterUserDate,Urgency")] DisasterUser disasterUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disasterUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", disasterUser.UserID);
            ViewBag.DisasterID = new SelectList(db.Disasters, "ID", "ID", disasterUser.DisasterID);
            return View(disasterUser);
        }

        // GET: DisasterUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterUser disasterUser = db.DisasterUsers.Find(id);
            if (disasterUser == null)
            {
                return HttpNotFound();
            }
            return View(disasterUser);
        }

        // POST: DisasterUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DisasterUser disasterUser = db.DisasterUsers.Find(id);
            db.DisasterUsers.Remove(disasterUser);
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
