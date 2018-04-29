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
        public ActionResult Login(User user)
        {
            using (SiteDBEntities db = new SiteDBEntities())
            {
                var usr = db.Users.Where(u => u.Lname == user.Lname).FirstOrDefault();
                if (usr != null)
                {
                    if (usr.Role == "Admin")
                    {
                        Session["LastName"] = usr.Lname.ToString();
                        Session["UserRole"] = usr.Role.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    if (usr.Role == "User")
                    {
                        Session["LastName"] = usr.Lname.ToString();
                        Session["UserRole"] = usr.Lname.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong Username");
                }
            }
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }

     
    }
}