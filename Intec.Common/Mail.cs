using System;
using System.Collections.Generic;
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

            
            //email.Bcc.Add(new MailAddress("lagunawilson@gmail.com"));            

            email.From = new MailAddress(From);
            email.Subject = Subject;
            //email.Body = Body;
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
                EnableSsl = false,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(From, Password)
            };
            //
            smtp.Send(email);
            smtp.Dispose();
            email.Dispose();
        }


        public bool sendEmail(string MailServer, string Subject, string From, int Port, string to, string emailLogin)
        {            
            Boolean response = false;
            //Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);
            try
            {
                //if (filename != null && filename != string.Empty)
                {
                    
                    
                    String textoEmail = "";
                    SmtpClient client = new SmtpClient(); ;
                    // utilizamos el servidor SMTP de gmail
                    client.Port = Convert.ToInt32(Port);
                    client.Host = MailServer;
                    client.EnableSsl = false;
                    client.Timeout = 1000000000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = true;
                    // nos autenticamos con nuestra cuenta de gmail
                    client.Credentials = new NetworkCredential();
                    MailMessage mail = new MailMessage();
                    mail.To.Add(new MailAddress(to));
                    mail.From = new MailAddress(From);
                    mail.Subject = Subject;

                    //mail.Body ="Equipo G500" + Environment.NewLine + " El archivo no pudo ser procesado ya que no tiene el formato correcto de blacklist para cuentas PREMIER bloqueadas hasta el día " + dateFormat + " . " + Environment.NewLine + "Saludos";


                    textoEmail = "               " + "<br><b>Día y fecha de solicitud</b>"
                    + "               " + "<br>" + DateTime.Now.ToString() + "."
                    + "<br><br>Estimado Usuario,<br><br>"
                    + "Adjunto a este correo se encuentra el archivo<br>"
                    + "con el reporte solicitado con período de <br>"
                    //+ ("consulta del <b>[" + initDate + "]-[" + endDate + "]</b>").Trim()
                    + "<br><br>Usuario que solicita: <br><br>"
                    + emailLogin + "<br><br>";



                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(" <img src=cid:companylogo>" + textoEmail + " <img src=cid:excel><br><br><br> <img src=cid:mailfoot>", null, "text/html");
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    var aa = System.AppDomain.CurrentDomain.BaseDirectory;

                    System.Net.Mail.LinkedResource imageResource = new System.Net.Mail.LinkedResource($@"{AppContext.BaseDirectory}img\logo.png");
                    System.Net.Mail.LinkedResource imageResource2 = new System.Net.Mail.LinkedResource($@"{AppContext.BaseDirectory}img\logo.png");
                    System.Net.Mail.LinkedResource imageResource3 = new System.Net.Mail.LinkedResource($@"{AppContext.BaseDirectory}img\logo.png");

                    //System.Net.Mail.LinkedResource imageResource1 = new System.Net.Mail.LinkedResource(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/assets/img/pc1.png");

                    imageResource.ContentId = "companylogo";
                    imageResource2.ContentId = "excel";
                    imageResource3.ContentId = "mailfoot";
                    htmlView.LinkedResources.Add(imageResource);
                    htmlView.LinkedResources.Add(imageResource2);
                    htmlView.LinkedResources.Add(imageResource3);
                    mail.AlternateViews.Add(htmlView);


                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    
                    
                    client.Send(mail);
                    
                    response = true;
                }

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
               
            }
            return response;
        }
    }
}
