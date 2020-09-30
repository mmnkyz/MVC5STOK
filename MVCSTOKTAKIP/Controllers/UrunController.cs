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
    public class UrunController : Controller
    {
        // GET: Urun
        DBMVCSTOKEntities db = new DBMVCSTOKEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var urunlist = db.TBL_Urunler.Where(m => m.DURUM == true).ToList().ToPagedList(sayfa, 5);

            //var urunl = db.TBL_Urunler.Where(m => m.DURUM == true).ToList();
            return View(urunlist);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktgrd = (from x in db.TBL_Kategori.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAD,
                                              Value = x.KategoriID.ToString()
                                          }).ToList();
            ViewBag.urundrop = ktgrd;

            List<SelectListItem> mrkd = (from x in db.TBL_Marka.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.MarkaAD,
                                             Value = x.MarkaID.ToString()
                                         }).ToList();
            ViewBag.markadrop = mrkd;

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBL_Urunler p)
        {
            var ktgr = db.TBL_Kategori.Where(x => x.KategoriID == p.TBL_Kategori.KategoriID).FirstOrDefault();
            var mrk = db.TBL_Marka.Where(x => x.MarkaID == p.TBL_Marka.MarkaID).FirstOrDefault();
            p.TBL_Kategori = ktgr;
            p.TBL_Marka = mrk;
            db.TBL_Urunler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
            //db.TBL_Urunler.Add(p);
            //db.SaveChanges();
            //return RedirectToAction("Index");
        }

        public ActionResult sil(int id)
        {
            var urunsil = db.TBL_Urunler.Find(id);
            db.TBL_Urunler.Remove(urunsil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> mrkd = (from x in db.TBL_Marka.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.MarkaAD,
                                             Value = x.MarkaID.ToString()
                                         }).ToList();

            List<SelectListItem> ktgrd = (from x in db.TBL_Kategori.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAD,
                                              Value = x.KategoriID.ToString()
                                          }
                                        ).ToList();
            ViewBag.mrkdrp = mrkd;
            ViewBag.ktgrdrp = ktgrd;
            var urungtr = db.TBL_Urunler.Find(id);
            return View("UrunGetir", urungtr);
        }
        public ActionResult UrunGuncelle(TBL_Urunler p1)
        {

            var urungncl = db.TBL_Urunler.Find(p1.UrunID);
            urungncl.UrunAD = p1.UrunAD;
            var urngnc = db.TBL_Marka.Where(x => x.MarkaID == p1.TBL_Marka.MarkaID).FirstOrDefault();
            urungncl.MARKA = urngnc.MarkaID;
            urungncl.STOK = p1.STOK;
            urungncl.ALISF = p1.ALISF;
            urungncl.SATISF = p1.SATISF;
            var ktggnc = db.TBL_Kategori.Where(x => x.KategoriID == p1.TBL_Kategori.KategoriID).FirstOrDefault();
            urungncl.KATEGORI = ktggnc.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urunbul = db.TBL_Urunler.Find(id);
            urunbul.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}