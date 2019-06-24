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
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                password = sb.ToString();
                Employee employee = new Employee(email, password);
                try
                {
                    LoginCommand cmd = new LoginCommand(employee);
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
                catch (Exception ex) { }
            }
        }
    }
}