using adminsite.common.entities;
using adminsite.model.acp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.acp
{
    public class GetAccountCoursePermitCommand : Command
    {
        AccountCoursePermit acpToConsult;
        AccountCoursePermit result;
        public GetAccountCoursePermitCommand(AccountCoursePermit acpToConsult)
        {
            this.acpToConsult = acpToConsult;
        }

        public override void Execute()
        {
            try
            {
                DAOAccountCoursePermit dao = new DAOAccountCoursePermit();
                result = dao.GetAccountCoursesPermit(acpToConsult);
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
        public AccountCoursePermit GetResult()
        {
            return result;
        }
    }
}