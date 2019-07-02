using adminsite.common;
using adminsite.model.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.hrm
{
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

        public List<Employee> GetResult()
        {
            return employees;
        }
    }
}