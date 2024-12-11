using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediTrack.Controllers
{
    [Authorize(Roles = "PAITENT")]
    public class PaitentController : Controller
    {
        // GET: Paitent
        public ActionResult Index()
        {
            return View();
        }
    }
}