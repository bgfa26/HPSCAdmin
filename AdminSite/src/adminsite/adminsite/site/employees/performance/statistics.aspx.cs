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
            Statistic year2005 = new Statistic("2005", 501.9);
            Statistic year2006 = new Statistic("2006", 50);
            Statistic year2007 = new Statistic("2007", 60);
            Statistic year2008 = new Statistic("2008", 99);
            Statistic year2009 = new Statistic("2009", 128.3);
            Statistic year2010 = new Statistic("2010", 139.9);
            Statistic year2011 = new Statistic("2011", 165.8);
            Statistic year2012 = new Statistic("2012", 201.1);
            Statistic year2013 = new Statistic("2013", 301.9);
            statistics.Add(year2005);
            statistics.Add(year2006);
            statistics.Add(year2007);
            statistics.Add(year2008);
            statistics.Add(year2009);
            statistics.Add(year2010);
            statistics.Add(year2011);
            statistics.Add(year2012);
            statistics.Add(year2013);
            string results = "";
            foreach (Statistic statistic in statistics)
            {
                results += statistic.title + "," + statistic.value + ";";
            }
            results = results.Remove(results.Length - 1);
            return results;
        }

        [System.Web.Services.WebMethod]
        public static string GetHoursPerMonth()
        {
            List<Statistic> statistics = new List<Statistic>();
            Statistic year2005 = new Statistic("2005-01-01", 501.9);
            Statistic year2006 = new Statistic("2006-01-01", 50);
            Statistic year2007 = new Statistic("2007-01-01", 60);
            Statistic year2008 = new Statistic("2008-01-01", 99);
            Statistic year2009 = new Statistic("2009-01-01", 128.3);
            Statistic year2010 = new Statistic("2010-01-01", 139.9);
            Statistic year2011 = new Statistic("2011-01-01", 165.8);
            Statistic year2012 = new Statistic("2012-01-01", 201.1);
            Statistic year2013 = new Statistic("2013-01-01", 301.9);
            statistics.Add(year2005);
            statistics.Add(year2006);
            statistics.Add(year2007);
            statistics.Add(year2008);
            statistics.Add(year2009);
            statistics.Add(year2010);
            statistics.Add(year2011);
            statistics.Add(year2012);
            statistics.Add(year2013);
            string results = "";
            foreach (Statistic statistic in statistics)
            {
                results += statistic.title + "," + statistic.value + ";";
            }
            results = results.Remove(results.Length - 1);
            return results;
        }

        [System.Web.Services.WebMethod]
        public static string GetAverageHoursPerDayOfWeek()
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

        [System.Web.Services.WebMethod]
        public static string GetTotalHoursPerPosition()
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