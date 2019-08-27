using adminsite.common.entities;
using adminsite.controller.acpmanagement;
using adminsite.controller.timesheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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

        protected void bindData()
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
                        DateTime initDate = Convert.ToDateTime(init);
                        DateTime endDate = Convert.ToDateTime(end);
                        if (validateDateRange(initDate, endDate)) {
                            GetAllWorkloadsByACPCommand cmd = new GetAllWorkloadsByACPCommand(acp, initDate, endDate);
                            cmd.Execute();
                            workloads = cmd.GetResults();
                            repCostCenter.DataSource = workloads;
                            repCostCenter.DataBind();
                            DateTime movableDate = initDate;
                            int dayCounter = 1;
                            header16.Visible = true;
                            header15.Visible = true;
                            header14.Visible = true;
                            footer16.Visible = true;
                            footer15.Visible = true;
                            footer14.Visible = true;
                            while (DateTime.Compare(movableDate, endDate) != 1)
                            {
                                switch (dayCounter)
                                {
                                    case 1:
                                        header1.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer1.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 2:
                                        header2.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer2.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 3:
                                        header3.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer3.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 4:
                                        header4.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer4.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 5:
                                        header5.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer5.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 6:
                                        header6.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer6.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 7:
                                        header7.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer7.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 8:
                                        header8.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer8.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 9:
                                        header9.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer9.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 10:
                                        header10.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer10.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 11:
                                        header11.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer11.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 12:
                                        header12.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer12.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 13:
                                        header13.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer13.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 14:
                                        header14.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer14.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 15:
                                        header15.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer15.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                    case 16:
                                        header16.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        footer16.InnerText = movableDate.ToString("dd/MM/yyyy");
                                        break;
                                }
                                movableDate = movableDate.AddDays(1);
                                dayCounter++;
                            }
                            int counter = 0;
                            foreach (RepeaterItem item in repCostCenter.Items)
                            {
                                HtmlTableCell day14 = ((HtmlTableCell)repCostCenter.Items[counter].FindControl("day14"));
                                HtmlTableCell day15 = ((HtmlTableCell)repCostCenter.Items[counter].FindControl("day15"));
                                HtmlTableCell day16 = ((HtmlTableCell)repCostCenter.Items[counter].FindControl("day16"));
                                if (endDate.Day == 30)
                                {
                                    day16.Visible = false;
                                    header16.Visible = false;
                                    footer16.Visible = false;
                                }
                                else if (endDate.Day == 29)
                                {
                                    day16.Visible = false;
                                    day15.Visible = false;
                                    header16.Visible = false;
                                    header15.Visible = false;
                                    footer16.Visible = false;
                                    footer15.Visible = false;
                                }
                                else if (endDate.Day == 15)
                                {
                                    day16.Visible = false;
                                    header16.Visible = false;
                                    footer16.Visible = false;
                                }
                                else if (endDate.Day == 28)
                                {
                                    day16.Visible = false;
                                    day15.Visible = false;
                                    day14.Visible = false;
                                    header16.Visible = false;
                                    header15.Visible = false;
                                    header14.Visible = false;
                                    footer16.Visible = false;
                                    footer15.Visible = false;
                                    footer14.Visible = false;
                                }
                                counter++;
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
                    Session.Remove("CONSULTED_ACP");
                    Response.Redirect("~/site/employees/acpmanagement/myacps.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Ha ocurrido un error al cargar la información', 'error')", true);
            }
        }

        protected void acceptBtn_Click(object sender, EventArgs e)
        {
            bindData();
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("CONSULTED_ACPMANAGEMENT");
            Response.Redirect("~/site/employees/acpmanagement/myacps.aspx", false);
        }

        protected void repCostCenter_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ImageButton action = (ImageButton)e.CommandSource;
            string actionString = action.ID;
            try
            {
                string idString = ((Label)repCostCenter.Items[e.Item.ItemIndex].FindControl("idWorkload")).Text;
                if (!idString.Equals(""))
                {
                    string status = "EN ESPERA";
                    if (action.ID.Equals("update"))
                    {
                        status = "APROBADA";
                    }
                    else if (action.ID.Equals("cancel"))
                    {
                        status = "REPROBADA";
                    }
                    int id = Int32.Parse(idString);
                    Workload workloadToUpdate = new Workload(id, status);
                    UpdateWorkloadStatusCommand cmd = new UpdateWorkloadStatusCommand(workloadToUpdate);
                    cmd.Execute();
                    int result = cmd.GetResult();
                    if (result == 200)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "sweetAlertNoRedirect('Se ha modificado el estatus exitosamente', 'success')", true);
                        bindData();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('No se ha podido actualizar el elemento seleccionado', 'error')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('No se ha podido actualizar el elemento seleccionado', 'error')", true);
            }
        }

        protected bool validateDateRange(DateTime initDate, DateTime endDate)
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
    }
}