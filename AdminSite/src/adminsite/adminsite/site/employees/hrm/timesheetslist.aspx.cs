﻿using adminsite.common.entities;
using adminsite.controller.hrm;
using adminsite.controller.statistics;
using adminsite.controller.unitmanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.hrm
{
    public partial class timesheetslist : System.Web.UI.Page
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
                        if (!((loggedEmployee.organizationalUnit.Equals("Administración")) && (loggedEmployee.positionName.Equals("Gerente de Talento Humano"))) &&
                            !((loggedEmployee.organizationalUnit.Equals("Contraloría")) && (loggedEmployee.positionName.Equals("Contralor de Gestión"))) &&
                            !((loggedEmployee.organizationalUnit.Equals("Directiva")) && (loggedEmployee.positionName.Equals("Director"))))
                        {
                            Response.Redirect("~/site/employees/dashboard.aspx", false);
                        }
                        GetAllYearsCommand cmd = new GetAllYearsCommand();
                        cmd.Execute();
                        List<string> years = cmd.GetResults();
                        ListItem item;
                        foreach (string year in years)
                        {
                            item = new ListItem(year, year);
                            yearsDropList.Items.Insert(yearsDropList.Items.Count, item);
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
            Session["CONSULTED_TIMESHEET_HRM"] = id;
            Response.Redirect("~/site/employees/hrm/timesheetemployee.aspx");
        }

        protected void acceptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                if (loggedEmployee != null)
                {
                    string emailExtension = loggedEmployee.email.Split('@')[1];
                    if (!((loggedEmployee.organizationalUnit.Equals("Administración")) && (loggedEmployee.positionName.Equals("Gerente de Talento Humano"))) &&
                        !((loggedEmployee.organizationalUnit.Equals("Contraloría")) && (loggedEmployee.positionName.Equals("Contralor de Gestión"))) &&
                        !((loggedEmployee.organizationalUnit.Equals("Directiva")) && (loggedEmployee.positionName.Equals("Director"))))
                    {
                        Response.Redirect("~/site/employees/dashboard.aspx", false);
                    }
                    if (!yearsDropList.SelectedValue.Equals(""))
                    {
                        int selectedYear = Int32.Parse(yearsDropList.SelectedValue);
                        GetTimesheetsByEmployeeCommand cmd = new GetTimesheetsByEmployeeCommand(selectedYear);
                        cmd.Execute();
                        List<Timesheet> timesheetsList = cmd.GetResults();
                        List<Timesheet> realTimesheetsList = new List<Timesheet>();

                        if ((loggedEmployee.organizationalUnit.Equals("Directiva")) && (loggedEmployee.positionName.Equals("Director")))
                        {
                            realTimesheetsList = timesheetsList;
                        }
                        else if (((loggedEmployee.organizationalUnit.Equals("Administración")) && (loggedEmployee.positionName.Equals("Gerente de Talento Humano"))) || ((loggedEmployee.organizationalUnit.Equals("Contraloría")) && (loggedEmployee.positionName.Equals("Contralor de Gestión"))))
                        {
                            foreach (Timesheet timesheet in timesheetsList)
                            {
                                if ((!timesheet.employee.email.Equals(loggedEmployee.email)))
                                {
                                    if (emailExtension.Equals("mt2005.net"))
                                    {
                                        if (timesheet.employee.email.Contains(emailExtension))
                                        {
                                            realTimesheetsList.Add(timesheet);
                                        }
                                    }
                                    else if (emailExtension.Equals("interatec.com"))
                                    {
                                        if (timesheet.employee.email.Contains(emailExtension))
                                        {
                                            realTimesheetsList.Add(timesheet);
                                        }
                                    }
                                    else
                                    {
                                        if ((!timesheet.employee.email.Contains("mt2005.net")) && (!timesheet.employee.email.Contains("interatec.com")))
                                        {
                                            realTimesheetsList.Add(timesheet);
                                        }
                                    }
                                }
                            }
                        }
                        repTimesheet.DataSource = realTimesheetsList;
                        repTimesheet.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Debe seleccionar un año', 'error')", true);
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