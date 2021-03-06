﻿using adminsite.common.entities;
using adminsite.common;
using adminsite.controller.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.usermanagement
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        private bool validateEmail(string email)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Match match = Regex.Match(email.Trim(), pattern, RegexOptions.IgnoreCase);

            if (match.Success)
                return true;
            else
                return false;
        }

        protected void acceptBtn_Click(object sender, EventArgs e)
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            if ((!email.Equals("")) && (!password.Equals("")) && (validateEmail(email)))
            {
                MD5Calculator calculator = new MD5Calculator();
                password = calculator.generateMD5(password);
                Employee employee = new Employee(email, password);
                try
                {
                    GetEmployeeInformationCommand cmd = new GetEmployeeInformationCommand(employee);
                    cmd.Execute();
                    Employee checkedEmployee = cmd.GetResult();
                    if (checkedEmployee != null)
                    {

                        if (employee.password.Equals(checkedEmployee.password))
                        {
                            if ((checkedEmployee.idOrganizationalUnit != 1) && (checkedEmployee.idPosition != 1) && (checkedEmployee.status != 0))
                            {
                                Session["EMPLOYEE_EMAIL"] = checkedEmployee.email;
                                Response.Redirect("~/site/employees/dashboard.aspx", false);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "infoSweetAlert('Su registro fue exitoso, sin embargo, no puede acceder ya que no tiene un cargo asignado')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('El correo y/o la contraseña son inválidos')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('El correo y/o la contraseña son inválidos')", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error tratando de iniciar sesión')", true);
                }
            }
        }
    }
}