using adminsite.common.entities;
using adminsite.model.acp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.acp
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para obtener todas las cuentas/cursos/permisos de la BD
    /// </summary>
    public class GetAllAccountCoursePermitCommand : Command
    {
        List<AccountCoursePermit> results;

        public override void Execute()
        {
            try
            {
                DAOAccountCoursePermit dao = new DAOAccountCoursePermit();
                results = dao.GetAllAccountsCoursesPermits();
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
        public List<AccountCoursePermit> GetResults()
        {
            return results;
        }
    }
}