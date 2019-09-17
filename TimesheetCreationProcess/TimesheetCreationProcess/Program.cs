using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetCreationProcess.controller.timesheet;

namespace TimesheetCreationProcess
{
    class Program
    {
        private static void createTimesheets(DateTime initDate, DateTime endDate)
        {
            try
            {
                AddTimesheetsPerEmployeeCommand cmd = new AddTimesheetsPerEmployeeCommand(initDate, endDate);
                cmd.Execute();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        static void Main(string[] args)
        {
            DateTime initDate = DateTime.Now;
            if (initDate.Day == 1)
            {
                DateTime endDate = initDate.AddDays(14);
                createTimesheets(initDate, endDate);
            }
            else if (initDate.Day == 16)
            {
                DateTime endDate = new DateTime(initDate.Year, initDate.Month, DateTime.DaysInMonth(initDate.Year, initDate.Month));
                createTimesheets(initDate, endDate);
            }
        }
    }
}
