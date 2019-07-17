using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using adminsite.common.entities;

namespace adminsite.model.emailservice
{
    /// <summary>
    /// Clase encargada de enviar correos electronicos
    /// </summary>
    public class EmailService
    {
        /// <summary>
        /// Metodo que envia el codigo de verificacion por correo
        /// </summary>
        /// <param name="employee">Empleado que va a recibir el correo</param>
        /// <param name="hexCode">Codigo hexadecimal a ser enviado</param>
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
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential(EmailResources.Email, EmailResources.Password);
                client.EnableSsl = true;
                client.Port = 587; // Usar puerto 25 o 587
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