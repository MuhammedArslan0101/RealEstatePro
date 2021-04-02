using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealEstatePro.Models;
using RealEstatePro.Models;
using Type = RealEstatePro.Models.Type;

namespace RealEstatePro.Controllers
{
    public class AdvertisementController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Advertisement
        public ActionResult Index()
        {
            var advertisements = db.Advertisements.Include(a => a.Neighborhood).Include(a => a.Type);
            return View(advertisements.ToList());
        }

        public List<City> CityGet()
        {
            List<City> cities = db.Cities.ToList();
            return cities;
        }
        public ActionResult DistrictGet( int CityId)
        {
            List<District> districtlist = db.Districts.Where(x => x.CityId == CityId).ToList();
            ViewBag.districtListesi = new SelectList(districtlist, "DistrictId", "DistrictName");

            return PartialView ("DistrictPartial");
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
            List<Type> typelist = db.Types.Where(x => x.StatusId == statusid).ToList();
            ViewBag.typelistesi = new SelectList(typelist, "TypeId", "TypeName");


            return PartialView("TypePartial");
        }

        // GET: Advertisement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // GET: Advertisement/Create
        public ActionResult Create()
        {
            //for list city and district to create page
            ViewBag.citylist = new SelectList(CityGet(), "CityId", "CityName");

            ViewBag.statuslist = new SelectList(statusGet(), "StatusId", "StatusName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdvId,Description,Price,NumOfRoom,NumOfBath,Credit,Area,Floor,Feature,Telephone,Addres,UserName,CityId,DistrictId,StatusId,NeighborhoodId,TypeId")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                advertisement.UserName = User.Identity.Name; 
                db.Advertisements.Add(advertisement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //for list city and district to create page
            ViewBag.citylist = new SelectList(CityGet(), "CityId", "CityName");

            ViewBag.statuslist = new SelectList(statusGet(), "StatusId", "StatusName");
            return View(advertisement);
        }

        // GET: Advertisement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "NeighborhoodId", "NeighborhoodName", advertisement.NeighborhoodId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "TypeName", advertisement.TypeId);
            return View(advertisement);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdvId,Description,Price,NumOfRoom,NumOfBath,Credit,Area,Floor,Feature,Telephone,Addres,UserName,CityId,DistrictId,StatusId,NeighborhoodId,TypeId")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertisement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NeighborhoodId = new SelectList(db.Neighborhoods, "NeighborhoodId", "NeighborhoodName", advertisement.NeighborhoodId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "TypeName", advertisement.TypeId);
            return View(advertisement);
        }

        // GET: Advertisement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // POST: Advertisement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertisement advertisement = db.Advertisements.Find(id);
            db.Advertisements.Remove(advertisement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
