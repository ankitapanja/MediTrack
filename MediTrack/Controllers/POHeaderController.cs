using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediTrack.Models;

namespace MediTrack.Controllers
{
    public class POHeaderController : Controller
    {
        private ClinicoEntities1 db = new ClinicoEntities1();

        // GET: POHeader
        public ActionResult Index()
        {
            var pOHeaders = db.POHeaders.Include(p => p.SupplierTable);
            return View(pOHeaders.ToList());
        }

        public ActionResult ProductLine()
        {
            return PartialView();
        }

        // GET: POHeader/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POHeader pOHeader = db.POHeaders.Find(id);
            if (pOHeader == null)
            {
                return HttpNotFound();
            }
            return View(pOHeader);
        }

        // GET: POHeader/Create
        public ActionResult Create()
        {
            ViewBag.SupplierID = new SelectList(db.SupplierTables, "SupplierID", "Name");
            return View();
        }

        // POST: POHeader/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "POID,PODate,SupplierID,Description")] POHeader pOHeader)
        {
            if (ModelState.IsValid)
            {
                db.POHeaders.Add(pOHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierID = new SelectList(db.SupplierTables, "SupplierID", "Name", pOHeader.SupplierID);
            return View(pOHeader);
        }

        // GET: POHeader/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POHeader pOHeader = db.POHeaders.Find(id);
            if (pOHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierID = new SelectList(db.SupplierTables, "SupplierID", "Name", pOHeader.SupplierID);
            return View(pOHeader);
        }

        // POST: POHeader/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "POID,PODate,SupplierID,Description")] POHeader pOHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierID = new SelectList(db.SupplierTables, "SupplierID", "Name", pOHeader.SupplierID);
            return View(pOHeader);
        }

        // GET: POHeader/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POHeader pOHeader = db.POHeaders.Find(id);
            if (pOHeader == null)
            {
                return HttpNotFound();
            }
            return View(pOHeader);
        }

        // POST: POHeader/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POHeader pOHeader = db.POHeaders.Find(id);
            db.POHeaders.Remove(pOHeader);
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
