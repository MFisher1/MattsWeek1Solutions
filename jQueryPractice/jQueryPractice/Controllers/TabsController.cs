using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQueryPractice.Controllers
{
    public class TabsController : Controller
    {
        //
        // GET: /Tabs/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tab1()
        {
            return Content("This is the land of tab 1");
        }

        public ActionResult Tab2() 
        {
            return Content("This is the land of tab 2");
        }

        public ActionResult Tab3()
        {
            return Content("This is the land of tab 3");
        }

    }
}
