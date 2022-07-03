using Microsoft.AspNetCore.Mvc;
using PortalBL.Helpers;
using PortalBL.Models;
using System.Net.Mail;
using System.Net;



namespace PortalPL.Controllers
{
    public class MailController : Controller
    {
      
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailVM mail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["Msg"] = MailSettings.MailSender("smtp.office365.com", 587, mail);
                    
                    return RedirectToAction("SendMail");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Failed Sent";
            }
            return View();
        }

    }
}
