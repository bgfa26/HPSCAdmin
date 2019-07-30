using adminsite.common;
using adminsite.common.entities;
using adminsite.controller.acp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.acp
{
    public partial class costcenterlist : System.Web.UI.Page
    {
        private List<AccountCoursePermit> acpList = new List<AccountCoursePermit>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                try
                {
                    Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                    if (!((loggedEmployee.organizationalUnit.Equals("Gerente de Talento Humano")) && (loggedEmployee.positionName.Equals("Administración"))) &&
                        !((loggedEmployee.organizationalUnit.Equals("Contralor de Gestión")) && (loggedEmployee.positionName.Equals("Contraloría"))) &&
                        !((loggedEmployee.organizationalUnit.Equals("Directiva")) && (loggedEmployee.positionName.Equals("Director"))))
                    {
                        Response.Redirect("~/site/employees/dashboard.aspx", false);
                    }
                    GetAllAccountCoursePermitCommand cmd = new GetAllAccountCoursePermitCommand();
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

        public string getAssociatedUnitsString(Object list)
        {
            List<CostCenter> costCenters = (List<CostCenter>)list;
            string associatedUnits = "";
            foreach (CostCenter costCenter in costCenters)
            {
                associatedUnits += costCenter.organizationalUnit.name + ", ";
            }
            associatedUnits = associatedUnits.Remove(associatedUnits.Length - 1);
            associatedUnits = associatedUnits.Remove(associatedUnits.Length - 1);
            return associatedUnits;
        }

        public string getEndDate(Object date)
        {
            string endDate = string.Format("{0:dd/MM/yyyy}", date);
            if (endDate.Contains("31/12/9999")){
                endDate = "No tiene fecha de culminación";
            }
            return endDate;
        }

        protected void repCostCenter_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ImageButton action = (ImageButton)e.CommandSource;
            string actionString = action.ID;
            if (action.ID.Equals("delete"))
            {
                try
                {
                    string id = ((Label)repCostCenter.Items[e.Item.ItemIndex].FindControl("costCenterId")).Text;
                    AccountCoursePermit acpToDelete = new AccountCoursePermit(id);
                    DeleteACPCommand cmd = new DeleteACPCommand(acpToDelete);
                    cmd.Execute();
                    int result = cmd.GetResult();
                    if (result == 200)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "sweetAlert('Se ha eliminado exitosamente', 'success', '/site/employees/acp/costcenterlist.aspx')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('No se ha podido eliminar el elemento seleccionado', 'error')", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('No se ha podido eliminar el elemento seleccionado', 'error')", true);
                }
            }
            else if (action.ID.Equals("modify"))
            {
                string id = ((Label)repCostCenter.Items[e.Item.ItemIndex].FindControl("costCenterId")).Text;
                Session["CONSULTED_ACP"] = id;
                Response.Redirect("~/site/employees/acp/acpdata.aspx");
            }
        }
    }
}