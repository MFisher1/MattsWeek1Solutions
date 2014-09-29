using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace BloodBank.Controllers
{
    public class BloodBankController : Controller
    {
        //
        // GET: /BloodBank/

        BloodBank.Models.BloodBankEntities db = new Models.BloodBankEntities();

        public ActionResult Index()
        {
            return View(db.BloodBanks);
        }

        public ActionResult Details(int id)
        {
            return View(db.BloodBanks.Find(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.BloodBanks.Find(id));
        }

        [HttpPost]
        public ActionResult DonorEdit(int id)
        {
            db.Entry(db.BloodBanks.Find(id)).State = System.Data.EntityState.Modified;
            //save changes
            db.SaveChanges();
            //Kick user back to list
            return RedirectToAction("Index", "BloodBank");
        }

    }
}
