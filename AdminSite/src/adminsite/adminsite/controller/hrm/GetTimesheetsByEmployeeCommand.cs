using adminsite.common.entities;
using adminsite.model.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.hrm
{
    public class GetTimesheetsByEmployeeCommand : Command
    {
        int year;
        List<Timesheet> results;

        public GetTimesheetsByEmployeeCommand(int year)
        {
            this.year = year;
        }

        public override void Execute()
        {
            try
            {
                DAOHumanResourcesManagement dao = new DAOHumanResourcesManagement();
                results = dao.GetTimesheetsByEmployee(year);
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