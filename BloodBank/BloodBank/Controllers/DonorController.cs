using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class DonorController : Controller
    {
        //
        // GET: /Donor/
        BloodBank.Models.BloodBankEntities db = new Models.BloodBankEntities();

        public ActionResult Index()
        {
            return View(db.Donors);
        }

        public ActionResult DonorDetails(int id)
        {
            return View(db.Donors.Find(id));
        }

        [HttpGet]
        public ActionResult DonorEdit(int id)
        {
            return View(db.Donors.Find(id));
        }

        [HttpPost]
        public ActionResult DonorEdit(int id, Models.Donor donor)
        {
            db.Entry(db.Donors.Find(id)).State = System.Data.EntityState.Modified;
            //save changes
            db.SaveChanges();
            //Kick user back to list
            return RedirectToAction("Index", "Donor");
        }
        
    }
}
