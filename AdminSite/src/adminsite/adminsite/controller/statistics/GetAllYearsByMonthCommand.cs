using adminsite.model.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.statistics
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para realizar la obtencion de los años en los cuales hay informacion
    /// </summary>
    public class GetAllYearsByMonthCommand : Command
    {
        List<string> results;
        int month;

        public GetAllYearsByMonthCommand(int month)
        {
            this.month = month;
        }

        public override void Execute()
        {
            try
            {
                DAOStatistics dao = new DAOStatistics();
                results = dao.GetAllYearsByMonth(month);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que retorna el resultado obtenido en la BD
        /// </summary>
        /// <returns>Retorna una lista de strings</returns>
        public List<string> GetResults()
        {
            return results;
        }
    }
}