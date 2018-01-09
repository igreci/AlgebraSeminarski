using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeminarDva;
using SeminarDva.Models;

namespace SeminarDva.Controllers
{
    public class SeminariController : Controller
    {
        private ModelOne db = new ModelOne();

        // GET: Seminari
        public ActionResult Index(string search)
        {
            var seminarLista = db.Seminari.Where(x => x.Popunjen == false && x.BrojMjesta > x.Predbiljezba.Count);

            if (!string.IsNullOrEmpty(search))
            {
                seminarLista = seminarLista.Where(x => x.Naziv.Contains(search) || x.Opis.Contains(search));
            }

            return View(seminarLista.OrderByDescending(x => x.DatumPocetka).ToList());
        }

        // GET: Seminari/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminar seminar = db.Seminari.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            return View(seminar);
        }

        // GET: Seminari/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seminari/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSeminar,Naziv,Opis,DatumPocetka,Popunjen,BrojMjesta")] Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                db.Seminari.Add(seminar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seminar);
        }

        // GET: Seminari/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminar seminar = db.Seminari.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            return View(seminar);
        }

        // POST: Seminari/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSeminar,Naziv,Opis,DatumPocetka,Popunjen,BrojMjesta")] Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seminar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seminar);
        }

        // GET: Seminari/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminar seminar = db.Seminari.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            return View(seminar);
        }

        // POST: Seminari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seminar seminar = db.Seminari.Find(id);
            db.Seminari.Remove(seminar);
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

        public ActionResult GetAllSeminari()
        {
            var listaSvi = db.Seminari.OrderByDescending(x => x.DatumPocetka).ToList();
            return View("Index", listaSvi);
        }
    }
}
