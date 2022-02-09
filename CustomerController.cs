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
    public class CustomerController : Controller
    {
        private Entities db = new Entities();

        // GET: Customer
        public ActionResult Index()
        {
            return View(db.tbl_Customer.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Customer tbl_Customer = db.tbl_Customer.Find(id);
            if (tbl_Customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Address,PostCode,DateRegistered")] tbl_Customer tbl_Customer)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Customer.Add(tbl_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Customer tbl_Customer = db.tbl_Customer.Find(id);
            if (tbl_Customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Address,PostCode,DateRegistered")] tbl_Customer tbl_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Customer tbl_Customer = db.tbl_Customer.Find(id);
            if (tbl_Customer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Customer tbl_Customer = db.tbl_Customer.Find(id);
            db.tbl_Customer.Remove(tbl_Customer);
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

        // GET: Customer/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "CustomerID,FirstName,LastName,Address,PostCode,DateRegistered")] tbl_Customer tbl_Customer)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Customer.Add(tbl_Customer);
                db.SaveChanges();
                return RedirectToAction("RegistrationSuccess");
            }

            return View(tbl_Customer);
        }

        public ActionResult RegistrationSuccess()
        {
            return View();
        }

        public ActionResult CreditCheck()
        {
            return View();
        }

        public ActionResult CheckPerforming()
        {
            return View();

        }

        public ActionResult CheckCompleted()
        {
            return View();
        }
    }

}
