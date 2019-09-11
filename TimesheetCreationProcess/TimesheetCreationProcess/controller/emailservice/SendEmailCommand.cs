using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetCreationProcess.common.entities;
using TimesheetCreationProcess.controller;
using TimesheetProcess.model.emailservice;

namespace TimesheetProcess.controller.emailservice
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para realizar el proceso de obtener la informacion de un empleado
    /// </summary>
    class SendEmailCommand : Command
    {
        Employee employee;
        private int type;
        private static Random random = new Random();

        public SendEmailCommand(Employee employee, int type)
        {
            this.employee = employee;
            this.type = type;
        }

        public override void Execute()
        {
            try
            {
                EmailManagement emailService = new EmailManagement();
                emailService.SendReminder(employee, type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
