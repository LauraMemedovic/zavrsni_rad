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
    public class ReceptController : Controller
    {
        private HranaContext db = new HranaContext();

        // GET: Recept
        public ActionResult Index()
        {
            return View(db.Recepti.ToList());
        }

        // GET: Recept/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recept recept = db.Recepti.Find(id);
            if (recept == null)
            {
                return HttpNotFound();
            }
            
            return View(recept);
        }

        // GET: Recept/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recept/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv")] Recept recept)
        {
            if (ModelState.IsValid)
            {
                db.Recepti.Add(recept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recept);
        }

        // GET: Recept/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recept recept = db.Recepti.Find(id);
            if (recept == null)
            {
                return HttpNotFound();
            }
            return View(recept);
        }

        // POST: Recept/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv")] Recept recept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recept);
        }

        // GET: Recept/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recept recept = db.Recepti.Find(id);
            if (recept == null)
            {
                return HttpNotFound();
            }
            return View(recept);
        }

        // POST: Recept/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recept recept = db.Recepti.Find(id);
            db.Recepti.Remove(recept);
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
