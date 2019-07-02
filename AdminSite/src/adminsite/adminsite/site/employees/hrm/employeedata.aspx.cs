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
        public Employee consultedEmployee;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["CONSULTED_EMAIL"] != null)
                {
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
                        foreach (Position position in positions)
                        {
                            positionDropList.Items.Add(position.name);
                        }
                        positionDropList.Items.FindByValue(consultedEmployee.positionName).Selected = true;
                        foreach (OrganizationalUnit organizationalUnit in organizationalUnits)
                        {
                            ouDropList.Items.Add(organizationalUnit.name);
                        }
                        ouDropList.Items.FindByValue(consultedEmployee.organizationalUnit).Selected = true;
                        string supervisedUnit = "";
                        superviseDropList.Items.Add("No aplica");
                        foreach (OrganizationalUnit organizationalUnit in organizationalUnits)
                        {
                            superviseDropList.Items.Add(organizationalUnit.name);
                            if (organizationalUnit.overseer == consultedEmployee.id)
                            {
                                supervisedUnit = organizationalUnit.name;
                            }
                        }
                        if (!supervisedUnit.Equals(""))
                        {
                            superviseDropList.Items.FindByValue(supervisedUnit).Selected = true;
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
    }
}