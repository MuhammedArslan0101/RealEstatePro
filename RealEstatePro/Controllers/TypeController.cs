using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealEstatePro.Models;
using Type = RealEstatePro.Models.Type;

namespace RealEstatePro.Controllers
{
    public class TypeController : Controller
    {
        private DataContext db = new DataContext();
        [Authorize(Roles = "admin")]
        // GET: Type
        public ActionResult Index()
        {
            var types = db.Types.Include(t => t.Status);
            return View(types.ToList());
        }

        public PartialViewResult StatusName1()
        {
            var statusname1 = db.Types.Where(i => i.StatusId == 1).FirstOrDefault();
            return PartialView(statusname1);
        }
        public PartialViewResult StatusName2()
        {
            var statusname2 = db.Types.Where(i => i.StatusId == 2).FirstOrDefault();
            return PartialView(statusname2);
        }

        public PartialViewResult StutsTip1()
        {
            var statustip1 = db.Types.Where(i => i.StatusId == 1).ToList();
            return PartialView(statustip1);

        }
        public PartialViewResult StutsTip2()
        {
            var statustip2 = db.Types.Where(i => i.StatusId == 2).ToList();
            return PartialView(statustip2);

        }
        [Authorize(Roles = "admin")]
        // GET: Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }
        [Authorize(Roles = "admin")]
        // GET: Type/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName");
            return View();
        }
        [Authorize(Roles = "admin")]
        // POST: Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeId,TypeName,StatusId")] Type type)
        {
            if (ModelState.IsValid)
            {
                db.Types.Add(type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", type.StatusId);
            return View(type);
        }
        [Authorize(Roles = "admin")]
        // GET: Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", type.StatusId);
            return View(type);
        }
        [Authorize(Roles = "admin")]
        // POST: Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeId,TypeName,StatusId")] Type type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", type.StatusId);
            return View(type);
        }
        [Authorize(Roles = "admin")]
        // GET: Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }
        [Authorize(Roles = "admin")]
        // POST: Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Type type = db.Types.Find(id);
            db.Types.Remove(type);
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
