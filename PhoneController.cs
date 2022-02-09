using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneShack.Models;

namespace PhoneShack.Controllers
{
    public class PhoneController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Phone
        public ActionResult Index()
        {
            return View(db.tbl_Phone.ToList());
        }

        // GET: Phone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Phone tbl_Phone = db.tbl_Phone.Find(id);
            if (tbl_Phone == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Phone);
        }

        // GET: Phone/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Phone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhoneID,PhoneName,PhoneManufacturer,YearMade")] tbl_Phone tbl_Phone)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Phone.Add(tbl_Phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Phone);
        }

        // GET: Phone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Phone tbl_Phone = db.tbl_Phone.Find(id);
            if (tbl_Phone == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Phone);
        }

        // POST: Phone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhoneID,PhoneName,PhoneManufacturer,YearMade")] tbl_Phone tbl_Phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Phone);
        }

        // GET: Phone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Phone tbl_Phone = db.tbl_Phone.Find(id);
            if (tbl_Phone == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Phone);
        }

        // POST: Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Phone tbl_Phone = db.tbl_Phone.Find(id);
            db.tbl_Phone.Remove(tbl_Phone);
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

        public ActionResult CustomerPhoneView()
        {
            return View(db.tbl_Phone.ToList());
        }
    }
}
