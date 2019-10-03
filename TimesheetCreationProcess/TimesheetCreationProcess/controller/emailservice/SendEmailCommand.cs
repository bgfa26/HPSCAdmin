using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetCreationProcess.common.entities;
using TimesheetCreationProcess.controller;
using TimesheetCreationProcess.model.employee;
using TimesheetProcess.model.emailservice;

namespace TimesheetProcess.controller.emailservice
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para realizar el proceso de obtener la informacion de un empleado
    /// </summary>
    class SendEmailCommand : Command
    {
        private int type;
        private static Random random = new Random();
        private DateTime endDate;

        public SendEmailCommand(int type)
        {
            this.type = type;
        }

        public SendEmailCommand(int type, DateTime endDate)
        {
            this.type = type;
            this.endDate = endDate;
        }

        public override void Execute()
        {
            try
            {
                DAOEmployee daoEmployee = new DAOEmployee();
                List<Employee> employees = new List<Employee>();
                if (type == 0)
                {
                    employees = daoEmployee.GetEmployeesOpenTimesheet(endDate);
                }
                else
                {
                    employees = daoEmployee.GetEmployees();
                }
                if (employees.Count > 0)
                {
                    EmailManagement emailService = new EmailManagement();
                    emailService.SendReminder(employees, type);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
