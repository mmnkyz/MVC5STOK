using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKTAKIP.Models.Entity;
using System.Web.Security;

namespace MVCSTOKTAKIP.Controllers
{
    public class LoginController : Controller
    {
        DBMVCSTOKEntities db = new DBMVCSTOKEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_Admin p)
        {
            var girisbilg = db.TBL_Admin.FirstOrDefault(m => m.KullaniciAD == p.KullaniciAD && m.Sifre == p.Sifre);
            if (girisbilg != null)
            {
                FormsAuthentication.SetAuthCookie(girisbilg.KullaniciAD, false);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}