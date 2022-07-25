using Microsoft.AspNetCore.Mvc;
using PortalBL.Helpers;
using PortalBL.Models;
using System.IO;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace PortalPL.Controllers
{
    [Authorize(Roles = "Account")]
    public class MailController : Controller
    {
      
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailVM mail, IFormFile[] attachments)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<string> fileNames = null;
                    if (attachments != null && attachments.Length > 0)
                    {
                        fileNames = new List<string>();
                        foreach (IFormFile attachment in attachments)
                        {
                            var path = UploadFiles.UploaderFiles("senders", attachment);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                attachment.CopyToAsync(stream);
                            }
                            fileNames.Add(path);
                        }
                    }
                    TempData["Msg"] = MailSettings.MailSender("smtp.office365.com", 587, mail, fileNames);
                    
                    return RedirectToAction("SendMail");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Failed Sent  "+ ex.Message;
            }
            return View();
        }

    }
}
