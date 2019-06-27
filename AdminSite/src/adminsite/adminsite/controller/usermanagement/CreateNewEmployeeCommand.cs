﻿using adminsite.common;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.usermanagement
{
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

        public int GetResult()
        {
            return result;
        }
    }
}