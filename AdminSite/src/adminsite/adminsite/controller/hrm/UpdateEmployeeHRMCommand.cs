﻿using adminsite.common.entities;
using adminsite.model.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.hrm
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para actualizar la informacion del empleado
    /// </summary>
    public class UpdateEmployeeHRMCommand : Command
    {
        Employee employeeToModify;
        int result;
        public UpdateEmployeeHRMCommand(Employee employeeToModify)
        {
            this.employeeToModify = employeeToModify;
        }

        public override void Execute()
        {
            try
            {
                DAOHumanResourcesManagement dao = new DAOHumanResourcesManagement();
                result = dao.UpdateEmployeePositionUnit(employeeToModify);
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