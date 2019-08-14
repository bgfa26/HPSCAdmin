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

        public string GetStringFile(Object statusObj)
        {
            string status = (string)statusObj;
            if (status.Equals("ENTREGADA"))
            {
                return "find";
            }
            else
            {
                return "assign";
            }
        }

        public string GetImageButton(Object statusObj)
        {
            string status = (string)statusObj;
            if (status.Equals("ENTREGADA"))
            {
                return "<asp:ImageButton ID=\"visualize\" runat=\"server\" Text=\"Visualizar\" ImageUrl=\"~/site/employees/img/icons/assign.svg\" Height=\"25px\" Width=\"25px\" ToolTip=\"Visualizar\" />";
            }
            else
            {
                return "<asp:ImageButton ID=\"modify\" runat=\"server\" Text=\"Modificar\" ImageUrl=\"~/site/employees/img/icons/assign.svg\" Height=\"25px\" Width=\"25px\" ToolTip=\"Modificar\" />";
            }
        }
    }
}