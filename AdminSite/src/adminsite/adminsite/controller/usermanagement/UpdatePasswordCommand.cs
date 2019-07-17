using adminsite.common.entities;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.usermanagement
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para realizar el proceso de actualizar la contraseña de un empleado
    /// </summary>
    public class UpdatePasswordCommand : Command
    {
        Employee employeeToModify;
        int result;
        public UpdatePasswordCommand(Employee employeeToModify)
        {
            this.employeeToModify = employeeToModify;
        }

        public override void Execute()
        {
            try
            {
                DAOUserManagement dao = new DAOUserManagement();
                result = dao.UpdateEmployeePassword(employeeToModify);
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