using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab6.Models;

namespace lab6.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TelemetriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Telemetries
        public ActionResult Index()
        {
            Telemetry telemetry = db.Telemetries.Find(1);
            
            telemetry.TotalPosts = db.Posts.Count();
            telemetry.TotalTopics = db.Topics.Count();
            telemetry.TotalComments = db.Comments.Count();

            db.SaveChanges();
            return View(db.Telemetries.ToList());
        }

        // GET: Telemetries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telemetry telem = db.Telemetries.Find(1);

            telem.TotalPosts = db.Posts.Count();
            telem.TotalTopics = db.Topics.Count();
            telem.TotalComments = db.Comments.Count();

            db.SaveChanges();
            Telemetry telemetry = db.Telemetries.Find(id);
            if (telemetry == null)
            {
                return HttpNotFound();
            }
            return View(telemetry);
        }

        // GET: Telemetries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Telemetries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TelemetryId,Region,TotalTopics,TotalPosts,TotalComments")] Telemetry telemetry)
        {
            if (ModelState.IsValid)
            {
                db.Telemetries.Add(telemetry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(telemetry);
        }

        // GET: Telemetries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telemetry telemetry = db.Telemetries.Find(id);
            if (telemetry == null)
            {
                return HttpNotFound();
            }
            return View(telemetry);
        }

        // POST: Telemetries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TelemetryId,TotalTopics,TotalPosts,TotalComments")] Telemetry telemetry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telemetry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(telemetry);
        }

        // GET: Telemetries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telemetry telemetry = db.Telemetries.Find(id);
            if (telemetry == null)
            {
                return HttpNotFound();
            }
            return View(telemetry);
        }

        // POST: Telemetries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telemetry telemetry = db.Telemetries.Find(id);
            db.Telemetries.Remove(telemetry);
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
