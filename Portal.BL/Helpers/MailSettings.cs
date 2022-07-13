using PortalBL.Models;
using System.Net.Mail;
using System.Net;
 



namespace PortalBL.Helpers
{
    public static class MailSettings
    {

          public  static string MailSender(string Host,int Port,MailVM mail,List<string>Attchments)
        {
            var STMP = new SmtpClient(Host,Port);
            STMP.DeliveryMethod = SmtpDeliveryMethod.Network;
            STMP.UseDefaultCredentials = false;//
            STMP.EnableSsl = true;
            STMP.Timeout = 100000;

            
            STMP.Credentials = new NetworkCredential(mail.FromEmail,mail.Password, mail.Name);
            MailMessage mail2 = new MailMessage(mail.FromEmail, mail.ToEmail);
            mail2.Subject = mail.Subject;
            mail2.Body = mail.Message;
            


            if (Attchments != null)
            {
                foreach (var attachment in Attchments)
                {
                    mail2.Attachments.Add(new Attachment(attachment));
                }
            }

            STMP.Send(mail2);
            return  "Send Succed";

        }
       
    }
}
