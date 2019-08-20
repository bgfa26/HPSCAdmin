using adminsite.model.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.statistics
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para realizar la obtencion de los años de las hojas de tiempo
    /// </summary>
    public class GetAllYearsCommand : Command
    {
        List<string> results;

        public override void Execute()
        {
            try
            {
                DAOStatistics dao = new DAOStatistics();
                results = dao.GetAllYears();
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