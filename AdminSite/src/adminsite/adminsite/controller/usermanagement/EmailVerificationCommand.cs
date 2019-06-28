using adminsite.common;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.usermanagement
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para realizar el proceso de verificacion la existencia de un empleado
    /// </summary>
    public class EmailVerificationCommand : Command
    {
        Employee employeeToConsult;
        Employee result;
        public EmailVerificationCommand (Employee employeeToConsult)
        {
            this.employeeToConsult = employeeToConsult;
        }

        public override void Execute()
        {
            try
            {
                DAOUserManagement dao = new DAOUserManagement();
                result = dao.EmailVerification(employeeToConsult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que retorna el resultado obtenido en la BD
        /// </summary>
        /// <returns>Retorna un Employee</returns>
        public Employee GetResult()
        {
            return result;
        }
    }
}