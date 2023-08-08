using CarShop.Models;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        CarShopEntities db = new CarShopEntities();
        // GET: Home
        public ActionResult Index(int? page)
        {
            var urunlerr = db.Urun.Where(x => x.UrunId > 0).ToList().ToPagedList(page ?? 1, 8);
            return View(urunlerr);
        }
        
        public ActionResult UrunGetir()
        {
            var urunlerr = db.Urun.Where(x => x.UrunId > 0);
            return View(urunlerr);
        }
    }
}