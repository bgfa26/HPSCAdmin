using adminsite.common.entities;
using adminsite.model.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.hrm
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para realizar el proceso de eliminar un empleado
    /// </summary>
    public class DeleteEmployeeCommand : Command
    {
        Employee employeeToDelete;
        int result;
        public DeleteEmployeeCommand(Employee employeeToDelete)
        {
            this.employeeToDelete = employeeToDelete;
        }

        public override void Execute()
        {
            try
            {
                DAOHumanResourcesManagement dao = new DAOHumanResourcesManagement();
                result = dao.DeleteEmployee(employeeToDelete);
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