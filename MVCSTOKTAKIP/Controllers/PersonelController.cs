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
    public class PersonelController : Controller
    {
        // GET: Personel
        DBMVCSTOKEntities db = new DBMVCSTOKEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var personellist = db.TBL_Personel.ToList().ToPagedList(sayfa, 5);
            //var Personell = db.TBL_Personel.ToList();
            return View(personellist);
        }

        [HttpGet]
        public ActionResult YeniPersonel()
        {

            List<SelectListItem> dprtmn = (from x in db.TBL_Departman.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAD,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dprtmndrp = dprtmn;
            return View();
        }

        [HttpPost]
        public ActionResult YeniPersonel(TBL_Personel p)
        {
            var dprtmnd = db.TBL_Departman.Where(m => m.DepartmanID == p.TBL_Departman.DepartmanID).FirstOrDefault();
            p.TBL_Departman = dprtmnd;


            db.TBL_Personel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var prssl = db.TBL_Personel.Find(id);
            db.TBL_Personel.Remove(prssl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> depart = (from x in db.TBL_Departman.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAD,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.departdrp = depart;
            var prsnlgtr = db.TBL_Personel.Find(id);
            return View("PersonelGetir", prsnlgtr);
        }

        public ActionResult Guncelle(TBL_Personel p)
        {
            var prsnlgnc = db.TBL_Personel.Find(p.PersonelID);
            prsnlgnc.PersonelAD = p.PersonelAD;
            prsnlgnc.PersonelSOYAD = p.PersonelSOYAD;
            var dprt = db.TBL_Departman.Where(x => x.DepartmanID == p.TBL_Departman.DepartmanID).FirstOrDefault();
            prsnlgnc.Departman = dprt.DepartmanID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}