using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Caviris_MIS4200.DAL;
using Caviris_MIS4200.Models;

namespace Caviris_MIS4200.Controllers
{
    public class PropertyRentersController : Controller
    {
        private Caviris_MIS4200Context db = new Caviris_MIS4200Context();

        // GET: PropertyRenters
        public ActionResult Index()
        {
            var propertyRenter = db.propertyRenter.Include(p => p.property).Include(p => p.renter);
            return View(propertyRenter.ToList());
        }

        // GET: PropertyRenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyRenter propertyRenter = db.propertyRenter.Find(id);
            if (propertyRenter == null)
            {
                return HttpNotFound();
            }
            return View(propertyRenter);
        }

        // GET: PropertyRenters/Create
        public ActionResult Create()
        {
            ViewBag.propertyID = new SelectList(db.property, "propertyID", "streetAddress");
            ViewBag.renterID = new SelectList(db.renter, "renterID", "fullName");
            return View();
        }

        // POST: PropertyRenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "propertyRenterID,dateTimeRented,monthlyRent,dateTimeEnded,propertyID,renterID")] PropertyRenter propertyRenter)
        {
            if (ModelState.IsValid)
            {
                db.propertyRenter.Add(propertyRenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.propertyID = new SelectList(db.property, "propertyID", "streetAddress", propertyRenter.propertyID);
            ViewBag.renterID = new SelectList(db.renter, "renterID", "fullName", propertyRenter.renterID);
            return View(propertyRenter);
        }

        // GET: PropertyRenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyRenter propertyRenter = db.propertyRenter.Find(id);
            if (propertyRenter == null)
            {
                return HttpNotFound();
            }
            ViewBag.propertyID = new SelectList(db.property, "propertyID", "streetAddress", propertyRenter.propertyID);
            ViewBag.renterID = new SelectList(db.renter, "renterID", "fullName", propertyRenter.renterID);
            return View(propertyRenter);
        }

        // POST: PropertyRenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "propertyRenterID,dateTimeRented,monthlyRent,dateTimeEnded,propertyID,renterID")] PropertyRenter propertyRenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyRenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.propertyID = new SelectList(db.property, "propertyID", "streetAddress", propertyRenter.propertyID);
            ViewBag.renterID = new SelectList(db.renter, "renterID", "fullName", propertyRenter.renterID);
            return View(propertyRenter);
        }

        // GET: PropertyRenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyRenter propertyRenter = db.propertyRenter.Find(id);
            if (propertyRenter == null)
            {
                return HttpNotFound();
            }
            return View(propertyRenter);
        }

        // POST: PropertyRenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyRenter propertyRenter = db.propertyRenter.Find(id);
            db.propertyRenter.Remove(propertyRenter);
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
