using adminsite.common.entities;
using adminsite.model.acpmanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.acpmanagement
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para obtener las cargas de trabajo por cuenta/curso/permiso
    /// </summary>
    public class GetAllWorkloadsByACPCommand : Command
    {
        List<Workload> results;
        string id;
        DateTime initDate;
        DateTime endDate;

        public GetAllWorkloadsByACPCommand(string id, DateTime initDate, DateTime endDate)
        {
            this.id = id;
            this.initDate = initDate;
            this.endDate = endDate;
        }

        public override void Execute()
        {
            try
            {
                DAOAccountCoursePermitManagement dao = new DAOAccountCoursePermitManagement();
                results = dao.GetAllWorkloadsByACP(id, initDate, endDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que retorna el resultado obtenido en la BD
        /// </summary>
        /// <returns>Retorna una lista</returns>
        public List<Workload> GetResults()
        {
            return results;
        }
    }
}