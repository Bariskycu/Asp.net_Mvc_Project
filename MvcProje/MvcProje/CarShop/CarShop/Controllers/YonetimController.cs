using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace CarShop.Controllers
{
    public class YonetimController : Controller
    {
        CarShopEntities db = new CarShopEntities();
        // GET: Yonetim
        public ActionResult Mesaj()
        {
            return View(db.Mesaj.ToList());
        }

        public ActionResult AraçTalepleri()
        {
            return View(db.AracTalip.ToList());
        }

        public ActionResult HesapAc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HesapAc(FormCollection form)
        {
            Giris grs = new Giris();
            grs.Ad = form["Ad"].Trim();
            grs.Soyad = form["Soyad"].Trim();
            grs.Email = form["Email"].Trim();
            grs.KullaniciAdi = form["KullaniciAdi"].Trim();
            grs.Sifre = form["Sifre"].Trim();
            db.Giris.Add(grs);
            db.SaveChanges();
            Response.Redirect("/");
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string id, string pass)
        {
            var deger = db.Giris.Where(x => x.KullaniciAdi == id && x.Sifre == pass).FirstOrDefault();
            if (deger != null)
            {
                Response.Redirect("Yonetim");
            }
            else
            {
                ViewBag.Message = "Kullanıcı Adı ve Şifre Uyuşmuyor";
                //Response.Redirect("/");
            }
            return View();
        }

        public ActionResult Yonetim(int? page)
        {
            return View(db.Urun.ToList());
        }

        string ResimKaydet(HttpPostedFileBase file)
        {
            Image orj = Image.FromStream(file.InputStream);
            string yol = Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid() + Path.GetExtension(file.FileName);
            orj.Save(Server.MapPath("~/Content/images/" + yol));
            return yol;
        }
        [HttpPost]
        public ActionResult Create(Urun urun, HttpPostedFileBase resim, IEnumerable<HttpPostedFileBase> resimlerrr)
        {
            string yolunyolu = ResimKaydet(resim);
            urun.ResimYol = "/Content/images/" + yolunyolu;
            Random rnd = new Random();
            urun.ResimId = rnd.Next();
            Resimler rsm = new Resimler();
            foreach (var item in resimlerrr)
            {
                string cyoll = ResimKaydet(item);
                rsm.ResimYolu = "/Content/images/" + cyoll;
                rsm.ResimId = urun.ResimId;
                db.Resimler.Add(rsm);
                db.SaveChanges();
            }

            db.Urun.Add(urun);
            db.SaveChanges();
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrunId,Baslik,ResimYol,Fiyat,Marka,Model,Yakit,Vites,KasaTipi,Renk,Kategori,ResimId")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/Yonetim/Yonetim");
            }
            return View(urun);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urun students = db.Urun.Find(id);
            db.Urun.Remove(students);
            db.SaveChanges();
            return RedirectToAction("/Yonetim/Yonetim");
        }

        public ActionResult MesajDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesaj mesaj = db.Mesaj.Find(id);
            if (mesaj == null)
            {
                return HttpNotFound();
            }
            return View(mesaj);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("MesajDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult MesajDeleteConfirmed(int id)
        {
            Mesaj mesaj = db.Mesaj.Find(id);
            db.Mesaj.Remove(mesaj);
            db.SaveChanges();
            return RedirectToAction("/Yonetim/Mesaj");
        }

        public ActionResult TalepDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracTalip talip = db.AracTalip.Find(id);
            if (talip == null)
            {
                return HttpNotFound();
            }
            return View(talip);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("TalepDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult TalipDeleteConfirmed(int id)
        {
            AracTalip talip = db.AracTalip.Find(id);
            db.AracTalip.Remove(talip);
            db.SaveChanges();
            return RedirectToAction("/Yonetim/AraçTalepleri/");
        }
    }
}