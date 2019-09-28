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
    public class UserSkillsController : Controller
    {
        private Entities db = new Entities();

        // GET: UserSkills
        public ActionResult Index()
        {
            var userSkills = db.UserSkills.Include(u => u.AppUser).Include(u => u.Skill);
            return View(userSkills.ToList());
        }

        // GET: UserSkills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSkill userSkill = db.UserSkills.Find(id);
            if (userSkill == null)
            {
                return HttpNotFound();
            }
            return View(userSkill);
        }

        // GET: UserSkills/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name");
            ViewBag.SkillID = new SelectList(db.Skills, "ID", "Skill1");
            return View();
        }

        // POST: UserSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkillID,UserID,ExperienceLevel")] UserSkill userSkill)
        {
            if (ModelState.IsValid)
            {
                db.UserSkills.Add(userSkill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", userSkill.UserID);
            ViewBag.SkillID = new SelectList(db.Skills, "ID", "Skill1", userSkill.SkillID);
            return View(userSkill);
        }

        // GET: UserSkills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSkill userSkill = db.UserSkills.Find(id);
            if (userSkill == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", userSkill.UserID);
            ViewBag.SkillID = new SelectList(db.Skills, "ID", "Skill1", userSkill.SkillID);
            return View(userSkill);
        }

        // POST: UserSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkillID,UserID,ExperienceLevel")] UserSkill userSkill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userSkill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", userSkill.UserID);
            ViewBag.SkillID = new SelectList(db.Skills, "ID", "Skill1", userSkill.SkillID);
            return View(userSkill);
        }

        // GET: UserSkills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSkill userSkill = db.UserSkills.Find(id);
            if (userSkill == null)
            {
                return HttpNotFound();
            }
            return View(userSkill);
        }

        // POST: UserSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserSkill userSkill = db.UserSkills.Find(id);
            db.UserSkills.Remove(userSkill);
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
