using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Intec.Common
{
    public class Mail
    {
        public void SendEmail(List<string> To, string Subject, string Body)
        {
            MailMessage email = new MailMessage();
            foreach (string to in To)
            {
                email.To.Add(new MailAddress(to));
            }
            //email.From = new MailAddress("coordinacion@inspiration.com.co");
            email.From = new MailAddress("intratec@intecsas.com.co");
            email.Subject = Subject;
            email.Body = Body;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            string textBody = Body;
            AlternateView plainTextView = AlternateView.CreateAlternateViewFromString(textBody, null, MediaTypeNames.Text.Plain);
            string htmlBody = "<html><body>" + textBody + "</body></html>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            string imagePathF = $@"{AppContext.BaseDirectory}img\logo.png";//aqui la ruta de tu imagen
            LinkedResource face = new LinkedResource(imagePathF);
            face.ContentId = "facebook";
            htmlView.LinkedResources.Add(face);
            email.AlternateViews.Add(htmlView);

            SmtpClient smtp = new SmtpClient
            {
                Host = "mail.intecsas.com.co",
                Port = 25,
                EnableSsl = false,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("intratec@intecsas.com.co", "intr4t3c@")
            };
            //
            smtp.Send(email);
            smtp.Dispose();
            email.Dispose();
        }

        //public void SendEmail(List<string> To, string Subject, string Body, List<string> Attached, string From, string Password, string MailServer, int Port, out string msjError)
        //{
        //    msjError = string.Empty;
        //    MailMessage email = new MailMessage();
        //    foreach (string to in To)
        //    {
        //        foreach (string t in to.Split(';'))
        //        {
        //            if (!string.IsNullOrEmpty(t))
        //            {
        //                try
        //                {
        //                    email.To.Add(new MailAddress(t));
        //                }
        //                catch (Exception ex)
        //                {
        //                    msjError = $"{msjError}||Error agregando cuenta destino: {t} => {ex.Message}";
        //                }
        //            }
        //        }
        //    }

        //    email.From = new MailAddress(From);
        //    email.Subject = Subject;
        //    email.Body = Body;
        //    email.IsBodyHtml = true;
        //    email.Priority = MailPriority.Normal;

        //    foreach (string file in Attached)
        //    {
        //        try
        //        {
        //            email.Attachments.Add(new Attachment(file));
        //        }
        //        catch (Exception ex)
        //        {
        //            msjError = $"{msjError}||Error agregando archivo a adjuntos: {file} => {ex.Message}";
        //        }
        //    }

        //    SmtpClient smtp = new SmtpClient
        //    {
        //        Host = MailServer,
        //        Port = Port,
        //        EnableSsl = false,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(From, Password)
        //    };
        //    //
        //    smtp.Send(email);
        //    smtp.Dispose();
        //    email.Dispose();
        //}

        public void SendEmail(List<string> To, string Subject, string Body, List<string> Attached, string From, string Password, string MailServer, int Port, out string msjError)
        {
            msjError = string.Empty;
            try
            {
                SmtpClient client = new SmtpClient();                
                client.Port = Port;
                client.Host = MailServer;
                client.EnableSsl = false;
                client.Timeout = 1000000000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;                
                client.Credentials = new NetworkCredential(From, Password);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(From);
                mail.Subject = Subject;

                foreach (string to in To)
                {
                    mail.To.Add(new MailAddress(to));
                }                

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString("<div><img src=cid:companylogo></div><div>" + Body + "</div>", null, "text/html");
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                System.Net.Mail.LinkedResource imageResource = new System.Net.Mail.LinkedResource(System.AppDomain.CurrentDomain.BaseDirectory + @"img\logo.png");

                imageResource.ContentId = "companylogo";                    
                htmlView.LinkedResources.Add(imageResource);                    
                mail.AlternateViews.Add(htmlView);

                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                foreach (string file in Attached)
                {
                    try
                    {
                        mail.Attachments.Add(new Attachment(file));
                    }
                    catch (Exception ex)
                    {
                        msjError = $"{msjError}||Error agregando archivo a adjuntos: {file} => {ex.Message}";
                    }
                }

                client.Send(mail);
                client.Send(mail);
            }
            catch (Exception ex){ msjError = ex.Message; }
        }
    }
}
