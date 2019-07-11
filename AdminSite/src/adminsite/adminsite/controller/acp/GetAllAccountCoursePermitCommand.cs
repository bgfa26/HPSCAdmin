using adminsite.common.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.acp
{
    public class GetAllAccountCoursePermitCommand : Command
    {
        List<AccountCoursePermit> results;

        public override void Execute()
        {
            try
            {
                //DAOAccountCoursePermit dao = new DAOAccountCoursePermit();
                //results = dao.GetAllAccountsCoursesPermits();
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
        public List<AccountCoursePermit> GetResults()
        {
            return results;
        }
    }
}