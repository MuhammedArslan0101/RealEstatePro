using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealEstatePro.Models;

namespace RealEstatePro.Controllers
{
    public class FooterLinkController : Controller
    {
        private DataContext db = new DataContext();

        // GET: FooterLink
        public ActionResult Index()
        {
            return View(db.foterLinks.ToList());
        }

        public PartialViewResult getfooterlink ()
        {
            var footerlink = db.foterLinks.ToList();

            return PartialView(footerlink);
        }
        // GET: FooterLink/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterLink footerLink = db.foterLinks.Find(id);
            if (footerLink == null)
            {
                return HttpNotFound();
            }
            return View(footerLink);
        }

        // GET: FooterLink/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FooterLink/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FooterId,facebook,twitter,instagram,youtube,googlemap,email,telephone,adres,whataspp")] FooterLink footerLink)
        {
            if (ModelState.IsValid)
            {
                db.foterLinks.Add(footerLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(footerLink);
        }

        // GET: FooterLink/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterLink footerLink = db.foterLinks.Find(id);
            if (footerLink == null)
            {
                return HttpNotFound();
            }
            return View(footerLink);
        }

        // POST: FooterLink/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FooterId,facebook,twitter,instagram,youtube,googlemap,email,telephone,adres,whataspp")] FooterLink footerLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footerLink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footerLink);
        }

        // GET: FooterLink/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FooterLink footerLink = db.foterLinks.Find(id);
            if (footerLink == null)
            {
                return HttpNotFound();
            }
            return View(footerLink);
        }

        // POST: FooterLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FooterLink footerLink = db.foterLinks.Find(id);
            db.foterLinks.Remove(footerLink);
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
