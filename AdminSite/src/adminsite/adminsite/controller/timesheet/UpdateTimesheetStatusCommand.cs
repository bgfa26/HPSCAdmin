using adminsite.common.entities;
using adminsite.model.timesheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.timesheet
{
    public class UpdateTimesheetStatusCommand : Command
    {
        Timesheet timesheetToUpdate;
        int result;
        public UpdateTimesheetStatusCommand(Timesheet timesheetToUpdate)
        {
            this.timesheetToUpdate = timesheetToUpdate;
        }

        public override void Execute()
        {
            try
            {
                DAOTimesheet dao = new DAOTimesheet();
                result = dao.UpdateTimesheetStatus(timesheetToUpdate);
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