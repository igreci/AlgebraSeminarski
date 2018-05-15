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
using SeminarDva.ViewModels;

namespace SeminarDva.Controllers
{
    public class PredbiljezbeController : Controller
    {
        private ModelOne db = new ModelOne();

        // GET: Predbiljezbe
        public ActionResult Index()
        {
            var predbiljezbe = db.Predbiljezbe.Include(p => p.Seminar);
            return View(predbiljezbe.ToList());
        }

        // GET: Predbiljezbe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezba predbiljezba = db.Predbiljezbe.Find(id);
            if (predbiljezba == null)
            {
                return HttpNotFound();
            }
            return View(predbiljezba);
        }

        // GET: Predbiljezbe/Create
        public ActionResult Create(int id)
        {
            ViewBag.IdSeminar = new SelectList(db.Seminari, "IdSeminar", "Naziv", id);
            return View();
        }

        // POST: Predbiljezbe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPredbiljezba,DatumPredbiljezbe,Ime,Prezime,Adresa,Email,Telefon,IdSeminar,Status")] Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                db.Predbiljezbe.Add(predbiljezba);
                db.SaveChanges();
                return RedirectToAction("Index", "Seminari");
            }

            ViewBag.IdSeminar = new SelectList(db.Seminari, "IdSeminar", "Naziv", predbiljezba.IdSeminar);
            return View(predbiljezba);
        }

        // GET: Predbiljezbe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezba predbiljezba = db.Predbiljezbe.Find(id);
            if (predbiljezba == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSeminar = new SelectList(db.Seminari, "IdSeminar", "Naziv", predbiljezba.IdSeminar);
            return View(predbiljezba);
        }

        // POST: Predbiljezbe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPredbiljezba,DatumPredbiljezbe,Ime,Prezime,Adresa,Email,Telefon,IdSeminar,Status")] Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predbiljezba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSeminar = new SelectList(db.Seminari, "IdSeminar", "Naziv", predbiljezba.IdSeminar);
            return View(predbiljezba);
        }

        // GET: Predbiljezbe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezba predbiljezba = db.Predbiljezbe.Find(id);
            if (predbiljezba == null)
            {
                return HttpNotFound();
            }
            return View(predbiljezba);
        }

        // POST: Predbiljezbe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Predbiljezba predbiljezba = db.Predbiljezbe.Find(id);
            db.Predbiljezbe.Remove(predbiljezba);
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

        public ActionResult GetSelected(int? id)
        {
            var listaSelected = db.Predbiljezbe.Include(p => p.Seminar).Where(x => x.IdSeminar == id);
            //ViewBag.SelectedList = listaSelected;
            return View("Index", listaSelected);
        }

        public ActionResult SortBySeminarName()
        {
            var listaSelected = db.Predbiljezbe.OrderBy(y => y.Status).OrderBy(x => x.Seminar.Naziv);
            return View("Index", listaSelected);
        }

        public ActionResult SortByPrezime(int? id)
        {
            if (id == null || id == 0)
            {
                var listaSelected = db.Predbiljezbe.OrderBy(x => x.Prezime);
                return View("Index", listaSelected);
            }

            int idSeminar = (int)id;
            var listaSelectedForSeminar = db.Predbiljezbe.Include(p => p.Seminar).Where(y => y.IdSeminar == id).OrderBy(x => x.Prezime);
            var viewModel = new PredbiljezbeForSeminarViewModel
            {
                Id = id,
                Predbiljezbe = listaSelectedForSeminar.ToList()
            };
            
            return View("PredbiljezbeViewModel", viewModel);

        }

        public ActionResult SortByDatumPredbiljezbe(int? id)
        {
            if (id == null || id == 0)
            {
                var listaSelected = db.Predbiljezbe.OrderByDescending(x => x.DatumPredbiljezbe);
                return View("Index", listaSelected);
            }

            int idSeminar = (int)id;
            var listaSelectedForSeminar = db.Predbiljezbe.Include(p => p.Seminar).Where(y => y.IdSeminar == id).OrderByDescending(x => x.DatumPredbiljezbe);
            var viewModel = new PredbiljezbeForSeminarViewModel
            {
                Id = idSeminar,
                Predbiljezbe = listaSelectedForSeminar.ToList()
            };

            return View("PredbiljezbeViewModel", viewModel);

        }

        public ActionResult SortByStatus(int? id)
        {
            if (id == null || id == 0)
            {
                var listaSelected = db.Predbiljezbe.OrderBy(y => y.Status);
                return View("Index", listaSelected); 
            }

            int idSeminar = (int)id;
            var listaSelectedForSeminar = db.Predbiljezbe.Include(p => p.Seminar).Where(y => y.IdSeminar == id).OrderBy(x => x.Status);
            var viewModel = new PredbiljezbeForSeminarViewModel
            {
                Id = idSeminar,
                Predbiljezbe = listaSelectedForSeminar.ToList()
            };

            return View("PredbiljezbeViewModel", viewModel);
        }
    }
}
