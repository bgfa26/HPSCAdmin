using adminsite.common.entities;
using adminsite.model.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.hrm
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para obtener todas las unidades organizacionales
    /// </summary>
    public class GetAllOrganizationalUnitsCommand : Command
    {
        List<OrganizationalUnit> results;

        public override void Execute()
        {
            try
            {
                DAOHumanResourcesManagement dao = new DAOHumanResourcesManagement();
                results = dao.GetAllOrganizationalUnits();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que retorna el resultado obtenido en la BD
        /// </summary>
        /// <returns>Retorna una lista de unidades organizacionales</returns>
        public List<OrganizationalUnit> GetResults()
        {
            return results;
        }
    }
}