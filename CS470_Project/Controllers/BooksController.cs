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
    public class BooksController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();
        
        public ActionResult Index(string searchString, string sortOrder, string currentFilter)
        {

            var books = from book in db.Books
                           select book;

            ViewBag.Currentfilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString) || s.ISBN.ToString().Contains(searchString));
            }
        
            switch (sortOrder)
            {
                case "title":
                    books = books.OrderBy(x => x.Title);
                    break;
                case "description":
                    books = books.OrderBy(x => x.Description);
                    break;
                case "year":
                    books = books.OrderBy(x => x.Yr);
                    break;
                case "rating":
                    books = books.OrderBy(x => x.Rating);
                    break;
                case "NumPages":
                    books = books.OrderBy(x => x.NumPages);
                    break;
                case "PublisherId":
                    books = books.OrderBy(x => x.PublisherID);
                    break;
                case "GenreId":
                    books = books.OrderBy(x => x.GenreID);
                    break;
                
            }
            ViewBag.Books = books.ToList();
            ViewBag.UserRole = (string)Session["UserRole"];


            
            return View(db.Books.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ISBN,Title,Description,Year,Rating,NumPages,PublisherID,GenreID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ISBN,Title,Description,Year,Rating,NumPages,PublisherID,GenreID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
