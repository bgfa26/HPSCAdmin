using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.usermanagement
{
    public partial class usermanagement : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["EMPLOYEE_EMAIL"] != null)
                {
                    Response.Redirect("~/site/employees/dashboard.aspx", false);
                }
            }
        }
    }
}