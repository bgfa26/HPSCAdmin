using adminsite.common.entities;
using adminsite.model.timesheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.timesheet
{
    public class GetAllACPPerOUCommand : Command
    {
        List<AccountCoursePermit> results;
        OrganizationalUnit unit;

        public GetAllACPPerOUCommand(OrganizationalUnit unit)
        {
            this.unit = unit;
        }

        public override void Execute()
        {
            try
            {
                DAOTimesheet dao = new DAOTimesheet();
                results = dao.GetAllACPPerOU(unit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que retorna el resultado obtenido en la BD
        /// </summary>
        /// <returns>Retorna una lista de ACP</returns>
        public List<AccountCoursePermit> GetResults()
        {
            return results;
        }
    }
}