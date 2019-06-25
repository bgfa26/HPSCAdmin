using adminsite.common;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.usermanagement
{
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
                result = dao.GetEmployeeByEmail(employeeToConsult);
            }
            catch (Exception ex) { }
        }

        public Employee GetResult()
        {
            return result;
        }
    }
}