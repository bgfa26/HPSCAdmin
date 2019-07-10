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
                            if ((consultedEmployee.organizationalUnit.Equals("Directiva")) && (consultedEmployee.organizationalUnit.Equals("Directiva")))
                            {
                                rrhhLi.Visible = true;
                                acpLi.Visible = true;
                            }
                            else if ((consultedEmployee.organizationalUnit.Equals("Gerente de Talento Humano")) && (consultedEmployee.organizationalUnit.Equals("Administración")))
                            {
                                rrhhLi.Visible = true;
                                acpLi.Visible = false;
                            }
                            else if ((consultedEmployee.organizationalUnit.Equals("Contralor de Gestión")) && (consultedEmployee.organizationalUnit.Equals("Operaciones")))
                            {
                                rrhhLi.Visible = false;
                                acpLi.Visible = true;
                            }
                            else
                            {
                                rrhhLi.Visible = false;
                                acpLi.Visible = false;
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