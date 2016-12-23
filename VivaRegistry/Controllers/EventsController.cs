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
    public class EventsController : Controller
    {
        private VivaRegistryContext db = new VivaRegistryContext();

        public ActionResult Create(int id)
        {
            ViewBag.App = id;
            ViewBag.LogId = new SelectList(db.LogLevels.ToList(), "LogLevelId", "LogLevelName", 0);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventGenerationDate,AppId,LogId")] Event newEvent, int id)
        {
            if (ModelState.IsValid)
            {
                newEvent.AppId = id;
                newEvent.EventGenerationDate = DateTime.Now;
                db.Events.Add(newEvent);
                db.SaveChanges();
                return Redirect($"~/Applications/Details/{id}");
            }
            ViewBag.App = id;
            ViewBag.LogId = new SelectList(db.LogLevels.ToList(), "LogLevelId", "LogLevelName", newEvent.LogId);
            return View(newEvent);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppId = new SelectList(db.Applications, "ApplicationId", "ApplicationName", @event.AppId);
            ViewBag.LogId = new SelectList(db.LogLevels, "LogLevelId", "LogLevelName", @event.LogId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventGenerationDate,AppId,LogId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect($"~/Applications/Details/{@event.AppId}");
            }
            ViewBag.AppId = new SelectList(db.Applications, "ApplicationId", "ApplicationName", @event.AppId);
            ViewBag.LogId = new SelectList(db.LogLevels, "LogLevelId", "LogLevelName", @event.LogId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return Redirect($"~/Applications/Details/{@event.AppId}");
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
