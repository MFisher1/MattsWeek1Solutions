﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPractice.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Models.ContactForm());
        }

        [HttpPost]
        public ActionResult Index(Models.ContactForm contactForm)
        {
            //create a connection database
            Models.ContactForm db = new Models.ContactForm();
            //Add contact info to database
            db.ContactForm.Add(contactForm);
            //save changes
            db.SaveChanges();
            //Kick user to thank you page
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ThankYou()
        {
            return View();
        }

    }
}
