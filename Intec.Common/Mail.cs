using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            email.From = new MailAddress("lagunawilson@gmail.com");
            email.Subject = Subject;
            email.Body = Body;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                //Credentials = new NetworkCredential("coordinacion@inspiration.com.co", "c00rd1n@c10n");
                Credentials = new NetworkCredential("lagunawilson@gmail.com", "w1ls0n777")
            };
            //
            smtp.Send(email);
            smtp.Dispose();
            email.Dispose();
        }

        public void SendEmail(List<string> To, string Subject, string Body, List<string> Attached, 
            string From, string Password, string MailServer, int Port, out string msjError)
        {
            msjError = string.Empty;
            MailMessage email = new MailMessage();
            foreach (string to in To)
            {
                foreach (string t in to.Split(';'))
                {
                    if (!string.IsNullOrEmpty(t))
                    {
                        try
                        {
                            email.To.Add(new MailAddress(t));
                        }
                        catch (Exception ex)
                        {
                            msjError = $"{msjError}||Error agregando cuenta destino: {t} => {ex.Message}";
                        }
                    }
                }
            }

            
            email.Bcc.Add(new MailAddress("lagunawilson@gmail.com"));            

            email.From = new MailAddress(From);
            email.Subject = Subject;
            email.Body = Body;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            foreach (string file in Attached)
            {
                try
                {
                    email.Attachments.Add(new Attachment(file));
                }
                catch (Exception ex)
                {
                    msjError = $"{msjError}||Error agregando archivo a adjuntos: {file} => {ex.Message}";
                }
            }

            SmtpClient smtp = new SmtpClient
            {
                Host = MailServer,
                Port = Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(From, Password)
            };
            //
            smtp.Send(email);
            smtp.Dispose();
            email.Dispose();
        }
    }
}
