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
    public class EmailManagement
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
                msg.From = new MailAddress(EmailManagementResources.Email, EmailManagementResources.Email);
                msg.Subject = EmailManagementResources.VerificationHeader;
                msg.Body = EmailManagementResources.VerificationBody + hexCode;
                msg.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential(EmailManagementResources.Email, EmailManagementResources.Password);
                client.EnableSsl = true;
                client.Port = 587; // Usar puerto 25 o 587
                client.Host = "smtp.office365.com";
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