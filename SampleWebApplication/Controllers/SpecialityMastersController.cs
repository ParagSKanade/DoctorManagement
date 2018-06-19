using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleWebApplication.Models;

namespace SampleWebApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SpecialityMastersController : Controller
    {
        private Entities db = new Entities();

        // GET: SpecialityMasters
        public ActionResult Index()
        {
            return View(db.SpecialityMasters.ToList());
        }

        // GET: SpecialityMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialityMaster specialityMaster = db.SpecialityMasters.Find(id);
            if (specialityMaster == null)
            {
                return HttpNotFound();
            }
            return View(specialityMaster);
        }

        // GET: SpecialityMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialityMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Speciality,Description")] SpecialityMaster specialityMaster)
        {
            if (ModelState.IsValid)
            {
                db.SpecialityMasters.Add(specialityMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specialityMaster);
        }

        // GET: SpecialityMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialityMaster specialityMaster = db.SpecialityMasters.Find(id);
            if (specialityMaster == null)
            {
                return HttpNotFound();
            }
            return View(specialityMaster);
        }

        // POST: SpecialityMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Speciality,Description")] SpecialityMaster specialityMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialityMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialityMaster);
        }

        // GET: SpecialityMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialityMaster specialityMaster = db.SpecialityMasters.Find(id);
            if (specialityMaster == null)
            {
                return HttpNotFound();
            }
            return View(specialityMaster);
        }

        // POST: SpecialityMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialityMaster specialityMaster = db.SpecialityMasters.Find(id);
            db.SpecialityMasters.Remove(specialityMaster);
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
