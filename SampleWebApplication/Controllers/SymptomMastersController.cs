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
    public class SymptomMastersController : Controller
    {
        private Entities db = new Entities();

        // GET: SymptomMasters
        public ActionResult Index()
        {
            return View(db.SymptomMasters.ToList());
        }

        // GET: SymptomMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SymptomMaster symptomMaster = db.SymptomMasters.Find(id);
            if (symptomMaster == null)
            {
                return HttpNotFound();
            }
            return View(symptomMaster);
        }

        // GET: SymptomMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SymptomMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Symptom")] SymptomMaster symptomMaster)
        {
            if (ModelState.IsValid)
            {
                db.SymptomMasters.Add(symptomMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(symptomMaster);
        }

        // GET: SymptomMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SymptomMaster symptomMaster = db.SymptomMasters.Find(id);
            if (symptomMaster == null)
            {
                return HttpNotFound();
            }
            return View(symptomMaster);
        }

        // POST: SymptomMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Symptom")] SymptomMaster symptomMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(symptomMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(symptomMaster);
        }

        // GET: SymptomMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SymptomMaster symptomMaster = db.SymptomMasters.Find(id);
            if (symptomMaster == null)
            {
                return HttpNotFound();
            }
            return View(symptomMaster);
        }

        // POST: SymptomMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SymptomMaster symptomMaster = db.SymptomMasters.Find(id);
            db.SymptomMasters.Remove(symptomMaster);
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
