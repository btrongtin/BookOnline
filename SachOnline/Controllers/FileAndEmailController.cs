using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SachOnline.Models;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace SachOnline.Controllers
{
    public class FileAndEmailController : Controller
    {
        // GET: FileAndEmail
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail(Mail model)
        {
            //cấu hình tt gmail [khai báo thư viện system.net]
            var mail = new SmtpClient("smtp.gmail.com", 587)
            {
                //khai báo thư viện system.net
                Credentials = new NetworkCredential(model.From, "sickmyduch4password"),
                //your email (abc@gmail.com) anhd your password (*****)
                EnableSsl = true
            };
            //tạo email
            var message = new MailMessage();
            message.From = new MailAddress(model.From);
            message.ReplyToList.Add(model.From);
            message.To.Add(new MailAddress(model.To));
            message.Subject = model.Subject;
            message.Body = model.Notes;

            var f = Request.Files["attachment"];
            var path = Path.Combine(Server.MapPath("~/UploadFile"), f.FileName);
            if (!System.IO.File.Exists(path))
            {
                f.SaveAs(path);
            }

            //khai báo thư viện system.net.mime
            Attachment data = new Attachment(Server.MapPath("~/UploadFile"+ f.FileName), MediaTypeNames.Application.Octet);
            message.Attachments.Add(data);
            //gửi email
            mail.Send(message);
            return View("SendMail");
        }
    }
}