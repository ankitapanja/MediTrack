using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MediTrack.Models;

namespace MediTrack.Models
{
    public class SecurityCredController : Controller
    {
        // GET: SecurityCred
        public ActionResult Login()
        {
            return View();
        }

        public  ActionResult Login(UserVeiwModel user)
        {
            if (ModelState.IsValid)
            {
                Models.ClinicoEntities1 _db = new Models.ClinicoEntities1();

                Models.Usertable usr = _db.Usertables.SingleOrDefault(dbusr => dbusr.Username.ToLower() == user.Username.ToLower() && dbusr.Password == user.Password);
                if (usr != null)
                {
                    FormsAuthentication.SetAuthCookie(usr.Username, false);
                    CurrentUserModel cusr = new CurrentUserModel();
                    cusr.Username = usr.Username;
                    cusr.UserId = usr.UserID;
                    cusr.Role = usr.Role;
                    cusr.ReferenceToID = usr.ReferenceToID;

                    if (usr.Role.ToUpper() == "PHYSICIAN")
                    {
                        var doc = _db.PhysicianTables.Find(usr.ReferenceToID);
                        cusr.Username = doc.Name;
                    }

                    if (usr.Role.ToUpper() == "PAITENT")
                    {
                        var ptn = _db.PaitentTables.Find(usr.ReferenceToID);
                        cusr.Username = ptn.PaitentName;

                    }

                    if (usr.Role.ToUpper() == "CHEMIST")
                    {
                        var chm = _db.ChemistTables.Find(usr.ReferenceToID);
                        cusr.Username = chm.Name;
                    }

                    if (usr.Role.ToUpper() == "SUPPLIER")
                    {
                        var sup = _db.SupplierTables.Find(usr.ReferenceToID);
                        cusr.Username = sup.Name;
                    }
                    if (usr.Role.ToUpper() == "ADMIN")
                    {
                        cusr.Username = "ADMIN";
                    }
                    Session["CurrentUser"] = cusr;
                    return RedirectToAction("Index", usr.Role);

                }
                
            }
            ModelState.AddModelError(" ", "invalid username or password");
            return View();

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }
    }
}