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
               /* Label serial = (Label)repPeople.Items[e.Item.ItemIndex].FindControl("serialeq");
                Label numequipo = (Label)repPeople.Items[e.Item.ItemIndex].FindControl("numeq");
                Response.Redirect("/Vista/Empleados/gestion-equipos/modificarequipo.aspx?serial=" + serial.Text + "&numequipo=" + numequipo.Text);
            */
            }
        }
    }
}