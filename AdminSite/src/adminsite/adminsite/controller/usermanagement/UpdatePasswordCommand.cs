using adminsite.common;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.usermanagement
{
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

        public int GetResult()
        {
            return result;
        }
    }
}