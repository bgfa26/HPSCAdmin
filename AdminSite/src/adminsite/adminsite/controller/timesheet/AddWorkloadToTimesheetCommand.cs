using adminsite.common.entities;
using adminsite.model.timesheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.timesheet
{
    public class AddWorkloadToTimesheetCommand : Command
    {
        Workload workloadToInsert;
        int result;
        public AddWorkloadToTimesheetCommand(Workload workloadToInsert)
        {
            this.workloadToInsert = workloadToInsert;
        }

        public override void Execute()
        {
            try
            {
                DAOTimesheet dao = new DAOTimesheet();
                result = dao.AddWorkloadToTimesheet(workloadToInsert);
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