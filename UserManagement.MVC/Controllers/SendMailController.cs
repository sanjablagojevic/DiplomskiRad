using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.MVC.Models;
using System.Net.Mail;

namespace UserManagement.MVC.Controllers
{
    public class SendMailController : Controller
    {
        [HttpPost]
        public ActionResult Index(Email email)
        {
            string to = email.To;
            string subject = email.Subject;
            string body = email.Body;
            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("sanjab2801@gmail.com");
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("sanjab2801@gmail.com", "harizma2801");
            smtp.Send(mm);
            ViewBag.message = "This Mail Has Been Sent To " + email.To + " Successfully...!";

            return null;
        }
    }
}
