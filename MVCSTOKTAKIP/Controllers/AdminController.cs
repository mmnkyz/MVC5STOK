using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKTAKIP.Models.Entity;

namespace MVCSTOKTAKIP.Controllers
{
    public class AdminController : Controller
    {
        DBMVCSTOKEntities db = new DBMVCSTOKEntities();
        [Authorize]
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniAdmin(TBL_Admin p)
        {
            if(!ModelState.IsValid)
            {
                return View("Index");
            }
            db.TBL_Admin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}