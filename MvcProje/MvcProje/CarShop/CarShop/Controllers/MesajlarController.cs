using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Controllers
{
    public class MesajlarController : Controller
    {
        CarShopEntities db = new CarShopEntities();
        // GET: Mesajlar
        public ActionResult Mesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Mesaj(string ad, string soyad, string telefon, string email, string mesaj)
        {
            Mesaj msj = new Mesaj();
            msj.Ad = ad;
            msj.Soyad = soyad;
            msj.Telefon = telefon;
            msj.Email = email;
            msj.Mesaj1 = mesaj;
            db.Mesaj.Add(msj);
            db.SaveChanges();
            Response.Redirect("/Home/");
            return View();
        }
    }
}