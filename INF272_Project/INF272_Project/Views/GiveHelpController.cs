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
    public class GiveHelpController : Controller
    {
        private Entities db = new Entities();
        // GET: GiveHelp
        public ActionResult Index(int? id)
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

            return View();
        }
    }
}