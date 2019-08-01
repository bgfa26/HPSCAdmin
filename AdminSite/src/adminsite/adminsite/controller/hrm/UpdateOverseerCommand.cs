using adminsite.common.entities;
using adminsite.model.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.hrm
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para actualizar el supervisor de una unidad organizacional
    /// </summary>
    public class UpdateOverseerCommand : Command
    {
        OrganizationalUnit unitToModify;
        int result;
        public UpdateOverseerCommand(OrganizationalUnit unitToModify)
        {
            this.unitToModify = unitToModify;
        }

        public override void Execute()
        {
            try
            {
                DAOHumanResourcesManagement dao = new DAOHumanResourcesManagement();
                result = dao.UpdateUnitOverseer(unitToModify);
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