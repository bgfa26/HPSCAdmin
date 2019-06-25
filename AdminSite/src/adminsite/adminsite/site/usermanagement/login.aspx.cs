using adminsite.common;
using adminsite.controller.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        protected void acceptBtn_Click(object sender, EventArgs e)
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            if ((!email.Equals("")) && (!password.Equals("")))
            {
                MD5Calculator calculator = new MD5Calculator();
                password = calculator.generateMD5(password);
                Employee employee = new Employee(email, password);
                try
                {
                    EmailVerificationCommand cmd = new EmailVerificationCommand(employee);
                    cmd.Execute();
                    Employee checkedEmployee = cmd.GetResult();
                    if (checkedEmployee != null)
                    {
                        if (employee.password.Equals(checkedEmployee.password))
                        {

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