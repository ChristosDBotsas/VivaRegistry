using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VivaRegistry.Models;

namespace VivaRegistry.Controllers
{
    public class ApplicationsController : Controller
    {
        private VivaRegistryContext db = new VivaRegistryContext();

        // GET: Applications
        public ActionResult Index()
        {
            return View(db.Applications.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationId,ApplicationName,CreationDate")] Application application)
        {
            if (ModelState.IsValid)
            {
                application.ApplicationId = Guid.NewGuid();
                application.CreationDate = DateTime.Now;
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Confirmation", application);
            }

            return View(application);
        }

        public ActionResult Confirmation(Application app)
        {
            return View(app);
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
