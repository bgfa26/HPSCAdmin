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
            if (password.Equals(passwordVerification))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "sweetAlert('Se ha actualizado su contraseña exitosamente', 'success')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "sweetAlert('Las contraseñas ingresadas no coinciden', 'error')", true);
            }
        }
    }
}