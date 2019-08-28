using adminsite.common.entities;
using adminsite.model.unitmanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.unitmanagement
{
    public class GetTimesheetsByUnitCommand : Command
    {
        Employee employee;
        List<Timesheet> results;

        public GetTimesheetsByUnitCommand(Employee employee)
        {
            this.employee = employee;
        }

        public override void Execute()
        {
            try
            {
                DAOUnitManagement dao = new DAOUnitManagement();
                results = dao.GetTimesheetsByUnit(employee);
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