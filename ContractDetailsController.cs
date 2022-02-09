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
    public class ContractDetailsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: ContractDetails
        public ActionResult Index()
        {
            return View(db.tbl_ContractDetails.ToList());
        }

        // GET: ContractDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ContractDetails tbl_ContractDetails = db.tbl_ContractDetails.Find(id);
            if (tbl_ContractDetails == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ContractDetails);
        }

        // GET: ContractDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContractDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractDetailsID,Data,Minutes,Texts")] tbl_ContractDetails tbl_ContractDetails)
        {
            if (ModelState.IsValid)
            {
                db.tbl_ContractDetails.Add(tbl_ContractDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_ContractDetails);
        }

        // GET: ContractDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ContractDetails tbl_ContractDetails = db.tbl_ContractDetails.Find(id);
            if (tbl_ContractDetails == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ContractDetails);
        }

        // POST: ContractDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractDetailsID,Data,Minutes,Texts")] tbl_ContractDetails tbl_ContractDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ContractDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_ContractDetails);
        }

        // GET: ContractDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ContractDetails tbl_ContractDetails = db.tbl_ContractDetails.Find(id);
            if (tbl_ContractDetails == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ContractDetails);
        }

        // POST: ContractDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ContractDetails tbl_ContractDetails = db.tbl_ContractDetails.Find(id);
            db.tbl_ContractDetails.Remove(tbl_ContractDetails);
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

        public ActionResult CustomerContractDetailView()
        {
            return View(db.tbl_ContractDetails.ToList());
        }
    }
}
