using adminsite.common.entities;
using adminsite.controller.acpmanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.acpmanagement
{
    public partial class workloadsperacp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                    string acp = (string)Session["CONSULTED_ACPMANAGEMENT"];
                    if (acp != null)
                    {
                        lblTitle.Text = acp;
                    }
                    else
                    {
                        Session.Remove("CONSULTED_ACPMANAGEMENT");
                        Response.Redirect("~/site/employees/acpmanagement/myacps.aspx", false);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Ha ocurrido un error al cargar la información', 'error')", true);
                }
            }
        }

        protected void acceptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                string acp = (string)Session["CONSULTED_ACPMANAGEMENT"];
                List<Workload> workloads = new List<Workload>();
                String init = dateinit.Text;
                String end = dateend.Text;
                if (acp != null)
                {
                    if ((!init.Equals("")) && (!end.Equals("")))
                    {
                        GetAllWorkloadsByACPCommand cmd = new GetAllWorkloadsByACPCommand(acp, Convert.ToDateTime(init), Convert.ToDateTime(end));
                        cmd.Execute();
                        workloads = cmd.GetResults();
                        repCostCenter.DataSource = workloads;
                        repCostCenter.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Debe seleccionar la fecha de inicio y de fin', 'error')", true);
                    }
                }
                else
                {
                    Session.Remove("CONSULTED_ACP");
                    Response.Redirect("~/site/employees/acpmanagement/myacps.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Ha ocurrido un error al cargar la información', 'error')", true);
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("CONSULTED_ACPMANAGEMENT");
            Response.Redirect("~/site/employees/acpmanagement/myacps.aspx", false);
        }
    }
}