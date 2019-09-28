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
    public class HelpUsersController : Controller
    {
        private Entities db = new Entities();

        // GET: HelpUsers
        public ActionResult Index()
        {
            var helpUsers = db.HelpUsers.Include(h => h.AppUser).Include(h => h.Disaster).Include(h => h.Help);
            return View(helpUsers.ToList());
        }

        // GET: HelpUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HelpUser helpUser = db.HelpUsers.Find(id);
            if (helpUser == null)
            {
                return HttpNotFound();
            }
            return View(helpUser);
        }

        // GET: HelpUsers/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name");
            ViewBag.DisasterID = new SelectList(db.Disasters, "ID", "ID");
            ViewBag.HelpID = new SelectList(db.Helps, "ID", "Help1");
            return View();
        }

        // POST: HelpUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HelpID,UserID,HelpUserDate,DisasterID")] HelpUser helpUser)
        {
            if (ModelState.IsValid)
            {
                db.HelpUsers.Add(helpUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", helpUser.UserID);
            ViewBag.DisasterID = new SelectList(db.Disasters, "ID", "ID", helpUser.DisasterID);
            ViewBag.HelpID = new SelectList(db.Helps, "ID", "Help1", helpUser.HelpID);
            return View(helpUser);
        }

        // GET: HelpUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HelpUser helpUser = db.HelpUsers.Find(id);
            if (helpUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", helpUser.UserID);
            ViewBag.DisasterID = new SelectList(db.Disasters, "ID", "ID", helpUser.DisasterID);
            ViewBag.HelpID = new SelectList(db.Helps, "ID", "Help1", helpUser.HelpID);
            return View(helpUser);
        }

        // POST: HelpUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HelpID,UserID,HelpUserDate,DisasterID")] HelpUser helpUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(helpUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", helpUser.UserID);
            ViewBag.DisasterID = new SelectList(db.Disasters, "ID", "ID", helpUser.DisasterID);
            ViewBag.HelpID = new SelectList(db.Helps, "ID", "Help1", helpUser.HelpID);
            return View(helpUser);
        }

        // GET: HelpUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) // edit
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HelpUser helpUser = db.HelpUsers.Find(id);
            if (helpUser == null)
            {
                return HttpNotFound();
            }
            return View(helpUser);
        }

        // POST: HelpUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HelpUser helpUser = db.HelpUsers.Find(id);
            db.HelpUsers.Remove(helpUser);
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
