using adminsite.common.entities;
using adminsite.model.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.hrm
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para obtener las hojas de trabajo de cada empleado
    /// </summary>
    public class GetDeliveredTimesheetsCommand : Command
    {
        int year;
        List<Timesheet> results;

        public GetDeliveredTimesheetsCommand(int year)
        {
            this.year = year;
        }

        public override void Execute()
        {
            try
            {
                DAOHumanResourcesManagement dao = new DAOHumanResourcesManagement();
                results = dao.GetDeliveredTimesheets(year);
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