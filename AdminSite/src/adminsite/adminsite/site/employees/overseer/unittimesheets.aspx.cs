using adminsite.common.entities;
using adminsite.controller.unitmanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.overseer
{
    public partial class unittimeshets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                    if (loggedEmployee != null)
                    {
                        OrganizationalUnit organizationalUnit = new OrganizationalUnit();
                        organizationalUnit.overseer = loggedEmployee.id;
                        GetOverseerUnitCommand _cmd = new GetOverseerUnitCommand(organizationalUnit);
                        _cmd.Execute();
                        organizationalUnit = _cmd.GetResult();
                        if (organizationalUnit.id != -1)
                        {
                            GetTimesheetsByUnitCommand cmd = new GetTimesheetsByUnitCommand(loggedEmployee);
                            cmd.Execute();
                            List<Timesheet> timesheetsList = cmd.GetResults();
                            repTimesheet.DataSource = timesheetsList;
                            repTimesheet.DataBind();
                        }
                        else
                        {
                            Session.RemoveAll();
                            Response.Redirect("~/site/employees/dashboard.aspx");
                        }
                    }
                    else
                    {
                        Session.Remove("EMPLOYEE_EMAIL");
                        Session.RemoveAll();
                        Response.Redirect("~/site/usermanagement/login.aspx", false);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Ha ocurrido un error al cargar la información', 'error')", true);
                }
            }
        }

        public string GetStringAction(Object statusObj)
        {
            string status = (string)statusObj;
            if (status.Equals("ENTREGADA"))
            {
                return "Visualizar";
            }
            else
            {
                return "Modificar";
            }
        }

        protected void repTimesheet_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = ((Label)repTimesheet.Items[e.Item.ItemIndex].FindControl("timesheetId")).Text;
            Session["CONSULTED_TIMESHEET_OVERSEER"] = id;
            Response.Redirect("~/site/employees/overseer/employeetimesheet.aspx");
        }
    }
}