using RealEstatePro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstatePro.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();


        // GET: Home
         public ActionResult Index()
        {
            var imgs = db.AdvPhotos.ToList();
            ViewBag.imgs = imgs;

            var adv = db.Advertisements.Include(m => m.Neighborhood).Include(e => e.Type);
            ModelState.Clear();
            return View(adv.ToList());
        }
        public ActionResult Details(int id)
        {
            var adv = db.Advertisements.Where(i => i.AdvId == id).Include(m => m.Neighborhood).Include(e => e.Type).FirstOrDefault();
            var imgs = db.AdvPhotos.Where(i => i.AdvId == id).ToList();
            ViewBag.imgs = imgs;
            return View(adv);

        }
    }
}