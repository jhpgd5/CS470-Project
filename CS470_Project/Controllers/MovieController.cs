using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS470_Project.Models;

namespace CS470_Project.Controllers
{
    public class MovieController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: Movie
        public ActionResult Index()
        {
            ViewBag.UserRole = (string)Session["UserRole"];
            return View(db.Movies.ToList());
        }

        // GET: Movie/Details/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie testMovieTable = db.Movies.Find(id);
            if (testMovieTable == null)
            {
                return HttpNotFound();
            }
            return View(testMovieTable);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ISAN,Year,Description,Rating,Runtime,ProducerID,GenreID")] Movie testMovieTable)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(testMovieTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testMovieTable);
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie testMovieTable = db.Movies.Find(id);
            if (testMovieTable == null)
            {
                return HttpNotFound();
            }
            return View(testMovieTable);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ISAN,Year,Description,Rating,Runtime,ProducerID,GenreID")] Movie testMovieTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testMovieTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testMovieTable);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie testMovieTable = db.Movies.Find(id);
            if (testMovieTable == null)
            {
                return HttpNotFound();
            }
            return View(testMovieTable);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie testMovieTable = db.Movies.Find(id);
            db.Movies.Remove(testMovieTable);
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
