using adminsite.common.entities;
using adminsite.model.acp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.acp
{
    public class GetAllAccountCoursePermitPerEmployeeCommand : Command
    {
        List<AccountCoursePermit> results;
        Employee employee;

        public GetAllAccountCoursePermitPerEmployeeCommand(Employee employee)
        {
            this.employee = employee;
        }

        public override void Execute()
        {
            try
            {
                DAOAccountCoursePermit dao = new DAOAccountCoursePermit();
                results = dao.GetAllAccountsCoursesPermitsPerEmployee(employee);
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