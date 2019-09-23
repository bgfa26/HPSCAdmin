using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TimesheetCreationProcess.common.entities;

namespace TimesheetProcess.model.emailservice
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
        public void SendReminder(List<Employee> employees, int type)
        {
            try
            {
                foreach (Employee employee in employees)
                {
                    MailMessage msg = new MailMessage();
                    msg.To.Add(new MailAddress(employee.email, employee.email));
                    msg.From = new MailAddress(EmailManagementResources.Email, EmailManagementResources.Email);
                    msg.Subject = EmailManagementResources.TimesheetHeader;
                    if (type == 1)
                    {
                        msg.Body = EmailManagementResources.TimesheetReminderBody;
                    }
                    else if (type == 0)
                    {
                        msg.Body = EmailManagementResources.LateTimesheetBody;
                    }
                    else
                    {
                        msg.Body = EmailManagementResources.TimesheetTodayBody;
                    }
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
            }
            catch (Exception ex)
            {}
        }
    }
}
