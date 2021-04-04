using RealEstatePro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
namespace RealEstatePro.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdvListesi(int page =1 )
        {
            var ads = db.Advertisements.Include(i => i.Neighborhood).Include(i => i.Type).ToList();

            return View(ads.ToPagedList(page , 2));
        }

    }
}