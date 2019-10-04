using adminsite.common.entities;
using adminsite.model.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.hrm
{
    public class GetHRMReportCommand : Command
    {
        int report;
        DateTime initDate;
        DateTime endDate;
        List<Report> results;

        public GetHRMReportCommand(int report, DateTime initDate, DateTime endDate)
        {
            this.report = report;
            this.initDate = initDate;
            this.endDate = endDate;
        }

        public override void Execute()
        {
            try
            {
                DAOHumanResourcesManagement dao = new DAOHumanResourcesManagement();
                results = dao.GetTimesheetsReport(initDate, endDate, report);
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
        public List<Report> GetResults()
        {
            return results;
        }
    }
}