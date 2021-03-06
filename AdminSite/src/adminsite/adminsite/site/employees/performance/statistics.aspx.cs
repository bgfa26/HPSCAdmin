﻿using adminsite.common.entities;
using adminsite.controller.hrm;
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
            if (!Page.IsPostBack)
            {
                try
                {
                    Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                    if (!(((loggedEmployee.organizationalUnit.Equals("Directiva")) && (loggedEmployee.positionName.Equals("Director"))) || ((loggedEmployee.organizationalUnit.Equals("Contraloría")) && (loggedEmployee.positionName.Equals("Contralor de Gestión")))))
                    {
                        Response.Redirect("~/site/employees/dashboard.aspx", false);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Ha ocurrido un error al cargar la información', 'error')", true);
                }
            }
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

        private static string createResultDaysOfWeek(List<Statistic> statistics, List<Int32> days)
        {
            string results = "";
            int count = 0;
            foreach (Statistic statistic in statistics)
            {
                results += statistic.title + "," + days[count] + "," + statistic.value + ";";
                count++;
            }
            if (!results.Equals(""))
            {
                results = results.Remove(results.Length - 1);
            }
            return results;
        }

        private static string createResultString(List<string> results)
        {
            string _results = "";
            foreach (string result in results)
            {
                _results += result + ";";
            }
            if (!_results.Equals(""))
            {
                _results = _results.Remove(_results.Length - 1);
            }
            return _results;
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
                DateTime initDate = new DateTime(year, month, 1);
                DateTime endDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                int mondays = CountDays(DayOfWeek.Monday, initDate, endDate);
                int tuesdays = CountDays(DayOfWeek.Tuesday, initDate, endDate);
                int wednesdays = CountDays(DayOfWeek.Wednesday, initDate, endDate);
                int thursdays = CountDays(DayOfWeek.Thursday, initDate, endDate);
                int fridays = CountDays(DayOfWeek.Friday, initDate, endDate);
                int saturdays = CountDays(DayOfWeek.Saturday, initDate, endDate);
                int sundays = CountDays(DayOfWeek.Sunday, initDate, endDate);
                List<Int32> days = new List<int>();
                days.Add(mondays);
                days.Add(tuesdays);
                days.Add(wednesdays);
                days.Add(thursdays);
                days.Add(fridays);
                days.Add(saturdays);
                days.Add(sundays);
                string results = createResultDaysOfWeek(statistics, days);
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

        [System.Web.Services.WebMethod]
        public static string GetYearsByMonth(string monthString, string graph)
        {
            try
            {
                int month = Int32.Parse(monthString);
                GetAllYearsByMonthCommand cmd = new GetAllYearsByMonthCommand(month);
                cmd.Execute();
                List<string> years = cmd.GetResults();
                if (years.Count > 0)
                {
                    string results = graph + "/" + createResultString(years);
                    return results;
                }
                else
                {
                    return graph + "/empty";
                }
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        [System.Web.Services.WebMethod]
        public static string GetAllYears()
        {
            try
            {
                GetAllYearsCommand cmd = new GetAllYearsCommand();
                cmd.Execute();
                List<string> years = cmd.GetResults();
                string results = createResultString(years);
                return results;
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        static int CountDays(DayOfWeek day, DateTime start, DateTime end)
        {
            TimeSpan ts = end - start;                       // Total duration
            int count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
            int remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
            int sinceLastDay = (int)(end.DayOfWeek - day);   // Number of days since last [day]
            if (sinceLastDay < 0) sinceLastDay += 7;         // Adjust for negative days since last [day]

            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay) count++;

            return count;
        }
    }
}