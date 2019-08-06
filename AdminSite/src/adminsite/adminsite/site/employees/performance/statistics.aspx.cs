using adminsite.common.entities;
using adminsite.controller.statistics;
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
            for (int year = 2010; year <= 2050; year++)
            {
                ListItem item = new ListItem(year.ToString(), year.ToString());
                yearBarChartDl.Items.Insert(yearBarChartDl.Items.Count, item);
                yearHBarChartDl.Items.Insert(yearHBarChartDl.Items.Count, item);
                yearPieChartDl.Items.Insert(yearPieChartDl.Items.Count, item);
            }
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
        public static string GetHoursPerMonth(string yearString)
        {
            /*List<Statistic> statistics = new List<Statistic>();
            Statistic year2005 = new Statistic("2019-01", 501.9);
            Statistic year2006 = new Statistic("2019-02", 50);
            Statistic year2007 = new Statistic("2019-03", 60);
            Statistic year2008 = new Statistic("2019-04", 99);
            Statistic year2009 = new Statistic("2019-05", 128.3);
            Statistic year2010 = new Statistic("2019-06", 139.9);
            Statistic year2011 = new Statistic("2019-07", 165.8);
            Statistic year2012 = new Statistic("2019-08", 201.1);
            Statistic year2013 = new Statistic("2019-09", 301.9);
            statistics.Add(year2005);
            statistics.Add(year2006);
            statistics.Add(year2007);
            statistics.Add(year2008);
            statistics.Add(year2009);
            statistics.Add(year2010);
            statistics.Add(year2011);
            statistics.Add(year2012);
            statistics.Add(year2013);*/
            try
            {
                int year = Int32.Parse(yearString);
                GetTotalHoursPerMonthCommand cmd = new GetTotalHoursPerMonthCommand(year);
                cmd.Execute();
                List<Statistic> statistics = cmd.GetResults();
                string results = "";
                foreach (Statistic statistic in statistics)
                {
                    results += statistic.title + "," + statistic.value + ";";
                }
                results = results.Remove(results.Length - 1);
                return results;
            }
            catch (Exception ex)
            {
                return "error";
            }
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