using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediTrack.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                MediTrack.Models.CurrentUserModel usr = Session["CurrentUser"] as MediTrack.Models.CurrentUserModel;

                if (usr == null)
                {
                    MediTrack.Models.ClinicoEntities1 _db = new MediTrack.Models.ClinicoEntities1();

                    var usrdb = _db.Usertables.SingleOrDefault(dbusr => dbusr.Username.ToUpper() == User.Identity.Name);

                    if (usrdb != null)
                    {
                        usr = new MediTrack.Models.CurrentUserModel();
                        usr.Username = usrdb.Username;
                        usr.Password = usrdb.Password;
                        usr.UserId = usrdb.UserID;
                        usr.ReferenceToID = usrdb.ReferenceToID;
                        usr.Role = usrdb.Role;


                        if (usr.Role.ToUpper() == "PHYSICIAN")
                        {
                            var doc = _db.PhysicianTables.Find(usr.ReferenceToID);
                            usr.Username = doc.Name;
                        }

                        if (usr.Role.ToUpper() == "PAITENT")
                        {
                            var ptn = _db.PaitentTables.Find(usr.ReferenceToID);
                            usr.Username = ptn.PaitentName;

                        }

                        if (usr.Role.ToUpper() == "CHEMIST")
                        {
                            var chm = _db.ChemistTables.Find(usr.ReferenceToID);
                            usr.Username = chm.Name;
                        }

                        if (usr.Role.ToUpper() == "SUPPLIER")
                        {
                            var sup = _db.SupplierTables.Find(usr.ReferenceToID);
                            usr.Username = sup.Name;
                        }
                        if (usr.Role.ToUpper() == "ADMIN")
                        {
                            usr.Username = "ADMIN";
                        }
                        Session["CurrentUser"] = usr;
                        return RedirectToAction("Index", usr.Role);

                    }
                }

            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        
        }
    }

