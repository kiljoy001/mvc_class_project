using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_tutorial_restart.Models;

namespace mvc_tutorial_restart.Controllers
{
    public class AdminController : Controller
    {
        DBModel adminLogin = new DBModel();
        // GET: Admin
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        //login request
        [HttpPost]
        public ActionResult Index(AdminLogin creds)
        {
            var emailLogin = adminLogin.Admins.ToList();
            var emailmatch = emailLogin.Where(un => un.Admin_Login == creds.UserName);
            if (ModelState.IsValid)
            {
                if (BCrypt.Net.BCrypt.Verify(creds.Secret, emailmatch.Single().Secret))
                {
                    return View("Configure");
                }
                
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit()
        {
            return View("Configure");
        }
        public ActionResult Albums()
        {
            return View("Albums");
        }
    }
}