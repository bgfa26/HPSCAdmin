using adminsite.common;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.usermanagement
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para realizar el proceso de validacion de existencia de un email, cedula e identificador de trabajador
    /// </summary>
    public class EmailIDVerificationCommand : Command
    {
        Employee employeeToConsult;
        int result;
        public EmailIDVerificationCommand(Employee employeeToConsult)
        {
            this.employeeToConsult = employeeToConsult;
        }

        public override void Execute()
        {
            try
            {
                DAOUserManagement dao = new DAOUserManagement();
                result = dao.ValidateDuplicatedIdEmail(employeeToConsult);
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