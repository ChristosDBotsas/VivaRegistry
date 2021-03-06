﻿using System;
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
        public ActionResult Details(int? id)
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
            if (TempData["ErrMsg"] != null)
            {
                ViewBag.Message = TempData["ErrMsg"].ToString();
            }
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationId,ApplicationKey,ApplicationEmail,ApplicationName,CreationDate")] Application application)
        {
            if (ModelState.IsValid)
            {
                Application duplicate = db.Applications.Where(x => x.ApplicationKey == application.ApplicationKey).FirstOrDefault();
                if (duplicate != null)
                {
                    TempData["ErrMsg"] = "You have entered a duplicate key value, please try again.";
                    return RedirectToAction("Create");
                }
                else
                {
                    application.CreationDate = DateTime.Now;
                    db.Applications.Add(application);
                    db.SaveChanges();
                    return RedirectToAction("Confirmation", application);
                }
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
