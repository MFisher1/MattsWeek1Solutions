using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class PatientController : Controller
    {
        //
        // GET: /Patient/

       BloodBank.Models.BloodBankEntities db = new Models.BloodBankEntities();

        public ActionResult Index()
        {
            return View(db.Patients);
        }

        public ActionResult PatientDetails(int id)
        {
            return View(db.Patients.Find(id));
        }

        public ActionResult PatientEdit(int id)
        {
            db.Entry(db.Patients.Find(id)).State = System.Data.EntityState.Modified;
            //save changes
            db.SaveChanges();
            //Kick user back to list
            return RedirectToAction("Index", "Patient");
        }

    }
}
