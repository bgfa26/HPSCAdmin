using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetCreationProcess.common.entities;
using TimesheetCreationProcess.model.employee;
using TimesheetCreationProcess.model.timesheet;

namespace TimesheetCreationProcess.controller.timesheet
{
    class AddTimesheetsPerEmployeeCommand : Command
    {
        int result;

        public override void Execute()
        {
            try
            {
                DAOEmployee daoEmployee = new DAOEmployee();
                List<Employee> employees = daoEmployee.GetEmployees();
                DAOTimesheet dao = new DAOTimesheet();
                result = dao.AddTimesheetsPerEmployee(employees);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que retorna el resultado obtenido en la BD
        /// </summary>
        /// <returns>Retorna un entero</returns>
        public int GetResult()
        {
            return result;
        }
    }
}
