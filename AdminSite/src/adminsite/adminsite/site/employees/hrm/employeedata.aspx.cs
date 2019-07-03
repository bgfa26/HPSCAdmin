using adminsite.common;
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
        private Employee consultedEmployee;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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
                        int supervisedUnit = 0;
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
                    }
                    else
                    {
                        Session.Remove("CONSULTED_EMAIL");
                        Response.Redirect("~/site/employees/dashboard.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Remove("CONSULTED_EMAIL");
                Response.Redirect("~/site/employees/dashboard.aspx", false);
            }
        }

        protected void acceptBtn_Click(object sender, EventArgs e)
        {
            int employeeId = consultedEmployee.id;
            int selectedPosition = Int32.Parse(positionDropList.SelectedValue);
            int selectedUnit = Int32.Parse(ouDropList.SelectedValue);
            int selectedUnitToSupervise = Int32.Parse(superviseDropList.SelectedValue);
            Employee employeeToModify = new Employee(employeeId, selectedPosition, selectedUnit);
            try
            {
                UpdateEmployeeHRMCommand cmd = new UpdateEmployeeHRMCommand(employeeToModify);
                cmd.Execute();
                if (!selectedUnitToSupervise.Equals("-1"))
                {
                    OrganizationalUnit organizationalUnit = new OrganizationalUnit(selectedUnitToSupervise, employeeId);
                    UpdateOverseerCommand cmdOverseer = new UpdateOverseerCommand(organizationalUnit);
                    cmdOverseer.Execute();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Ha ocurrido un error al procesar su solicitud', 'error')", true);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "sweetAlert('Se ha modificado el empleado exitosamente', 'success', '/site/employees/hrm/employeedata.aspx')", true);
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("CONSULTED_EMAIL");
            Response.Redirect("~/site/employees/hrm/employeelist.aspx", false);
        }
    }
}