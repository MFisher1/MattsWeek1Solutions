using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Models.BlogEntities db = new Models.BlogEntities();

        public ActionResult Index()
        {
            return View(db.Posts.OrderByDescending(x => x.DateCreated));
        }

        public ActionResult AddComment(Models.Comment commentToAdd)
        { 
            //make sure comment is fully filled out
            commentToAdd.DateCreated = DateTime.Now;

            //add comment to database
            db.Comments.Add(commentToAdd);
            db.SaveChanges();
            
            //for now until we ajax it, kick user back to index
            return RedirectToAction("Index", "Home");
            
        }

    }
}
