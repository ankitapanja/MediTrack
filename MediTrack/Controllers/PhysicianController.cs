using MediTrack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediTrack.Controllers
{
    [Authorize(Roles = "PHYSICIAN")]
    public class PhysicianController : Controller
    {
        public ClinicoEntities1 db = new ClinicoEntities1();
        // GET: Physician
        public ActionResult Index(int id)
        {
            return View();
        }


        [HttpPost]
        [Route("DrugRequest")]
        public ActionResult DrugRequest( int id)
        {
            DrugRequest request = db.DrugRequests.Find(id);
           
            if (request == null || string.IsNullOrEmpty(request.DrugInfo) )
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                request.PhysicianID = request.PhysicianID;
                request.ChemistID = request.ChemistID;


                // TODO: Add update logic here
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(new { message = "Drug request submitted successfully.", request });
        }

    }
}