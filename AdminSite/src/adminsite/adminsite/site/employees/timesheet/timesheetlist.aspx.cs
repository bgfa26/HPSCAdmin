 using adminsite.common.entities;
using adminsite.controller.timesheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.timesheet
{
    public partial class timesheetlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                    GetTimesheetsByEmployeeCommand cmd = new GetTimesheetsByEmployeeCommand(loggedEmployee);
                    cmd.Execute();
                    List<Timesheet> timesheetsList = cmd.GetResults();
                    repTimesheet.DataSource = timesheetsList;
                    repTimesheet.DataBind();
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
            string timesheetStatus = ((Label)repTimesheet.Items[e.Item.ItemIndex].FindControl("status")).Text;
            if ((timesheetStatus.Equals("ENTREGADA")) || (timesheetStatus.Contains("APROBADA")))
            {
                string id = ((Label)repTimesheet.Items[e.Item.ItemIndex].FindControl("timesheetId")).Text;
                Session["CONSULTED_TIMESHEET"] = id;
                Response.Redirect("~/site/employees/timesheet/timesheetdata.aspx");
            }
            else
            {
                string id = ((Label)repTimesheet.Items[e.Item.ItemIndex].FindControl("timesheetId")).Text;
                Session["CONSULTED_TIMESHEET"] = id;
                Response.Redirect("~/site/employees/timesheet/activetimesheet.aspx");
            }
        }
    }
}