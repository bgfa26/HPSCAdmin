using adminsite.common.entities;
using adminsite.model.timesheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.timesheet
{
    public class GetTimesheetsByEmployeeCommand : Command
    {
        Employee employee;
        List<Timesheet> results;

        public GetTimesheetsByEmployeeCommand(Employee employee)
        {
            this.employee = employee;
        }

        public override void Execute()
        {
            try
            {
                DAOTimesheet dao = new DAOTimesheet();
                results = dao.GetTimesheetsByEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que retorna el resultado obtenido en la BD
        /// </summary>
        /// <returns>Retorna una lista de hojas de trabajo</returns>
        public List<Timesheet> GetResults()
        {
            return results;
        }
    }
}