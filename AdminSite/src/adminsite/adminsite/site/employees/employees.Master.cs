using adminsite.common;
using adminsite.controller.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees
{
    public partial class employees : System.Web.UI.MasterPage
    {
        private Employee employee;
        private Employee consultedEmployee;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["EMPLOYEE_EMAIL"] != null)
                {
                    string employeeEmail = Session["EMPLOYEE_EMAIL"].ToString();
                    try
                    {
                        employee = new Employee(employeeEmail);
                        GetEmployeeInformationCommand cmd = new GetEmployeeInformationCommand(employee);
                        cmd.Execute();
                        consultedEmployee = cmd.GetResult();
                        if (consultedEmployee.status != 0)
                        {
                            string employeeName = consultedEmployee.firstName + " " + consultedEmployee.lastName;
                            Session["MY_INFORMATION"] = consultedEmployee;
                            employeeOptions.InnerHtml = "<i class=\"fa fa-user\"></i> " + employeeName + " <b class=\"caret\"></b>";
                            if (employee.status == 100)
                            {
                                rrhhLi.Visible = true;
                                acpLi.Visible = true;
                            }
                        }
                        else
                        {
                            Session.Remove("EMPLOYEE_EMAIL");
                            Session.RemoveAll();
                            Response.Redirect("~/site/usermanagement/login.aspx", false);
                        }
                    }
                    catch(Exception ex)
                    {
                        Session.Remove("EMPLOYEE_EMAIL");
                        Session.RemoveAll();
                        Response.Redirect("~/site/usermanagement/login.aspx", false);
                    }
                }
                else
                {
                    Session.Remove("EMPLOYEE_EMAIL");
                    Session.RemoveAll();
                    Response.Redirect("~/site/usermanagement/login.aspx", false);
                }
            }
        }

        public Employee GetEmployee()
        {
            return consultedEmployee;
        }

        
        protected void endSession_click(object sender, EventArgs e)
        {
            Session.Remove("EMPLOYEE_EMAIL");
            Session.RemoveAll();
            Response.Redirect("~/site/usermanagement/login.aspx", false);
        }
    }
}