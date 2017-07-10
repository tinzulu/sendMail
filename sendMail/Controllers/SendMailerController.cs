using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using System.Configuration;
using sendMail.Models;

namespace sendMail.Controllers
{
    public class SendMailerController : Controller
    {
        // GET: SendMailer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {

                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                _objModelMail.From = ConfigurationManager.AppSettings.Get("mailaddress");
                string mailpassword = ConfigurationManager.AppSettings.Get("mailpassword");
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(_objModelMail.From,mailpassword);
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return View("index", _objModelMail);
            }
            else
            {
                return View();
            }
        }
    }
}