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
    public class ContractsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Contracts
        public ActionResult Index()
        {
            var tbl_Contracts = db.tbl_Contracts.Include(t => t.tbl_ContractDetails).Include(t => t.tbl_Customer).Include(t => t.tbl_Phone);
            return View(tbl_Contracts.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Contracts tbl_Contracts = db.tbl_Contracts.Find(id);
            if (tbl_Contracts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Contracts);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            ViewBag.ContractDetailsID = new SelectList(db.tbl_ContractDetails, "ContractDetailsID", "Data");
            ViewBag.CustomerID = new SelectList(db.tbl_Customer, "CustomerID", "FirstName");
            ViewBag.PhoneID = new SelectList(db.tbl_Phone, "PhoneID", "PhoneName");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractID,CustomerID,ContractDetailsID,PhoneID")] tbl_Contracts tbl_Contracts)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Contracts.Add(tbl_Contracts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContractDetailsID = new SelectList(db.tbl_ContractDetails, "ContractDetailsID", "Data", tbl_Contracts.ContractDetailsID);
            ViewBag.CustomerID = new SelectList(db.tbl_Customer, "CustomerID", "FirstName", tbl_Contracts.CustomerID);
            ViewBag.PhoneID = new SelectList(db.tbl_Phone, "PhoneID", "PhoneName", tbl_Contracts.PhoneID);
            return View(tbl_Contracts);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Contracts tbl_Contracts = db.tbl_Contracts.Find(id);
            if (tbl_Contracts == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractDetailsID = new SelectList(db.tbl_ContractDetails, "ContractDetailsID", "Data", tbl_Contracts.ContractDetailsID);
            ViewBag.CustomerID = new SelectList(db.tbl_Customer, "CustomerID", "FirstName", tbl_Contracts.CustomerID);
            ViewBag.PhoneID = new SelectList(db.tbl_Phone, "PhoneID", "PhoneName", tbl_Contracts.PhoneID);
            return View(tbl_Contracts);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractID,CustomerID,ContractDetailsID,PhoneID")] tbl_Contracts tbl_Contracts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Contracts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractDetailsID = new SelectList(db.tbl_ContractDetails, "ContractDetailsID", "Data", tbl_Contracts.ContractDetailsID);
            ViewBag.CustomerID = new SelectList(db.tbl_Customer, "CustomerID", "FirstName", tbl_Contracts.CustomerID);
            ViewBag.PhoneID = new SelectList(db.tbl_Phone, "PhoneID", "PhoneName", tbl_Contracts.PhoneID);
            return View(tbl_Contracts);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Contracts tbl_Contracts = db.tbl_Contracts.Find(id);
            if (tbl_Contracts == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Contracts);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Contracts tbl_Contracts = db.tbl_Contracts.Find(id);
            db.tbl_Contracts.Remove(tbl_Contracts);
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

        // GET: Contracts/Create
        public ActionResult CustomerCreateContract()
        {
            ViewBag.ContractDetailsID = new SelectList(db.tbl_ContractDetails, "ContractDetailsID", "Data");
            ViewBag.CustomerID = new SelectList(db.tbl_Customer, "CustomerID", "FirstName");
            ViewBag.PhoneID = new SelectList(db.tbl_Phone, "PhoneID", "PhoneName");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerCreateContract([Bind(Include = "ContractID,CustomerID,ContractDetailsID,PhoneID")] tbl_Contracts tbl_Contracts)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Contracts.Add(tbl_Contracts);
                db.SaveChanges();
                return RedirectToAction("CustomerContractCreationCompleted");
            }

            ViewBag.ContractDetailsID = new SelectList(db.tbl_ContractDetails, "ContractDetailsID", "Data", tbl_Contracts.ContractDetailsID);
            ViewBag.CustomerID = new SelectList(db.tbl_Customer, "CustomerID", "FirstName", tbl_Contracts.CustomerID);
            ViewBag.PhoneID = new SelectList(db.tbl_Phone, "PhoneID", "PhoneName", tbl_Contracts.PhoneID);
            return View(tbl_Contracts);
        }

        public ActionResult CustomerContractCreationCompleted()
        {
            return View();
        }

        public ActionResult CustomerIndex()
        {
            var tbl_Contracts = db.tbl_Contracts.Include(t => t.tbl_ContractDetails).Include(t => t.tbl_Customer).Include(t => t.tbl_Phone);
            return View(tbl_Contracts.OrderByDescending(x => x.ContractID).Take(1).ToList());
        }
    }
}
