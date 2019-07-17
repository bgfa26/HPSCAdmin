using adminsite.common.entities;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.usermanagement
{

    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para realizar el proceso de registrar un nuevo empleado
    /// </summary>
    public class CreateNewEmployeeCommand : Command
    {
        Employee employeeToInsert;
        int result;
        public CreateNewEmployeeCommand(Employee employeeToInsert)
        {
            this.employeeToInsert = employeeToInsert;
        }

        public override void Execute()
        {
            try
            {
                DAOUserManagement dao = new DAOUserManagement();
                result = dao.AddEmployee(employeeToInsert);
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