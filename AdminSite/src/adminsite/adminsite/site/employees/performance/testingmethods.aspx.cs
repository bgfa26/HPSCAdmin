﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.performance
{
    public partial class testingmethods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static String GetACPByMonth()
        {
            string response = "hola";
            return response;
        }
    }
}