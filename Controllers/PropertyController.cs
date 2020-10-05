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
    public class PropertyController : Controller
    {
        private Caviris_MIS4200Context db = new Caviris_MIS4200Context();

        // GET: Properties
        public ActionResult Index()
        {
            var property = db.property.Include(p => p.owner);
            return View(property.ToList());
        }

        // GET: Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.property.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            ViewBag.ownerID = new SelectList(db.owner, "ownerID", "fullName");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "propertyID,streetAddress,city,state,zipcode,ownerID")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.property.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ownerID = new SelectList(db.owner, "ownerID", "fullName", property.ownerID);
            return View(property);
        }

        // GET: Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.property.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.ownerID = new SelectList(db.owner, "ownerID", "fullName", property.ownerID);
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "propertyID,streetAddress,city,state,zipcode,ownerID")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ownerID = new SelectList(db.owner, "ownerID", "fullName", property.ownerID);
            return View(property);
        }

        // GET: Properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.property.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.property.Find(id);
            db.property.Remove(property);
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
