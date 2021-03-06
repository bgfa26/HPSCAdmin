﻿using adminsite.common;
using adminsite.common.entities;
using adminsite.controller.hrm;
using adminsite.controller.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.hrm
{
    public partial class employeedata : System.Web.UI.Page
    {

        protected bool checkActiveSession()
        {

            Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
            if (loggedEmployee == null)
            {
                Session.RemoveAll();
                Response.Redirect("~/site/usermanagement/login.aspx", false);
                return false;
            }
            return true;
        }
        private Employee consultedEmployee;
        private int supervisedUnit = -1;
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
                    if (Session["CONSULTED_EMAIL"] != null)
                    {
                        ouDropList.ClearSelection();
                        positionDropList.ClearSelection();
                        superviseDropList.ClearSelection();
                        ouDropList.Items.Clear();
                        positionDropList.Items.Clear();
                        superviseDropList.Items.Clear();

                        string employeeEmail = (string)Session["CONSULTED_EMAIL"];
                        Employee employee = new Employee(employeeEmail);
                        GetEmployeeInformationCommand cmd = new GetEmployeeInformationCommand(employee);
                        GetAllPositionsCommand cmdPositions = new GetAllPositionsCommand();
                        GetAllOrganizationalUnitsCommand cmdUnits = new GetAllOrganizationalUnitsCommand();
                        cmd.Execute();
                        cmdPositions.Execute();
                        cmdUnits.Execute();
                        consultedEmployee = cmd.GetResult();
                        List<OrganizationalUnit> organizationalUnits = cmdUnits.GetResults();
                        List<Position> positions = cmdPositions.GetResults();
                        if (consultedEmployee != null)
                        {
                            id.Value = consultedEmployee.id.ToString();
                            Session["CONSULTED_ID"] = consultedEmployee.id;
                            workerid.Value = consultedEmployee.workerId;
                            name.Value = consultedEmployee.firstName + " " + consultedEmployee.lastName;
                            email.Value = consultedEmployee.email;
                            ListItem item;
                            foreach (Position position in positions)
                            {
                                item = new ListItem(position.name, position.id.ToString());
                                positionDropList.Items.Insert(positionDropList.Items.Count, item);
                            }
                            positionDropList.Items.FindByValue(consultedEmployee.idPosition.ToString()).Selected = true;
                            foreach (OrganizationalUnit organizationalUnit in organizationalUnits)
                            {
                                item = new ListItem(organizationalUnit.name, organizationalUnit.id.ToString());
                                ouDropList.Items.Insert(ouDropList.Items.Count, item);
                            }
                            ouDropList.Items.FindByValue(consultedEmployee.idOrganizationalUnit.ToString()).Selected = true;
                            item = new ListItem("No aplica", "-1");
                            superviseDropList.Items.Insert(superviseDropList.Items.Count, item);
                            foreach (OrganizationalUnit organizationalUnit in organizationalUnits)
                            {
                                if (organizationalUnit.id != 1)
                                {
                                    item = new ListItem(organizationalUnit.name, organizationalUnit.id.ToString());
                                    superviseDropList.Items.Insert(superviseDropList.Items.Count, item);
                                    if (organizationalUnit.overseer == consultedEmployee.id)
                                    {
                                        supervisedUnit = organizationalUnit.id;
                                    }
                                }
                            }
                            if (supervisedUnit != 0)
                            {
                                superviseDropList.Items.FindByValue(supervisedUnit.ToString()).Selected = true;
                            }

                            Session["CONSULTED_SUPERVISEDUNIT"] = supervisedUnit;
                        }
                        else
                        {
                            Session.Remove("CONSULTED_EMAIL");
                            Session.Remove("CONSULTED_ID");
                            Session.Remove("CONSULTED_SUPERVISEDUNIT");
                            Response.Redirect("~/site/employees/dashboard.aspx", false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Session.Remove("CONSULTED_EMAIL");
                    Session.Remove("CONSULTED_ID");
                    Session.Remove("CONSULTED_SUPERVISEDUNIT");
                    Response.Redirect("~/site/employees/hrm/employeelist.aspx", false);
                }
            }
        }

        protected void acceptBtn_Click(object sender, EventArgs e)
        {
            bool active = checkActiveSession();
            if (active)
            {
                int employeeId = (int)Session["CONSULTED_ID"];
                int selectedPosition = Int32.Parse(positionDropList.SelectedValue);
                int selectedUnit = Int32.Parse(ouDropList.SelectedValue);
                int selectedUnitToSupervise = Int32.Parse(superviseDropList.SelectedValue);
                supervisedUnit = (int)Session["CONSULTED_SUPERVISEDUNIT"];
                Employee employeeToModify = new Employee(employeeId, selectedPosition, selectedUnit);
                try
                {
                    UpdateEmployeeHRMCommand cmd = new UpdateEmployeeHRMCommand(employeeToModify);
                    cmd.Execute();
                    if (selectedUnitToSupervise != -1)
                    {
                        OrganizationalUnit organizationalUnit = new OrganizationalUnit(selectedUnitToSupervise, employeeId);
                        UpdateOverseerCommand cmdOverseer = new UpdateOverseerCommand(organizationalUnit);
                        cmdOverseer.Execute();
                        if (supervisedUnit != -1)
                        {
                            OrganizationalUnit organizationalUnitToRemove = new OrganizationalUnit(supervisedUnit);
                            RemoveOverseerCommand cmdRemove = new RemoveOverseerCommand(organizationalUnitToRemove);
                            cmdRemove.Execute();
                        }
                    }
                    else
                    {
                        OrganizationalUnit organizationalUnitToRemove = new OrganizationalUnit(supervisedUnit);
                        RemoveOverseerCommand cmdRemove = new RemoveOverseerCommand(organizationalUnitToRemove);
                        cmdRemove.Execute();
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Ha ocurrido un error al procesar su solicitud', 'error')", true);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "sweetAlert('Se ha modificado el empleado exitosamente', 'success', '/site/employees/hrm/employeedata.aspx')", true);
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("CONSULTED_EMAIL");
            Session.Remove("CONSULTED_ID");
            Response.Redirect("~/site/employees/hrm/employeelist.aspx", false);
        }
    }
}