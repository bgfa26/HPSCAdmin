using adminsite.common.entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.performance
{
    public partial class statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        [System.Web.Services.WebMethod]
        public static string GetACPByMonth()
        {
            List<Statistic> statistics = new List<Statistic>();
            Statistic lithuania = new Statistic("Lithuania", 501.9);
            Statistic netherlands = new Statistic("Netherlands", 50);
            Statistic belgium = new Statistic("Belgium", 60);
            Statistic uk = new Statistic("UK", 99);
            Statistic austria = new Statistic("Austria", 128.3);
            Statistic australia = new Statistic("Australia", 139.9);
            Statistic germany = new Statistic("Germany", 165.8);
            Statistic ireland = new Statistic("Ireland", 201.1);
            Statistic czechia = new Statistic("Czechia", 301.9);
            statistics.Add(lithuania);
            statistics.Add(netherlands);
            statistics.Add(belgium);
            statistics.Add(uk);
            statistics.Add(austria);
            statistics.Add(australia);
            statistics.Add(germany);
            statistics.Add(ireland);
            statistics.Add(czechia);
            string results = "";
            foreach (Statistic statistic in statistics)
            {
                results += statistic.title + "," + statistic.value + ";";
            }
            results = results.Remove(results.Length - 1);
            return results;
        }
    }
}