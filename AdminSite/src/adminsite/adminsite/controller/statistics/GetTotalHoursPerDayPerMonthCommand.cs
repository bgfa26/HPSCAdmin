﻿using adminsite.common.entities;
using adminsite.model.statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.statistics
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para realizar la grafica de las horas utilizadas en cada día de la semana
    /// </summary>
    public class GetTotalHoursPerDayPerMonthCommand : Command
    {
        List<Statistic> results;
        int month;
        int year;

        public GetTotalHoursPerDayPerMonthCommand(int month, int year)
        {
            this.month = month;
            this.year = year;
        }

        public override void Execute()
        {
            try
            {
                DAOStatistics dao = new DAOStatistics();
                results = dao.GetTotalHoursPerDayPerMonth(month, year);
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