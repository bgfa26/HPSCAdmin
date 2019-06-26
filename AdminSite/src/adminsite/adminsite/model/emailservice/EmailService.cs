using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using adminsite.common;

namespace adminsite.model.emailservice
{
    public class EmailService
    {
        public void SendVerificationCode(Employee employee, string hexCode)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress(employee.email, employee.email));
                msg.From = new MailAddress(EmailResources.Email, EmailResources.Email);
                msg.Subject = EmailResources.VerificationHeader;
                msg.Body = EmailResources.VerificationBody + hexCode;
                msg.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(EmailResources.Email, EmailResources.Password);
                client.Port = 587; // You can use Port 25 if 587 is blocked
                //client.Host = "smtp.office365.com";
                client.Host = "smtp-mail.outlook.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}