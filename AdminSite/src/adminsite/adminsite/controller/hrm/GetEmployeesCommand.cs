using adminsite.common.entities;
using adminsite.model.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.hrm
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para obtener todos los empleados
    /// </summary>
    public class GetEmployeesCommand : Command
    {
        private List<Employee> employees = new List<Employee>();
        public override void Execute()
        {
            try
            {
                DAOHumanResourcesManagement dao = new DAOHumanResourcesManagement();
                employees = dao.GetEmployees();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Metodo que retorna el resultado obtenido en la BD
        /// </summary>
        /// <returns>Retorna una lista de empleados</returns>
        public List<Employee> GetResult()
        {
            return employees;
        }
    }
}