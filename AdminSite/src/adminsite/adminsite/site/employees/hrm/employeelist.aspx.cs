using adminsite.common;
using adminsite.controller.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.hrm
{
    public partial class employeelist : System.Web.UI.Page
    {

        private List<Employee> employeeList = new List<Employee>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GetEmployeesCommand cmd = new GetEmployeesCommand();
                cmd.Execute();
                employeeList = cmd.GetResult();
                List<Employee> activeEmployees = new List<Employee>();
                foreach (Employee employee in employeeList)
                {
                    if ((employee.status == 1))
                    {
                        activeEmployees.Add(employee);
                    }
                }
                if (activeEmployees.Count != 0)
                {
                    repEmployees.DataSource = activeEmployees;
                    repEmployees.DataBind();
                }
            }
            catch (Exception ex)
            {
                string script = "alert(\"No se pudo cargar la información en la página, por favor refresque la página\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }
    }
}