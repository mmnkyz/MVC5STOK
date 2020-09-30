using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOKTAKIP.Models.Entity;

namespace MVCSTOKTAKIP.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBMVCSTOKEntities db = new DBMVCSTOKEntities();
        [Authorize]
        public ActionResult Index()
        {
            var ktgrl = db.TBL_Kategori.ToList();
            return View(ktgrl);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBL_Kategori p)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBL_Kategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ktgrsil = db.TBL_Kategori.Find(id);
            db.TBL_Kategori.Remove(ktgrsil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgrgtr = db.TBL_Kategori.Find(id);
            return View("KategoriGetir", ktgrgtr);
        }

        public ActionResult KategoriGuncelle(TBL_Kategori p)
        {
            var ktgrgnc = db.TBL_Kategori.Find(p.KategoriID);
            ktgrgnc.KategoriAD = p.KategoriAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}