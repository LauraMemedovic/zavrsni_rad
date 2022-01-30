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
    public class PopisRecepataController : Controller
    {
        private HranaContext db = new HranaContext();

        // GET: PopisRecepata
        public ActionResult Index(string sortOrder,string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asc" : "";
            var popisi = from pr in db.PopisiRecepata
                           select pr;
            if (!String.IsNullOrEmpty(searchString))
            {
                popisi = popisi.Where(pr => pr.Sastojak.Contains(searchString)
                                       || pr.Sastojak2.Contains(searchString)
                                       || pr.Slozenost.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_asc":
                    popisi = popisi.OrderBy(pr => pr.Naziv);
                    break;
            }

            return View(popisi.ToList());
        }

        // GET: PopisRecepata/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopisRecepata popisRecepata = db.PopisiRecepata.Find(id);
            if (popisRecepata == null)
            {
                return HttpNotFound();
            }
            return View(popisRecepata);
        }

        // GET: PopisRecepata/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PopisRecepata/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv,Sastojak,Sastojak2,Slozenost")] PopisRecepata popisRecepata)
        {
            if (ModelState.IsValid)
            {
                db.PopisiRecepata.Add(popisRecepata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(popisRecepata);
        }

        // GET: PopisRecepata/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopisRecepata popisRecepata = db.PopisiRecepata.Find(id);
            if (popisRecepata == null)
            {
                return HttpNotFound();
            }
            return View(popisRecepata);
        }

        // POST: PopisRecepata/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,Sastojak,Sastojak2,Slozenost")] PopisRecepata popisRecepata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(popisRecepata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(popisRecepata);
        }

        // GET: PopisRecepata/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PopisRecepata popisRecepata = db.PopisiRecepata.Find(id);
            if (popisRecepata == null)
            {
                return HttpNotFound();
            }
            return View(popisRecepata);
        }

        // POST: PopisRecepata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopisRecepata popisRecepata = db.PopisiRecepata.Find(id);
            db.PopisiRecepata.Remove(popisRecepata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        new List<string> omiljeni = new List<string>();
        [HttpPost, ActionName("Dodaj")]
        [ValidateAntiForgeryToken]
        public ActionResult Dodaj(string name)
        {
            omiljeni.Add(name);
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
