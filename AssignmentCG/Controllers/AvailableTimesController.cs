using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssignmentCG.Models;

namespace AssignmentCG.Controllers
{
    public class AvailableTimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AvailableTimes
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.AvailableTimes.ToList());
        }

        // GET: AvailableTimes/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailableTime availableTime = db.AvailableTimes.Find(id);
            if (availableTime == null)
            {
                return HttpNotFound();
            }
            return View(availableTime);
        }

        // GET: AvailableTimes/Create
        public ActionResult Create()
        {
            if (User.IsInRole("General Practitioner") || User.IsInRole("Admin"))
            { return View(); }
            else
            { return HttpNotFound(); }
        }

        // POST: AvailableTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTime,EndTime")] AvailableTime availableTime)
        {
            if (User.IsInRole("General Practitioner") || User.IsInRole("Admin"))
            {
                availableTime.GP = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                ModelState.Clear();
                TryValidateModel(availableTime);
                if (ModelState.IsValid)
                {
                    db.AvailableTimes.Add(availableTime);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(availableTime);
            }
            else
            { return HttpNotFound(); }

           
        }

        // GET: AvailableTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailableTime availableTime = db.AvailableTimes.Find(id);
            if (availableTime == null)
            {
                return HttpNotFound();
            }
            return View(availableTime);
        }

        // POST: AvailableTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,EndTime")] AvailableTime availableTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(availableTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(availableTime);
        }

        // GET: AvailableTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvailableTime availableTime = db.AvailableTimes.Find(id);
            if (availableTime == null)
            {
                return HttpNotFound();
            }
            return View(availableTime);
        }

        // POST: AvailableTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvailableTime availableTime = db.AvailableTimes.Find(id);
            db.AvailableTimes.Remove(availableTime);
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
