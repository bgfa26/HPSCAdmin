using adminsite.common.entities;
using adminsite.common;
using adminsite.controller.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.usermanagement
{
    public partial class changepassword : System.Web.UI.Page
    {
        private string employeeEmail;
        protected void Page_Load(object sender, EventArgs e)
        {
            var email = Session["changepassword"];
            if (email != null)
            {
                employeeEmail = (String)email;
            }
            else
            {
                Response.Redirect("~/site/usermanagement/login.aspx");
            }
        }

        protected void acceptBtn_Click(object sender, EventArgs e)
        {
            string password = pwd.Value;
            string passwordVerification = pwdverification.Value;
            if (password.Length >= 8) {
                if (password.Equals(passwordVerification))
                {
                    MD5Calculator calculator = new MD5Calculator();
                    password = calculator.generateMD5(password);
                    Employee employee = new Employee(employeeEmail, password);
                    try
                    {
                        UpdatePasswordCommand cmd = new UpdatePasswordCommand(employee);
                        cmd.Execute();
                        int result = cmd.GetResult();
                        if (result == 200)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "sweetAlert('Se ha actualizado su contraseña exitosamente', 'success')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Su contraseña no ha podido ser actualizada', 'error')", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Su contraseña no ha podido ser actualizada', 'error')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Las contraseñas ingresadas no coinciden', 'error')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('La contraseña debe tener al menos 8 caracteres', 'error')", true);
            }
        }
    }
}