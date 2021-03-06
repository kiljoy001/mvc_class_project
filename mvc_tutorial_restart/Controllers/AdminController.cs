﻿using System;
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
            Admin adminModel = new Admin();
            var emailLogin = adminLogin.Admins.ToList();
            var emailmatch = emailLogin.Where(un => un.Admin_Login.Trim() == creds.UserName);
            foreach (Admin item in emailmatch)
            {
                adminModel = item;
            }
            if (!ModelState.IsValid)
            {
#if DEBUG
                var errors = ModelState.Where(ms => ms.Value.Errors.Count > 0).ToArray();
#endif
                return View(creds);
            }
            if (BCrypt.Net.BCrypt.Verify(creds.Secret, emailmatch.Single().Secret))
            {
                var CLViewModel = new ConfigureLoginViewModel()
                {
                    Login = creds,
                    LoginDbModel = adminModel
                };
                return View("Configure", CLViewModel);
            }
            return View();
        }
        public ActionResult Edit()
        {
            return View("Configure");
        }
        public ActionResult Albums()
        {
            return View("Albums");
        }
        [HttpPost]
        public void Update_Discogs(ConfigureLoginViewModel updated )
        {
            adminLogin.Admins.Attach(updated.LoginDbModel);
            var entry = adminLogin.Entry(updated.LoginDbModel);
            entry.Property(a => a.Discogs).IsModified = true;
            adminLogin.SaveChanges();
            //return View("Configure");
        }
    }
}