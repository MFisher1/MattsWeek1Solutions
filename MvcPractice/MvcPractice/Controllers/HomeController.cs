using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPractice.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //GET: /Home/About

        public ActionResult About()
        {
            return View();
        }

        public ActionResult HighScores()
        {
            return View();
        }

        
    }
}
