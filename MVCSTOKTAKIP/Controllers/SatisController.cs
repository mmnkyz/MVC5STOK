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
    public class SatisController : Controller
    {
        // GET: Satis
        DBMVCSTOKEntities db = new DBMVCSTOKEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var satislist = db.TBL_Satis.ToList().ToPagedList(sayfa, 5);

            //var satisl = db.TBL_Satis.ToList();
            return View(satislist);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            //Ürün listeleme 
            List<SelectListItem> urun = (from x in db.TBL_Urunler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAD,
                                             Value = x.UrunID.ToString()
                                         }).ToList();
            ViewBag.urundrp = urun;

            //Personel Listeleme
            List<SelectListItem> prsnl = (from x in db.TBL_Personel.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.PersonelAD + " " + x.PersonelSOYAD,
                                              Value = x.PersonelID.ToString(),
                                          }).ToList();
            ViewBag.prsnldrp = prsnl;

            //Müşteri Listeleme
            List<SelectListItem> mstr = (from x in db.TBL_Musteri.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.MusteriAD + " " + x.MusteriSOYAD,
                                             Value = x.MusteriID.ToString()
                                         }).ToList();
            ViewBag.mstrdrp = mstr;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBL_Satis p)
        {
            var urn = db.TBL_Urunler.Where(x => x.UrunID == p.TBL_Urunler.UrunID).FirstOrDefault();
            var prs = db.TBL_Personel.Where(x => x.PersonelID == p.TBL_Personel.PersonelID).FirstOrDefault();
            var mst = db.TBL_Musteri.Where(x => x.MusteriID == p.TBL_Musteri.MusteriID).FirstOrDefault();
            p.TBL_Urunler = urn;
            p.TBL_Personel = prs;
            p.TBL_Musteri = mst;
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_Satis.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
            //db.TBL_Satis.Add(p);
            //db.SaveChanges();
            //return RedirectToAction("Index");
        }

        public ActionResult sil(int id)
        {
            var satissil = db.TBL_Satis.Find(id);
            db.TBL_Satis.Remove(satissil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir (int id)
        {
            //Ürün Getirme 
            List<SelectListItem> urun = (from x in db.TBL_Urunler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAD,
                                             Value = x.UrunID.ToString()
                                         }).ToList();
            ViewBag.urundrp = urun;

            //Personel Getirme
            List<SelectListItem> prsnl = (from x in db.TBL_Personel.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.PersonelAD + " " + x.PersonelSOYAD,
                                              Value = x.PersonelID.ToString(),
                                          }).ToList();
            ViewBag.prsnldrp = prsnl;

            //Müşteri Getirme
            List<SelectListItem> mstr = (from x in db.TBL_Musteri.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.MusteriAD + " " + x.MusteriSOYAD,
                                             Value = x.MusteriID.ToString()
                                         }).ToList();
            ViewBag.mstrdrp = mstr;
            var satirgtr = db.TBL_Satis.Find(id);
            return View("SatisGetir", satirgtr);
        }

        public ActionResult Guncelle(TBL_Satis p)
        {
            var satisgnc = db.TBL_Satis.Find(p.SatisID);
            var urngnc = db.TBL_Urunler.Where(x => x.UrunID == p.TBL_Urunler.UrunID).FirstOrDefault();
            satisgnc.Urun = urngnc.UrunID;
            var prsgnc = db.TBL_Personel.Where(x => x.PersonelID == p.TBL_Personel.PersonelID).FirstOrDefault();
            satisgnc.Personel = prsgnc.PersonelID;
            var mstgnc = db.TBL_Musteri.Where(x => x.MusteriID == p.TBL_Musteri.MusteriID).FirstOrDefault();
            satisgnc.Musteri = mstgnc.MusteriID;
            satisgnc.Fiyat = p.Fiyat;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}