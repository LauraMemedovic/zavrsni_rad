using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using aplikacija1.Data;
using aplikacija1.Models;

namespace aplikacija1.Controllers
{
    public class PrehranaController : Controller
    {
        private HranaContext db = new HranaContext();

        // GET: Prehrana
        public ActionResult Index()
        {
            return View(db.Prehrane.ToList());
        }

        // GET: Prehrana/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prehrana prehrana = db.Prehrane.Find(id);
            if (prehrana == null)
            {
                return HttpNotFound();
            }
            return View(prehrana);
        }

        // GET: Prehrana/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prehrana/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Info")] Prehrana prehrana)
        {
            if (ModelState.IsValid)
            {
                db.Prehrane.Add(prehrana);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prehrana);
        }

        // GET: Prehrana/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prehrana prehrana = db.Prehrane.Find(id);
            if (prehrana == null)
            {
                return HttpNotFound();
            }
            return View(prehrana);
        }

        // POST: Prehrana/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Info")] Prehrana prehrana)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prehrana).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prehrana);
        }

        // GET: Prehrana/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prehrana prehrana = db.Prehrane.Find(id);
            if (prehrana == null)
            {
                return HttpNotFound();
            }
            return View(prehrana);
        }

        // POST: Prehrana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prehrana prehrana = db.Prehrane.Find(id);
            db.Prehrane.Remove(prehrana);
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
