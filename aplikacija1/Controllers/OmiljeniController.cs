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
    public class OmiljeniController : Controller
    {
        private HranaContext db = new HranaContext();

        // GET: Omiljeni
        public ActionResult Index()
        {
            var omiljeniR = db.OmiljeniR.Include(o => o.PopisRecepata).Include(o => o.Sastojak);
            return View(omiljeniR.ToList());
        }

        // GET: Omiljeni/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Omiljeni omiljeni = db.OmiljeniR.Find(id);
            if (omiljeni == null)
            {
                return HttpNotFound();
            }
            return View(omiljeni);
        }

        // GET: Omiljeni/Create
        public ActionResult Create()
        {
            ViewBag.PopisRecepataID = new SelectList(db.PopisiRecepata, "ID", "Naziv");
            ViewBag.SastojakID = new SelectList(db.Sastojci, "ID", "Naziv");
            return View();
        }

        // POST: Omiljeni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OmiljeniID,SastojakID,PopisRecepataID")] Omiljeni omiljeni)
        {
            if (ModelState.IsValid)
            {
                db.OmiljeniR.Add(omiljeni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PopisRecepataID = new SelectList(db.PopisiRecepata, "ID", "Naziv", omiljeni.PopisRecepataID);
            ViewBag.Sastojak = new SelectList(db.Sastojci, "ID", "Naziv", omiljeni.SastojakID);
            return View(omiljeni);
        }

        // GET: Omiljeni/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Omiljeni omiljeni = db.OmiljeniR.Find(id);
            if (omiljeni == null)
            {
                return HttpNotFound();
            }
            ViewBag.PopisRecepataID = new SelectList(db.PopisiRecepata, "ID", "Naziv", omiljeni.PopisRecepataID);
            ViewBag.SastojakID = new SelectList(db.Sastojci, "ID", "Naziv", omiljeni.SastojakID);
            return View(omiljeni);
        }

        // POST: Omiljeni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OmiljeniID,SastojakID,PopisRecepataID")] Omiljeni omiljeni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(omiljeni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PopisRecepataID = new SelectList(db.PopisiRecepata, "ID", "Naziv", omiljeni.PopisRecepataID);
            ViewBag.SastojakID = new SelectList(db.Sastojci, "ID", "Naziv", omiljeni.SastojakID);
            return View(omiljeni);
        }

        // GET: Omiljeni/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Omiljeni omiljeni = db.OmiljeniR.Find(id);
            if (omiljeni == null)
            {
                return HttpNotFound();
            }
            return View(omiljeni);
        }

        // POST: Omiljeni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Omiljeni omiljeni = db.OmiljeniR.Find(id);
            db.OmiljeniR.Remove(omiljeni);
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
