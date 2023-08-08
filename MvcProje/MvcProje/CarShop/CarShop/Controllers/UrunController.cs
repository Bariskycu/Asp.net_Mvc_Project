using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace CarShop.Controllers
{
    public class UrunController : Controller
    {
        CarShopEntities db = new CarShopEntities();
        // GET: Urun
        public ActionResult Audi(int? page)
        {
            return View(db.Urun.Where(x => x.Kategori == 1).ToList().ToPagedList(page ?? 1, 8));
        }
        public ActionResult Wolksvagen(int? page)
        {
            return View(db.Urun.Where(x => x.Kategori == 2).ToList().ToPagedList(page ?? 1, 8));
        }
        public ActionResult Kia(int? page)
        {
            return View(db.Urun.Where(x => x.Kategori == 3).ToList().ToPagedList(page ?? 1, 8));
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detay(int id)
        {
            return View(db.Urun.FirstOrDefault(x => x.UrunId == id));
        }
        public ActionResult SatinAl(string id)
        {
            return View(db.Urun.FirstOrDefault(x => x.Baslik == id));
        }
        [HttpPost]
        public ActionResult SatinAl(string arac, string ad, string soyad, string telefon, string email,string mesaj)
        {
                AracTalip ms = new AracTalip();
                ms.Arac = arac;
                ms.Ad = ad;
                ms.Soyad = soyad;
                ms.Telefon = telefon;
                ms.Email = email;
                ms.Mesaj = mesaj;
                db.AracTalip.Add(ms);
                db.SaveChanges();
                return Redirect("/Home/");
            
        }
    }
}