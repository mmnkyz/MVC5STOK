using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKTAKIP.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCSTOKTAKIP.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DBMVCSTOKEntities db = new DBMVCSTOKEntities();
        [Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            var musteriliste = db.TBL_Musteri.Where(m => m.DURUM == true).ToList().ToPagedList(sayfa, 5);
            //var mstrl = db.TBL_Musteri.ToList();
            return View(musteriliste);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBL_Musteri p)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBL_Musteri.Add(p);
            p.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(int id)
        {
            var musteribul = db.TBL_Musteri.Find(id);
            musteribul.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult MusteriGetir(int id)
        {
            var musget = db.TBL_Musteri.Find(id);
            return View("MusteriGetir", musget);
        }
        public ActionResult MusteriGuncelle(TBL_Musteri p)
        {
            var musgncl = db.TBL_Musteri.Find(p.MusteriID);
            musgncl.MusteriAD = p.MusteriAD;
            musgncl.MusteriSOYAD = p.MusteriSOYAD;
            musgncl.Sehir = p.Sehir;
            musgncl.Bakiye = p.Bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}