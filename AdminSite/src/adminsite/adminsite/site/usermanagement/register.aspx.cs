using adminsite.common;
using adminsite.controller.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site
{
    public partial class register : System.Web.UI.Page
    {
        private Employee employee;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool validateEmail(string email)
        {
            string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            Match match = Regex.Match(email.Trim(), pattern, RegexOptions.IgnoreCase);

            if (match.Success)
                return true;
            else
                return false;
        }

        protected void acceptBtn_Click(object sender, EventArgs e)
        {
            string employeeEmail = email.Value;
            if (validateEmail(employeeEmail)) {
                try
                {
                    employee = new Employee(employeeEmail);
                    EmailIDVerificationCommand evc = new EmailIDVerificationCommand(employee);
                    evc.Execute();

                    int result = evc.GetResult();
                    if (result == 200)
                    {
                        try
                        {
                            SendEmailCommand cmd = new SendEmailCommand(employee);
                            cmd.Execute();
                            employeeForm.Visible = false;
                            verificationForm.Visible = true;
                            message.Visible = true;
                            ViewState["hexcode"] = cmd.GetHexCode();
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error al enviar el código de verificación')", true);
                        }
                    }
                    else if (result == 100)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('El correo ingresado se encuentra registrado en el sistema')", true);
                    }
                    else if (result == 101)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('La cédula ingresada se encuentra registrado en el sistema')", true);
                    }
                    else if (result == 102)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('El identificador de trabajador se encuentra registrado en el sistema')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error al validar los datos ingresados')", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error al validar los datos ingresados')", true);
                }
            }
        }

        protected void verificationBtn_Click(object sender, EventArgs e)
        {
            if (codeHex.Value.ToUpper().Equals((String)ViewState["hexcode"]))
            {
                //AQUI SE REALIZA LA INSERCION EN BD
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "sweetAlert('Se ha registrado exitosamente en el sistema')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('El código de verificación ingresado es erróneo')", true);
            }
        }
    }
}