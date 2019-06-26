using adminsite.common;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.usermanagement
{
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

        public int GetResult()
        {
            return result;
        }
    }
}