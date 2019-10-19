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
    public class DisastersController : Controller
    {
        private Entities db = new Entities();


        public ActionResult Request(string type, string city, string destruction, string severity, string btnSubmit, string email)
        {
            if (btnSubmit == "Submit")
            {
                if (type == "" || city == "" || destruction == "" || severity == "")
                {
                    ViewBag.Success = "Please complete all fields";
                    return View("Request");
                }
                else
                {
                    ViewBag.Success = "Email sent! Feel free to submit another disaster.";
                    var senderEmail = new MailAddress("u17073708@tuks.co.za"); //your email goes here
                    var receiverEmail = new MailAddress("hansentheasian@gmail.com", "Administrator");
                    var password = "Dragonoid3316_"; //your email password goes here
                    var sub = "Create new disaster";
                    var body = "Good day admin, a new disaster has been requested to be created with the following details:" + "\n" + "Type of disaster:" + type + "\n" + "City:" + city + "\n" + "Destruction:" + destruction + "\n" + "Severity:" + severity;
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

                    return View("Request");

                }
            }
            else
            {
                return View("Request");
            }
          
        }
        // GET: Disasters
        public ActionResult Index()
        {
            var disasters = db.Disasters.Include(d => d.City).Include(d => d.DisasterType);
            return View(disasters.ToList());
        }

        public ActionResult Index2()
        {
            var disasters = db.Disasters.Include(d => d.City).Include(d => d.DisasterType);
            return View(disasters.ToList());
        }

        // GET: Disasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disaster disaster = db.Disasters.Find(id);
            if (disaster == null)
            {
                return HttpNotFound();
            }
            return View(disaster);
        }

        // GET: Disasters/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name");
            ViewBag.DisasterID = new SelectList(db.DisasterTypes, "ID", "Name");
            return View();
        }

        // POST: Disasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DisasterDate,DamageLevel,Casualties,DisasterID,CityID")] Disaster disaster)
        {
            if (ModelState.IsValid)
            {
                db.Disasters.Add(disaster);
                db.SaveChanges();
                return RedirectToAction("Index2");
            }

            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", disaster.CityID);
            ViewBag.DisasterID = new SelectList(db.DisasterTypes, "ID", "Name", disaster.DisasterID);
            return View(disaster);
        }

        // GET: Disasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disaster disaster = db.Disasters.Find(id);
            if (disaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", disaster.CityID);
            ViewBag.DisasterID = new SelectList(db.DisasterTypes, "ID", "Name", disaster.DisasterID);
            return View(disaster);
        }

        // POST: Disasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DisasterDate,DamageLevel,Casualties,DisasterID,CityID")] Disaster disaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index2");
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", disaster.CityID);
            ViewBag.DisasterID = new SelectList(db.DisasterTypes, "ID", "Name", disaster.DisasterID);
            return View(disaster);
        }

        // GET: Disasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disaster disaster = db.Disasters.Find(id);
            if (disaster == null)
            {
                return HttpNotFound();
            }
            return View(disaster);
        }

        // POST: Disasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disaster disaster = db.Disasters.Find(id);
            db.Disasters.Remove(disaster);
            db.SaveChanges();
            return RedirectToAction("Index2");
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
