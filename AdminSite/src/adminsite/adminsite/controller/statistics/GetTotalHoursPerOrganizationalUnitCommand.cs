using adminsite.common.entities;
using adminsite.model.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.statistics
{
    public class GetTotalHoursPerOrganizationalUnitCommand : Command
    {
        List<Statistic> results;
        int month;
        int year;

        public GetTotalHoursPerOrganizationalUnitCommand(int month, int year)
        {
            this.month = month;
            this.year = year;
        }

        public override void Execute()
        {
            try
            {
                DAOStatistics dao = new DAOStatistics();
                results = dao.GetTotalHoursPerOrganizationalUnit(month, year);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que retorna el resultado obtenido en la BD
        /// </summary>
        /// <returns>Retorna una lista de estadisticas</returns>
        public List<Statistic> GetResults()
        {
            return results;
        }
    }
}