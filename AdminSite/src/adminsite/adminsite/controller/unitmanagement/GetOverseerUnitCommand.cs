using adminsite.common.entities;
using adminsite.model.unitmanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.unitmanagement
{
    public class GetOverseerUnitCommand : Command
    {
        OrganizationalUnit ouToConsult;
        OrganizationalUnit result;
        public GetOverseerUnitCommand(OrganizationalUnit ouToConsult)
        {
            this.ouToConsult = ouToConsult;
        }

        public override void Execute()
        {
            try
            {
                DAOUnitManagement dao = new DAOUnitManagement();
                result = dao.GetOverseerUnit(ouToConsult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que retorna el resultado obtenido en la BD
        /// </summary>
        /// <returns>Retorna una unidad</returns>
        public OrganizationalUnit GetResult()
        {
            return result;
        }
    }
}