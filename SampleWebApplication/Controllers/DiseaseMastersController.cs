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
    public class DiseaseMastersController : Controller
    {
        private Entities db = new Entities();

        // GET: DiseaseMasters
        public ActionResult Index()
        {
            return View(db.DiseaseMasters.ToList());
        }

        // GET: DiseaseMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiseaseMaster diseaseMaster = db.DiseaseMasters.Find(id);
            if (diseaseMaster == null)
            {
                return HttpNotFound();
            }
            return View(diseaseMaster);
        }

        // GET: DiseaseMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiseaseMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Disease")] DiseaseMaster diseaseMaster)
        {
            if (ModelState.IsValid)
            {
                db.DiseaseMasters.Add(diseaseMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diseaseMaster);
        }

        // GET: DiseaseMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiseaseMaster diseaseMaster = db.DiseaseMasters.Find(id);
            if (diseaseMaster == null)
            {
                return HttpNotFound();
            }
            return View(diseaseMaster);
        }

        // POST: DiseaseMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Disease")] DiseaseMaster diseaseMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diseaseMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diseaseMaster);
        }

        // GET: DiseaseMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiseaseMaster diseaseMaster = db.DiseaseMasters.Find(id);
            if (diseaseMaster == null)
            {
                return HttpNotFound();
            }
            return View(diseaseMaster);
        }

        // POST: DiseaseMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiseaseMaster diseaseMaster = db.DiseaseMasters.Find(id);
            db.DiseaseMasters.Remove(diseaseMaster);
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
