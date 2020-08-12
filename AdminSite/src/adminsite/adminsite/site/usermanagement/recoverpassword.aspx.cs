using adminsite.common.entities;
using adminsite.controller.usermanagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.usermanagement
{
    public partial class recoverpassword : System.Web.UI.Page
    {
        String click;
        protected void Page_Load(object sender, EventArgs e)
        {
            click = (String)ViewState["click"];
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
            if ((click == null) && (validateEmail(email.Value)))
            {
                try
                {
                    Employee employee = new Employee(email.Value);
                    GetEmployeeInformationCommand evc = new GetEmployeeInformationCommand(employee);
                    evc.Execute();
                    Employee checkedEmployee = evc.GetResult();
                    if (checkedEmployee != null)
                    {
                        try
                        {
                            SendEmailCommand cmd = new SendEmailCommand(employee);
                            cmd.Execute();
                            hexacode.Visible = true;
                            message.Visible = true;
                            email.Attributes.Add("disabled", "disabled");
                            mail.Enabled = false;
                            ViewState["hexcode"] = cmd.GetHexCode();
                            ViewState["click"] = "clicked"; //String al azar
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error al enviar el código de verificación')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('El correo ingresado no se encuentra registrado en el sistema')", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error al validar el correo ingresado')", true);
                }
            }
            else
            {
                if (codeHex.Value.ToUpper().Equals((String)ViewState["hexcode"]))
                {
                    Session["changepassword"] = email.Value;
                    Response.Redirect("~/site/usermanagement/changepassword.aspx", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('El código de verificación ingresado es erróneo')", true);
                }
            }
        }
    }
}