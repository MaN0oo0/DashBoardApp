using PortalBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace PortalBL.Helpers
{
    public static class MailSettings
    {
        
          public  static string MailSender(string Host,int Port,MailVM mail)
        {
            var STMP = new SmtpClient(Host,Port);
            STMP.DeliveryMethod = SmtpDeliveryMethod.Network;
            STMP.UseDefaultCredentials = false;//
            STMP.EnableSsl = true;

          
            STMP.Credentials = new NetworkCredential(mail.FromEmail,mail.Password, mail.Name);
            MailMessage mail2 = new MailMessage(mail.FromEmail, mail.ToEmail);
            mail2.Subject = mail.Subject;
            mail2.Body = mail.Message;
            STMP.Send(mail2);
            return  "Send Succed";

        }
       
    }
}
