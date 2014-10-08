using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; //import namespace for path
using System.Web.Security; //import namespace for membership

namespace MyBlog.Controllers
{
    public class AcountController : Controller
    {
        //Set up my data context
        Models.BlogEntities db = new Models.BlogEntities();

        [HttpGet]
        public ActionResult Register()
        {
            return View();

        }

        //add http posted file parameter

        [HttpPost]
        public ActionResult Register(Models.Registration registration, HttpPostedFileBase ImageUrl)
        {
            
            if (ImageUrl != null)
            {
                //save image to website
                //Guid Generates random characters to make sure that file name is not repeated
                string filename = Guid.NewGuid().ToString().Substring(0,6) + ImageUrl.FileName;
                //specify the path to save the file to
                //sever mappath actually gets the physical location of the website on the server
                string path = Path.Combine(Server.MapPath("~/content/"), filename);
                //save the file
                ImageUrl.SaveAs(path);
                //update our registration object with the Image 
                registration.ImageUrl ="/content/" +filename;
            }
            //create our membership user
            Membership.CreateUser(registration.UserName, registration.Password);
            //create our Author Object
            Models.Author author = new Models.Author();
            author.Name = registration.Name;
            author.ImgUrl = registration.ImageUrl;
            author.UserName = registration.UserName;
            //add author to database
            db.Authors.Add(author);
            db.SaveChanges();

            //registration complete! Log in the user
            FormsAuthentication.SetAuthCookie(registration.UserName, false);

            return RedirectToAction("Index", "Post");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Acount");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Login login)
        { 
            if(Membership.ValidateUser(login.Username, login.Password))
            {
            //if valid user log them in
            FormsAuthentication.SetAuthCookie(login.Username, false);
            //kik user to create post page
            return RedirectToAction("Index", "Post");
            }
            else
            {
                ViewBag.ErrorMessage = "Ivalid user name and or password";
                return View(login);
            }
        }
    }
}
