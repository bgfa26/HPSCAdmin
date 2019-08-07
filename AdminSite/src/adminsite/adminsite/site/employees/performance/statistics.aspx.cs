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

        }

        private static string createResult(List<Statistic> statistics)
        {
            string results = "";
            foreach (Statistic statistic in statistics)
            {
                results += statistic.title + "," + statistic.value + ";";
            }
            if (!results.Equals(""))
            {
                results = results.Remove(results.Length - 1);
            }
            return results;
        }

        [System.Web.Services.WebMethod]
        public static string GetACPPerMonth(string monthString, string yearString)
        {

            try
            {
                int month = Int32.Parse(monthString);
                int year = Int32.Parse(yearString);
                GetTotalHoursPerACPCommand cmd = new GetTotalHoursPerACPCommand(month, year);
                cmd.Execute();
                List<Statistic> statistics = cmd.GetResults();
                string results = createResult(statistics);
                return results;
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        [System.Web.Services.WebMethod]
        public static string GetHoursPerMonth(string yearString)
        {
            try
            {
                int year = Int32.Parse(yearString);
                GetTotalHoursPerMonthCommand cmd = new GetTotalHoursPerMonthCommand(year);
                cmd.Execute();
                List<Statistic> statistics = cmd.GetResults();
                string results = createResult(statistics);
                return results;
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        [System.Web.Services.WebMethod]
        public static string GetTotalHoursPerDayOfWeek(string monthString, string yearString)
        {
            try
            {
                int month = Int32.Parse(monthString);
                int year = Int32.Parse(yearString);
                GetTotalHoursPerDayPerMonthCommand cmd = new GetTotalHoursPerDayPerMonthCommand(month, year);
                cmd.Execute();
                List<Statistic> statistics = cmd.GetResults();
                string results = createResult(statistics);
                return results;
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        [System.Web.Services.WebMethod]
        public static string GetTotalHoursPerOrganizationalUnit(string monthString, string yearString)
        {
            try
            {
                int month = Int32.Parse(monthString);
                int year = Int32.Parse(yearString);
                GetTotalHoursPerOrganizationalUnitCommand cmd = new GetTotalHoursPerOrganizationalUnitCommand(month, year);
                cmd.Execute();
                List<Statistic> statistics = cmd.GetResults();
                string results = createResult(statistics);
                return results;
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    }
}