using adminsite.common.entities;
using adminsite.model.acp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.acp
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para modificar una cuenta/curso/permiso
    /// </summary>
    public class UpdateAccountCoursePermitCommand : Command
    {
        AccountCoursePermit acpToModify;
        int result;
        public UpdateAccountCoursePermitCommand(AccountCoursePermit acpToModify)
        {
            this.acpToModify = acpToModify;
        }

        public override void Execute()
        {
            try
            {
                DAOAccountCoursePermit dao = new DAOAccountCoursePermit();
                result = dao.UpdateAccountCoursePermit(acpToModify);
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