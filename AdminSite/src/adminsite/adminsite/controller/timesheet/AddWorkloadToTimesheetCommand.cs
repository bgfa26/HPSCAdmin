using adminsite.common.entities;
using adminsite.model.timesheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.timesheet
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para agregar una carga de trabajo a una hoja de tiempo
    /// </summary>
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