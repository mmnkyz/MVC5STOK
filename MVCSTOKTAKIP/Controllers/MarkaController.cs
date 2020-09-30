using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKTAKIP.Models.Entity;

namespace MVCSTOKTAKIP.Controllers
{
    public class MarkaController : Controller
    {
        // GET: Marka

        DBMVCSTOKEntities db = new DBMVCSTOKEntities();
        [Authorize]
        public ActionResult Index()
        {
            var markal = db.TBL_Marka.ToList();
            return View(markal);
        }

        [HttpGet]
        public ActionResult YeniMarka()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMarka(TBL_Marka p)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMarka");
            }
            db.TBL_Marka.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var markasil = db.TBL_Marka.Find(id);
            db.TBL_Marka.Remove(markasil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MarkaGetir(int id)
        {
            var markagtr = db.TBL_Marka.Find(id);
            return View("MarkaGetir", markagtr);
        }

        public ActionResult MarkaGuncelle (TBL_Marka p)
        {
            var markagnc = db.TBL_Marka.Find(p.MarkaID);
            markagnc.MarkaAD = p.MarkaAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}