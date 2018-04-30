using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS470_Project.Models;

namespace CS470_Project.Controllers
{
    public class LoginController : Controller
    {
        private SiteDBEntities db = new SiteDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string LName)
        {
            
            var query = from u in db.Users where (u.Lname == LName) select u;

            if (query.Count() == 1)
            {
                var user = query.First();
                Session["UserRole"] = user.Role;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // error handling
            }

            return View();
        }
        public ActionResult Login()
        {

            return View();
        }

     
    }
}