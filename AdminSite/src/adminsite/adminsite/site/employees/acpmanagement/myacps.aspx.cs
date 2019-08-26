using adminsite.common.entities;
using adminsite.controller.acp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.acpmanagement
{
    public partial class myacps : System.Web.UI.Page
    {
        private List<AccountCoursePermit> acpList = new List<AccountCoursePermit>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                    if (!((loggedEmployee.organizationalUnit.Equals("Administración")) && (loggedEmployee.positionName.Equals("Gerente de Talento Humano"))) &&
                        !((loggedEmployee.organizationalUnit.Equals("Contraloría")) && (loggedEmployee.positionName.Equals("Contralor de Gestión"))) &&
                        !((loggedEmployee.organizationalUnit.Equals("Directiva")) && (loggedEmployee.positionName.Equals("Director"))))
                    {
                        Response.Redirect("~/site/employees/dashboard.aspx", false);
                    }
                    GetAllAccountCoursePermitPerEmployeeCommand cmd = new GetAllAccountCoursePermitPerEmployeeCommand(loggedEmployee);
                    cmd.Execute();
                    acpList = cmd.GetResults();
                    List<AccountCoursePermit> activeAcp = new List<AccountCoursePermit>();
                    foreach (AccountCoursePermit acp in acpList)
                    {
                        if ((acp.status == 1))
                        {
                            activeAcp.Add(acp);
                        }
                    }
                    if (activeAcp.Count != 0)
                    {
                        repCostCenter.DataSource = activeAcp;
                        repCostCenter.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Ha ocurrido un error al cargar la información', 'error')", true);
                }
            }
        }

        public string GetEndDate(Object date)
        {
            string endDate = string.Format("{0:dd/MM/yyyy}", date);
            if (endDate.Contains("31/12/9999"))
            {
                endDate = "No tiene fecha de culminación";
            }
            return endDate;
        }
    }
}