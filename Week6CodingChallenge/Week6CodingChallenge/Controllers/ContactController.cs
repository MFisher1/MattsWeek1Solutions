using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace Week6CodingChallenge.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Week6CodingChallenge.Models.ContactForm());
        }

        //[HttpPost]
        //public ActionResult Index(Models.ContactForm contactForm)
        //{
        //    //create a connection database
        //    Models.ContactForm db = new Models.ContactForm();
        //    //Add contact info to database
        //    db.ContactForm.Add(contactForm);
        //    //save changes
        //    db.SaveChanges();
        //    //Kick user to thank you page
        //    return RedirectToAction("Index", "Home");
        //}

        //new contact form post

        [HttpPost]
        public ActionResult Index(Week6CodingChallenge.Models.ContactForm contactForm)
        {
            //sending an email 
            //step 1. add using system.net.mail
            //step 2. create a new message first
            MailMessage message = new MailMessage("theRobots@seedpaths.com", "mattfish490@gmail.com");
            //step 3. set subject
            message.Subject = "Contact request from";
            //step 4. construct the body with stringbuilder
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("You have a new contact request.");
            sb.AppendLine("Name: " + contactForm.Name);
            sb.AppendLine("Email: " + contactForm.Email);
            sb.AppendLine("Message: " + contactForm.Message);
            sb.AppendLine(" I Love You");
            sb.AppendLine("- THe Robots");
            //step 5. Add Body to Message
            message.Body = sb.ToString();
            //step 6. Declare the SMTP client/aka the mail server
            SmtpClient client = new SmtpClient("mail.dustinkraft.com", 587);
            client.Credentials = new System.Net.NetworkCredential("postmaster@dustinkraft.com", "techIsFun1");
            //Step 7. Send message
            client.Send(message);
            return RedirectToAction("ThankYou", "Contact");
        }

        public ActionResult ThankYou()
        {
            return View();
        }

    }
}