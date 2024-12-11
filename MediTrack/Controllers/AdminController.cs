using MediTrack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;


namespace MediTrack.Controllers
{
    public class AdminController : Controller
    {
        private ClinicoEntities1 db = new ClinicoEntities1();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Paitents
        public ActionResult PaitentIndex()
        {
            return View(db.PaitentTables.ToList());
        }


        // GET: Paitents/Create
        public ActionResult PaitentCreate()
        {
            return View();
        }

        // POST: Paitents/Create
        [HttpPost]
        public ActionResult PaitentCreate(PaitentTable paitent)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                db.PaitentTables.Add(paitent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paitent);
        }

        // GET: Paitents/Edit/5
        public ActionResult PaitentEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaitentTable paitent = db.PaitentTables.Find(id);
            if (paitent == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Paitents/Edit/5
        [HttpPost]
        public ActionResult PaitentEdit(PaitentTable paitent)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                db.Entry(paitent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paitent);
        }

        // GET: Paitents/Delete/5
        public ActionResult PaitentDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.PaitentTable paitent = db.PaitentTables.Find(id);
            if (paitent == null)
            {
                return HttpNotFound();
            }
            return View(paitent);
        }

        // POST: Paitents/Delete/5
        [HttpPost]
        public ActionResult PaitentDelete(int id, PaitentTable paitent)
        {


            // TODO: Add delete logic here
            db.PaitentTables.Add(paitent);
            db.PaitentTables.Remove(paitent);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult PhysicianIndex()
        {
            return View(db.PhysicianTables.ToList());
        }

        [HttpPost]

        // GET: Physicians/Create
        public ActionResult PhysicianCreate()
        {
            return View();
        }

        // POST: Physicians/Create
        [HttpPost]
        public ActionResult PhysicianCreate(PhysicianTable physician)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                db.PhysicianTables.Add(physician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Physicians/Edit/5
        public ActionResult PhysicianEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicianTable physician = db.PhysicianTables.Find(id);
            if (physician == null)
            {
                return HttpNotFound();
            }
            return View(physician);
        }

        // POST: Physicians/Edit/5
        [HttpPost]
        public ActionResult PhysicianEdit(PhysicianTable physician)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                db.Entry(physician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Physicians/Delete/5
        public ActionResult PhysicianDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicianTable physician = db.PhysicianTables.Find(id);
            if (physician == null)
            {
                return HttpNotFound();
            }
            return View(physician);
        }

        // POST: Physicians/Delete/5
        [HttpPost]
        public ActionResult PhysicianDelete(int id)
        {
            PhysicianTable physician = db.PhysicianTables.Find(id);
            db.PhysicianTables.Remove(physician);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult ChemistIndex(ChemistTable chemist)
        {
            var chemists = db.ChemistTables.ToList();
            return View(chemists);
        }

        // GET: Chemist/Details/5
        public ActionResult ChemistDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChemistTable chemist = db.ChemistTables.Find(id);
            if (chemist == null)
            {
                return HttpNotFound();
            }
            return View(chemist);
        }

        // GET: Chemist/Create
        public ActionResult ChemistCreate(int id)
        {
            return View();
        }

        // POST: Chemist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChemistCreate([Bind(Include = "ChemistID,ChemistName,ContactNumber,Email,ShopAddress")] ChemistTable chemist)
        {
            if (ModelState.IsValid)
            {
                db.ChemistTables.Add(chemist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chemist);
        }

        // GET: Chemist/Edit/5
        public ActionResult ChemistEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChemistTable chemist = db.ChemistTables.Find(id);
            if (chemist == null)
            {
                return HttpNotFound();
            }
            return View(chemist);
        }

        // POST: Chemist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChemistEdit([Bind(Include = "ChemistID,ChemistName,ContactNumber,Email,ShopAddress")] ChemistTable chemist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chemist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chemist);
        }

        // GET: Chemist/Delete/5
        public ActionResult ChemistDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChemistTable chemist = db.ChemistTables.Find(id);
            if (chemist == null)
            {
                return HttpNotFound();
            }
            return View(chemist);
        }

        // POST: Chemist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ChemistDeleteConfirmed(int id)
        {
            ChemistTable chemist = db.ChemistTables.Find(id);
            db.ChemistTables.Remove(chemist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SupplierIndex()
        {
            var suppliers = db.SupplierTables.ToList();
            return View(suppliers);
        }

        // GET: Supplier/Details/5
        public ActionResult SupplierDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierTable supplier = db.SupplierTables.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Supplier/Create
        public ActionResult SupplierCreate(int? id)
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SupplierCreate([Bind(Include = "SupplierID,SupplierName,ContactNumber,Email,Address")] SupplierTable supplier)
        {
            if (ModelState.IsValid)
            {
                db.SupplierTables.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Supplier/Edit/5
        public ActionResult SupplierEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierTable supplier = db.SupplierTables.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SupplierEdit([Bind(Include = "SupplierID,SupplierName,ContactNumber,Email,Address")] SupplierTable supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Supplier/Delete/5
        public ActionResult SupplierDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierTable supplier = db.SupplierTables.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult SupplierDeleteConfirmed(int id)
        {
            SupplierTable supplier = db.SupplierTables.Find(id);
            db.SupplierTables.Remove(supplier);
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

        

    
        
    
