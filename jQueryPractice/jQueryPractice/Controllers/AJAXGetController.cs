using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQueryPractice.Controllers
{
    public class AJAXGetController : Controller
    {
        //
        // GET: /AJAXGet/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cats()
        {
            return PartialView();
        }

        public ActionResult Dogs() 
        {
            return Content("Dogs are awesome!");
        }

    }
}
