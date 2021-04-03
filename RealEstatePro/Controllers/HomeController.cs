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

        public ActionResult MenuFilter(int id)
        {
            var imgs = db.AdvPhotos.ToList();
            ViewBag.imgs = imgs;
            var filter = db.Advertisements.Where(i => i.TypeId ==id).Include(m => m.Neighborhood).Include(e => e.Type).ToList();
            return View(filter);
        }

        public PartialViewResult PartialFilter()
        {
            ViewBag.citylist = new SelectList(CityGet(), "CityId", "CityName");
            ViewBag.statuslist = new SelectList(statusGet(), "StatusId", "StatusName");
            return PartialView();

        }
        public ActionResult Filter(int? min , int? max , int? cityid , int? districtid , int? nghdid , int?  stautsid , int? typeid )
        {
            var imgs = db.AdvPhotos.ToList();
            ViewBag.imgs = imgs;
            var filter = db.Advertisements.Where(x => x.Price >= min || x.Price <= max
            || x.CityId == cityid
            || x.DistrictId == districtid
            || x.NeighborhoodId == nghdid
            || x.StatusId == stautsid
            || x.TypeId == typeid).Include(m => m.Neighborhood).Include(e => e.Type).ToList();

            return View(filter);

        }
        public List<City> CityGet()
        {
            List<City> cities = db.Cities.ToList();
            return cities;
        }
        public ActionResult DistrictGet(int CityId)
        {
            List<District> districtlist = db.Districts.Where(x => x.CityId == CityId).ToList();
            ViewBag.districtListesi = new SelectList(districtlist, "DistrictId", "DistrictName");

            return PartialView("DistrictPartial");
        }

        public ActionResult NgbhdGet(int districtid)
        {
            List<Neighborhood> neighborhoodlist = db.Neighborhoods.Where(x => x.DistrictId == districtid).ToList();
            ViewBag.nghbdlistesi = new SelectList(neighborhoodlist, "NeighborhoodId", "NeighborhoodName");

            return PartialView("NgbhdPartial");
        }

        public List<Status> statusGet()
        {
            List<Status> statuses = db.Statuses.ToList();
            return statuses;
        }
        public ActionResult typeGet(int statusid)
        {
            // because status sub table of Type 
            List<Models.Type> typelist = db.Types.Where(x => x.StatusId == statusid).ToList();
            ViewBag.typelistesi = new SelectList(typelist, "TypeId", "TypeName");


            return PartialView("TypePartial");
        }

        public ActionResult Search(string s)
        {
            var imgs = db.AdvPhotos.ToList();
            ViewBag.imgs = imgs;
            var search = db.Advertisements.Include(m => m.Neighborhood).Include(e => e.Type);
            if (!string.IsNullOrEmpty(s))
            {
                search = search.Where(i => i.Description.Contains(s) || i.Neighborhood.NeighborhoodName.Contains(s)
                || i.Neighborhood.District.City.CityName.Contains(s));
            }

            return View(search.ToList());
        }

        public ActionResult DetailsOfCity(int id)
        {
            var doc = db.Cities.Where(i => i.CityId == id).FirstOrDefault();           
            return View(doc);
        }
        public ActionResult Details(int id)
        {
            var adv = db.Advertisements.Where(i => i.AdvId == id).Include(m => m.Neighborhood).Include(e => e.Type).FirstOrDefault();
            var imgs = db.AdvPhotos.Where(i => i.AdvId == id).ToList();
            ViewBag.imgs = imgs;
            return View(adv);

        }
        public PartialViewResult Slider()
        {
            var adv = db.Advertisements.ToList().Take(5);
            var imgs = db.AdvPhotos.ToList();
            ViewBag.imgs = imgs;
            return PartialView(adv);
        }
    }
}




//The first commit before this commit  was uploaded after adding the Get file, and before uploading
//i had added the following elements:
// Project's Files : 
// 1-index page with slider 
// 2- details page  with slider 
// 3- Models ( Advertisement , AdvPhoto , City , District, Neighborhood, Status , Type  )
// 4- other classes (DataContext , DataInitializer , Database connection )
// 5- Content bootstrap , Css , js 
//This Commit is only for writing the project sections .