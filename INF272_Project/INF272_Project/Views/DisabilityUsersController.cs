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
    public class DisabilityUsersController : Controller
    {
        private Entities db = new Entities();

        // GET: DisabilityUsers
        public ActionResult Index()
        {
            var disabilityUsers = db.DisabilityUsers.Include(d => d.AppUser).Include(d => d.Disability);
            return View(disabilityUsers.ToList());
        }

        // GET: DisabilityUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisabilityUser disabilityUser = db.DisabilityUsers.Find(id);
            if (disabilityUser == null)
            {
                return HttpNotFound();
            }
            return View(disabilityUser);
        }

        // GET: DisabilityUsers/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name");
            ViewBag.DisabilityID = new SelectList(db.Disabilities, "ID", "Disability1");
            return View();
        }

        // POST: DisabilityUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DisabilityID,UserID,Precautions")] DisabilityUser disabilityUser)
        {
            if (ModelState.IsValid)
            {
                db.DisabilityUsers.Add(disabilityUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", disabilityUser.UserID);
            ViewBag.DisabilityID = new SelectList(db.Disabilities, "ID", "Disability1", disabilityUser.DisabilityID);
            return View(disabilityUser);
        }

        // GET: DisabilityUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisabilityUser disabilityUser = db.DisabilityUsers.Find(id);
            if (disabilityUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", disabilityUser.UserID);
            ViewBag.DisabilityID = new SelectList(db.Disabilities, "ID", "Disability1", disabilityUser.DisabilityID);
            return View(disabilityUser);
        }

        // POST: DisabilityUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DisabilityID,UserID,Precautions")] DisabilityUser disabilityUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disabilityUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", disabilityUser.UserID);
            ViewBag.DisabilityID = new SelectList(db.Disabilities, "ID", "Disability1", disabilityUser.DisabilityID);
            return View(disabilityUser);
        }

        // GET: DisabilityUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisabilityUser disabilityUser = db.DisabilityUsers.Find(id);
            if (disabilityUser == null)
            {
                return HttpNotFound();
            }
            return View(disabilityUser);
        }

        // POST: DisabilityUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DisabilityUser disabilityUser = db.DisabilityUsers.Find(id);
            db.DisabilityUsers.Remove(disabilityUser);
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
