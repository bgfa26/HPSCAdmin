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

            if (!Page.IsPostBack)
            {
                try
                {
                    GetEmployeesCommand cmd = new GetEmployeesCommand();
                    cmd.Execute();
                    employeeList = cmd.GetResult();
                    List<Employee> activeEmployees = new List<Employee>();
                    Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                    string emailExtension = loggedEmployee.email.Split('@')[1];
                    if ((loggedEmployee.organizationalUnit.Equals("Directiva")) && (loggedEmployee.positionName.Equals("Director")))
                    {
                        foreach (Employee employee in employeeList)
                        {
                            if ((employee.status == 1))
                            {
                                activeEmployees.Add(employee);
                            }
                        }
                    }
                    else if (((loggedEmployee.organizationalUnit.Equals("Gerente de Talento Humano")) && (loggedEmployee.positionName.Equals("Administración"))) || ((loggedEmployee.organizationalUnit.Equals("Contralor de Gestión")) && (loggedEmployee.positionName.Equals("Operaciones"))))
                    {
                        foreach (Employee employee in employeeList)
                        {
                            if ((employee.status == 1) && (!employee.email.Equals(loggedEmployee.email)))
                            {
                                if (emailExtension.Equals("mt2005.net"))
                                {
                                    if (employee.email.Contains(emailExtension))
                                    {
                                        activeEmployees.Add(employee);
                                    }
                                }
                                else if (emailExtension.Equals("interatec.com"))
                                {
                                    if (employee.email.Contains(emailExtension))
                                    {
                                        activeEmployees.Add(employee);
                                    }
                                }
                                else
                                {
                                    if ((!employee.email.Contains("mt2005.net")) && (!employee.email.Contains("interatec.com")))
                                    {
                                        activeEmployees.Add(employee);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/site/employees/dashboard.aspx", false);
                    }
                    if (activeEmployees.Count != 0)
                    {
                        repEmployees.DataSource = activeEmployees;
                        repEmployees.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Ha ocurrido un error al cargar la información', 'error')", true);
                }
            }
        }

        protected void repEmployees_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ImageButton action = (ImageButton)e.CommandSource;
            string actionString = action.ID;
            if (action.ID.Equals("delete"))
            {
                try
                {
                    string id = ((Label)repEmployees.Items[e.Item.ItemIndex].FindControl("employeeId")).Text;
                    Employee employeeToDelete = new Employee(Int32.Parse(id));
                    DeleteEmployeeCommand cmd = new DeleteEmployeeCommand(employeeToDelete);
                    cmd.Execute();
                    int result = cmd.GetResult();
                    if (result == 200)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "sweetAlert('Se ha eliminado el empleado exitosamente', 'success', '/site/employees/hrm/employeelist.aspx')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('El empleado no ha podido ser eliminado', 'error')", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('El empleado no ha podido ser eliminado', 'error')", true);
                }
            }
            else if (action.ID.Equals("modify"))
            {
                string email = ((Label)repEmployees.Items[e.Item.ItemIndex].FindControl("employeeEmail")).Text;
                Session["CONSULTED_EMAIL"] = email;
                Response.Redirect("~/site/employees/hrm/employeedata.aspx", false);
            }
        }
    }
}