//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace MediTrack.Controllers
//{
//    [Authorize(Roles = "SUPPLIER")]
//    public class SupplierController : Controller
//    {
//        // GET: Supplier
//        public ActionResult Index()
//        {
//            return View();
//        }
//        public ActionResult Supl
//    }
//}

using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using MediTrack.Models; 

namespace MediTrack.Controllers
{
    [Authorize(Roles = "SUPPILER")]
    public class SupplierController : Controller
    {
        private  ClinicoEntities1 db = new  ClinicoEntities1();
      
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("ViewRequest")]
        public ActionResult RequestReceived(int id, ActionResult orders)
        {
            try
            {
                // Fetch orders only for the specific chemist
                var requests = db.POHeaders
                    .Where(or => or.POID == id)
                    .Include(dr => dr.SupplierID)
                    .ToList();

                return orders;
            }
            catch (Exception ex)
            {
                return HttpStatusCodeResult(500, $"Internal server error: {ex.Message}");
            }
        }

        private ActionResult HttpStatusCodeResult(int id, string v)
        {
            throw new NotImplementedException();
        }


        // GET: Supplier/RequestsReceived
        public ActionResult ViewRequest(int id)
        {
            
            var requests = db.POHeaders
                .Include(r => r.POID)
                
                .Where(r => r.SupplierID == id)
                .ToList();

            return View(requests);
        }

        // GET: Supplier/RequestsSent
        
        private int GetCurrentUserId() 
        { 
                 return int.Parse(User.Identity.Name);
        }
    }
}

