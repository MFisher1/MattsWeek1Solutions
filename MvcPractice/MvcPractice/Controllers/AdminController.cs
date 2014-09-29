using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPractice.Controllers
{
    public class AdminController : Controller
    {
        //Create connectiont to database
        Models.ContactFormEntities db = new Models.ContactFormEntities();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            //List the contents of our contacts forms

            return View(db.ContactForms);
        }

        public ActionResult Details(int id) 
        {
            return View(db.ContactForms.Find(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.ContactForms.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.ContactForm contactForm)
        {
            db.Entry(contactForm).State = System.Data.EntityState.Modified;
            //save changes
            db.SaveChanges();
            //Kick user back to list
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult DeleteConfirm(int id)
        {
            Models.ContactForm formToDelete = db.ContactForms.Find(id);
            db.ContactForms.Remove(formToDelete);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }


    }
}
