using adminsite.common.entities;
using adminsite.model.timesheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.timesheet
{
    public class GetAllWorkloadsByTimesheetCommand : Command
    {
        Timesheet timesheet;
        Timesheet result;

        public GetAllWorkloadsByTimesheetCommand(Timesheet timesheet)
        {
            this.timesheet = timesheet;
        }

        public override void Execute()
        {
            try
            {
                DAOTimesheet dao = new DAOTimesheet();
                result = dao.GetAllWorkloadsByTimesheet(timesheet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que retorna el resultado obtenido en la BD
        /// </summary>
        /// <returns>Retorna una lista de cargas de trabajo</returns>
        public Timesheet GetResults()
        {
            return result;
        }
    }
}