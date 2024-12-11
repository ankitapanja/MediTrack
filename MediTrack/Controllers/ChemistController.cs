using MediTrack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediTrack.Controllers
{
    [Authorize(Roles = "CHEMIST")]
    public class ChemistController : Controller
    {
        public ClinicoEntities1 db = new ClinicoEntities1();

        // GET: Chemist
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("ViewOrders")]
        public ActionResult ViewOrders(int id)
        {
            try
            {
              
                var requests = db.DrugRequests
                    .Where(dr => dr.PhysicianID == id &&
                                 (dr.Status == "Pending" || dr.Status == "Done" || dr.Status == "Ongoing"))
                    .Include(dr => dr.PhysicianTable)
                    .ToList();

                return View(requests);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult GetDrugRequest()
        {
            ViewBag.Physicians = db.PhysicianTables.Where(u => u.Role == "PHYSICIAN").ToList();
            ViewBag.Drugs = db.DrugTables.ToList();
            return View();
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetDrugRequest(DrugRequest drugRequest, int name)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Physicians = db.PhysicianTables.Where(u => u.Role == "PHYSICIAN").ToList();
                    ViewBag.Drugs = db.DrugTables.ToList();
                    return View(drugRequest);
                }

                drugRequest.RequestDate = DateTime.Now;
                drugRequest.Status = "Pending";
               // drugRequest.RequestBy = phy ;    
                db.DrugRequests.Add(drugRequest);
                db.SaveChanges();

                return RedirectToAction("ViewOrders", new { id = drugRequest.PhysicianID });
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, $"Internal server error: {ex.Message}");
            }
        }

        public ActionResult CreatePO()
        {
            ViewBag.SupplierID = new SelectList(db.SupplierTables, "supplierID", "name");


            ViewBag.Drugs = db.DrugTables.ToList();



            POHeader header = new POHeader();
            header.PODate = DateTime.Now;

            header.PODrugLines.Add(new PODrugLine());


            return View(header);
        }
        [HttpPost]
        public ActionResult CreatePO(Models.POHeader POHeader)
        {

            POHeader.SupplierTable = db.SupplierTables.Find(POHeader.SupplierID);


            foreach (var DrgLn in POHeader.PODrugLines)
            {
                DrgLn.DrugTable = db.DrugTables.Find(DrgLn.DrugID);

            }

            db.POHeaders.Add(POHeader);
            db.SaveChanges();

            ViewBag.SupplierID = new SelectList(db.SupplierTables, "SupplierID", "Name");


            ViewBag.Drugs = db.DrugTables.ToList();
            POHeader header = new POHeader();
            header.PODate = DateTime.Now;

            header.PODrugLines.Add(new PODrugLine());
            return View(header);
        }

        public ActionResult CreateProductLine(string id)
        {
            ViewBag.slno = id;
            return PartialView();
        }




    }
}
