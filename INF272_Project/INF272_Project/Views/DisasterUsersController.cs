using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INF272_Project.Models;
using System.Net.Mail;

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
      

        public ActionResult Index2()
        {
            var disasterUsers = db.DisasterUsers.Include(d => d.AppUser).Include(d => d.Disaster);
            return View(disasterUsers.ToList());
        }

        public ActionResult Index3()
        {
            var disasterUsers = db.DisasterUsers.Include(d => d.AppUser).Include(d => d.Disaster);
            return View(disasterUsers.ToList());
        }

      

        public ActionResult GiveHelpForms(string name, string city, string days, string description, string btnSubmit)
        {
            if (btnSubmit == "Submit")
            {
                if (name == "" || city == "" || days == "" || description == "")
                {

                    ViewBag.Success = "Please complete all fields";
                    return View("GiveHelpForms");
                }
                else
                {
                    ViewBag.Success = "Email sent to the person needing help!";
                    var senderEmail = new MailAddress("u17073708@tuks.co.za"); //your email goes here
                    var receiverEmail = new MailAddress("hansentheasian@gmail.com", "Administrator");
                    var password = "Dragonoid3316_"; //your email password goes here
                    var sub = "Help is on its way!";
                    var body = "We hope this message finds you well, " + name + " is on their way and they will be there in " + days + " days because they are coming from " + city + "." + "\n" + "They will be providing you with the following help:" + "\n" + description + "\n" + "Hang in there as help is on its way!";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com", //this might change accordingly
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = sub,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }

                    return View("GiveHelpForms");

                }
            }
            else
            {
                return View("GiveHelpForms");
            }
        }

       

        // GET: DisasterUsers/Details/5
        public ActionResult Details(int? id, int? id2)
        {
            if (id == null || id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CODE MODIFIED HERE
            DisasterUser disasterUser = db.DisasterUsers.Find(id2,id);
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
        public ActionResult Edit(int? id, int? id2)
        {
            if (id == null||id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterUser disasterUser = db.DisasterUsers.Find(id2,id);
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
                return RedirectToAction("Index3");
            }
            ViewBag.UserID = new SelectList(db.AppUsers, "ID", "Name", disasterUser.UserID);
            ViewBag.DisasterID = new SelectList(db.Disasters, "ID", "ID", disasterUser.DisasterID);
            return View(disasterUser);
        }

        // GET: DisasterUsers/Delete/5
        public ActionResult Delete(int? id,int? id2)
        {
            if (id == null||id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterUser disasterUser = db.DisasterUsers.Find(id2,id);
            if (disasterUser == null)
            {
                return HttpNotFound();
            }
            return View(disasterUser);
        }

        // POST: DisasterUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int id2)
        {
            DisasterUser disasterUser = db.DisasterUsers.Find(id2, id);
            db.DisasterUsers.Remove(disasterUser);
            db.SaveChanges();
            return RedirectToAction("Index3");
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
