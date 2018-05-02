﻿using System;
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
    public class GamesController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();

        // GET: Games
        public ActionResult Index()
        {
            ViewBag.UserRole = (string)Session["UserRole"];
            return View(db.Games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game testGamesTable = db.Games.Find(id);
            if (testGamesTable == null)
            {
                return HttpNotFound();
            }
            return View(testGamesTable);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GameID,Title,Description,Year,Rating,GenreID,PublisherID,ProducerID")] Game testGamesTable)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(testGamesTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testGamesTable);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game testGamesTable = db.Games.Find(id);
            if (testGamesTable == null)
            {
                return HttpNotFound();
            }
            return View(testGamesTable);
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GameID,Title,Description,Year,Rating,GenreID,PublisherID,ProducerID")] Game testGamesTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testGamesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testGamesTable);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game testGamesTable = db.Games.Find(id);
            if (testGamesTable == null)
            {
                return HttpNotFound();
            }
            return View(testGamesTable);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game testGamesTable = db.Games.Find(id);
            db.Games.Remove(testGamesTable);
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
