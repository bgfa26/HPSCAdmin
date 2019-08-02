using adminsite.common.entities;
using adminsite.model.acp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.acp
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para crear una nueva cuenta/curso/permiso
    /// </summary>
    public class CreateNewACPCommand : Command
    {
        AccountCoursePermit acpToInsert;
        int result;
        public CreateNewACPCommand(AccountCoursePermit acpToInsert)
        {
            this.acpToInsert = acpToInsert;
        }

        public override void Execute()
        {
            try
            {
                DAOAccountCoursePermit dao = new DAOAccountCoursePermit();
                result = dao.AddAccountCoursePermit(acpToInsert);
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