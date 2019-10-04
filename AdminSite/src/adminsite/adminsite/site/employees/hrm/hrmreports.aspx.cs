using adminsite.common.entities;
using adminsite.controller.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.hrm
{
    public partial class hrmreports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected bool ValidateDateRange(DateTime initDate, DateTime endDate)
        {
            if ((initDate.Day == 1) && (endDate.Day == 15))
            {
                return true;
            }
            else
            {
                if (initDate.Month == endDate.Month)
                {
                    switch (initDate.Month)
                    {
                        case 1:
                            if ((initDate.Day == 16) && (endDate.Day == 31))
                            {
                                return true;
                            }
                            break;
                        case 2:
                            if ((initDate.Day == 16) && (endDate.Day == 28))
                            {
                                return true;
                            }
                            else if ((initDate.Day == 16) && (endDate.Day == 29))
                            {
                                return true;
                            }
                            break;
                        case 3:
                            if ((initDate.Day == 16) && (endDate.Day == 31))
                            {
                                return true;
                            }
                            break;
                        case 4:
                            if ((initDate.Day == 16) && (endDate.Day == 30))
                            {
                                return true;
                            }
                            break;
                        case 5:
                            if ((initDate.Day == 16) && (endDate.Day == 31))
                            {
                                return true;
                            }
                            break;
                        case 6:
                            if ((initDate.Day == 16) && (endDate.Day == 30))
                            {
                                return true;
                            }
                            break;
                        case 7:
                            if ((initDate.Day == 16) && (endDate.Day == 31))
                            {
                                return true;
                            }
                            break;
                        case 8:
                            if ((initDate.Day == 16) && (endDate.Day == 31))
                            {
                                return true;
                            }
                            break;
                        case 9:
                            if ((initDate.Day == 16) && (endDate.Day == 30))
                            {
                                return true;
                            }
                            break;
                        case 10:
                            if ((initDate.Day == 16) && (endDate.Day == 31))
                            {
                                return true;
                            }
                            break;
                        case 11:
                            if ((initDate.Day == 16) && (endDate.Day == 30))
                            {
                                return true;
                            }
                            break;
                        case 12:
                            if ((initDate.Day == 16) && (endDate.Day == 31))
                            {
                                return true;
                            }
                            break;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        protected void acceptBtn_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void BindData()
        {
            try
            {
                Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                List<Report> reports = new List<Report>();
                String init = dateinit.Text;
                String end = dateend.Text;
                if (loggedEmployee != null)
                {
                    if (!((loggedEmployee.organizationalUnit.Equals("Administración")) && (loggedEmployee.positionName.Equals("Gerente de Talento Humano"))) &&
                        !((loggedEmployee.organizationalUnit.Equals("Contraloría")) && (loggedEmployee.positionName.Equals("Contralor de Gestión"))) &&
                        !((loggedEmployee.organizationalUnit.Equals("Directiva")) && (loggedEmployee.positionName.Equals("Director"))))
                    {
                        Response.Redirect("~/site/employees/dashboard.aspx", false);
                    }
                    if ((!init.Equals("")) && (!end.Equals("")))
                    {
                        DateTime initDate = Convert.ToDateTime(init);
                        DateTime endDate = Convert.ToDateTime(end);
                        if (ValidateDateRange(initDate, endDate))
                        {
                            int report = Int32.Parse(reportsDropList.SelectedValue);
                            GetHRMReportCommand cmd = new GetHRMReportCommand(report, initDate, endDate);
                            cmd.Execute();
                            reports = cmd.GetResults();
                            repReports.DataSource = reports;
                            repReports.DataBind();
                            if ((report == 0) || (report == 1))
                            {
                                headerOUACP.Text = "Unidad organizacional";
                                footerOUACP.Text = "Unidad organizacional";
                            }
                            else
                            {
                                headerOUACP.Text = "Cuentas";
                                footerOUACP.Text = "Cuentas";
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Debe seleccionar un rango de fechas válido', 'error')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Debe seleccionar la fecha de inicio y de fin', 'error')", true);
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
}