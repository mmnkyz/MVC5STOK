using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKTAKIP.Models.Entity;

namespace MVCSTOKTAKIP.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        DBMVCSTOKEntities db = new DBMVCSTOKEntities();
        [Authorize]
        public ActionResult Index()
        {
            var departl = db.TBL_Departman.ToList();
            return View(departl);
        }

        [HttpGet]
        public ActionResult YeniDepartman()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDepartman(TBL_Departman p)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniDepartman");
            }
            db.TBL_Departman.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var departsl = db.TBL_Departman.Find(id);
            db.TBL_Departman.Remove(departsl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departgtr = db.TBL_Departman.Find(id);
            return View("DepartmanGetir", departgtr);
        }

        public ActionResult DepartmanGuncelle (TBL_Departman p)
        {
            var departgnc = db.TBL_Departman.Find(p.DepartmanID);
            departgnc.DepartmanAD = p.DepartmanAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}