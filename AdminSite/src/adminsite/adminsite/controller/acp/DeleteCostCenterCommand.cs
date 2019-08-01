using adminsite.common.entities;
using adminsite.model.acp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.acp
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para eliminar un centro de costo
    /// </summary>
    public class DeleteCostCenterCommand : Command
    {
        AccountCoursePermit accountCoursePermit;
        int result;
        public DeleteCostCenterCommand(AccountCoursePermit accountCoursePermit)
        {
            this.accountCoursePermit = accountCoursePermit;
        }

        public override void Execute()
        {
            try
            {
                DAOAccountCoursePermit dao = new DAOAccountCoursePermit();
                result = dao.DeleteCostCenter(accountCoursePermit);
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