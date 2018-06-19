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
    public class DocTypeMastersController : Controller
    {
        private Entities db = new Entities();

        // GET: DocTypeMasters
        public ActionResult Index()
        {
            return View(db.DocTypeMasters.ToList());
        }

        // GET: DocTypeMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocTypeMaster docTypeMaster = db.DocTypeMasters.Find(id);
            if (docTypeMaster == null)
            {
                return HttpNotFound();
            }
            return View(docTypeMaster);
        }

        // GET: DocTypeMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocTypeMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type")] DocTypeMaster docTypeMaster)
        {
            if (ModelState.IsValid)
            {
                db.DocTypeMasters.Add(docTypeMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(docTypeMaster);
        }

        // GET: DocTypeMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocTypeMaster docTypeMaster = db.DocTypeMasters.Find(id);
            if (docTypeMaster == null)
            {
                return HttpNotFound();
            }
            return View(docTypeMaster);
        }

        // POST: DocTypeMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type")] DocTypeMaster docTypeMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docTypeMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docTypeMaster);
        }

        // GET: DocTypeMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocTypeMaster docTypeMaster = db.DocTypeMasters.Find(id);
            if (docTypeMaster == null)
            {
                return HttpNotFound();
            }
            return View(docTypeMaster);
        }

        // POST: DocTypeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocTypeMaster docTypeMaster = db.DocTypeMasters.Find(id);
            db.DocTypeMasters.Remove(docTypeMaster);
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
