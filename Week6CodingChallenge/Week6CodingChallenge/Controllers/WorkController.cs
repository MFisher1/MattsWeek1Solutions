﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week6CodingChallenge.Controllers
{
    public class WorkController : Controller
    {
        //
        // GET: /Work/

        public ActionResult Index()
        {
            return PartialView();
        }

    }
}
