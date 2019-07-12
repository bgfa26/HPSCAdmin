﻿using adminsite.common;
using adminsite.common.entities;
using adminsite.controller.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.acp
{
    public partial class newacp : System.Web.UI.Page
    {
        private List<Employee> employees = new List<Employee>();
        private List<OrganizationalUnit> units = new List<OrganizationalUnit>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    GetEmployeesCommand cmd = new GetEmployeesCommand();
                    cmd.Execute();
                    employees = cmd.GetResult();
                    GetAllOrganizationalUnitsCommand cmdOu = new GetAllOrganizationalUnitsCommand();
                    cmdOu.Execute();
                    units = cmdOu.GetResults();
                    List<Employee> activeEmployees = new List<Employee>();
                    Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                    string emailExtension = loggedEmployee.email.Split('@')[1];
                    if ((loggedEmployee.organizationalUnit.Equals("Directiva")) && (loggedEmployee.positionName.Equals("Director")))
                    {
                        foreach (Employee employee in employees)
                        {
                            if ((employee.status == 1))
                            {
                                activeEmployees.Add(employee);
                            }
                        }
                    }
                    else
                    {
                        foreach (Employee employee in employees)
                        {
                            if ((employee.status == 1) && (!employee.email.Equals(loggedEmployee.email)))
                            {
                                if (emailExtension.Equals("mt2005.net"))
                                {
                                    if (employee.email.Contains(emailExtension))
                                    {
                                        activeEmployees.Add(employee);
                                    }
                                }
                                else if (emailExtension.Equals("interatec.com"))
                                {
                                    if (employee.email.Contains(emailExtension))
                                    {
                                        activeEmployees.Add(employee);
                                    }
                                }
                                else
                                {
                                    if ((!employee.email.Contains("mt2005.net")) && (!employee.email.Contains("interatec.com")))
                                    {
                                        activeEmployees.Add(employee);
                                    }
                                }
                            }
                        }
                    }
                    if (activeEmployees.Count != 0)
                    {
                        String options = "";
                        foreach (Employee employee in activeEmployees)
                        {
                            String itemValue = "ID de trebajador: " + employee.workerId + ". Nombre: " + employee.firstName + " " + employee.lastName;
                            options +="<option value=\"" + employee.id + "\" label=\"" + itemValue + "\" >";
                        }
                        employeeList.InnerHtml = options;
                    }

                    foreach (OrganizationalUnit unit in units)
                    {
                        if (!unit.name.Equals("Sin unidad"))
                        {
                            organizationalUnitsCkl.Items.Add(new ListItem(unit.name, unit.id.ToString()));
                        }
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
            string acpId = id.Value;
            string acpName = name.Value;
            string acptype = type.SelectedValue;
            String init = dateinit.Text;
            String end = dateend.Text;
            string administrator = admin.Value;
            List<string> selectedUnits = organizationalUnitsCkl.Items.Cast<ListItem>()
               .Where(li => li.Selected)
               .Select(li => li.Value)
               .ToList();
        }
    }
}