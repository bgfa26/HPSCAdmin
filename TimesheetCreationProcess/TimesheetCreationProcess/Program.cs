using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetCreationProcess.controller.timesheet;
using TimesheetProcess.controller.emailservice;

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
            DateTime end = new DateTime(initDate.Year, initDate.Month, DateTime.DaysInMonth(initDate.Year, initDate.Month));
            int middleDay = end.Day - 3;
            if (initDate.Day == 3)
            {
                int year = initDate.Year;
                int month = initDate.Month - 1;
                if (month == 0)
                {
                    month = 12;
                    year--;
                }
                DateTime dateTime = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                SendEmailCommand cmd = new SendEmailCommand(0, dateTime);
                cmd.Execute();
            }
            else if (initDate.Day == middleDay)
            {
                SendEmailCommand cmd = new SendEmailCommand(1);
                cmd.Execute();
            }
            else if (initDate.Day == 12)
            {
                SendEmailCommand cmd = new SendEmailCommand(1);
                cmd.Execute();
            }
            else if (initDate.Day == 18)
            {
                DateTime dateTime = new DateTime(initDate.Year, initDate.Month, 15);
                SendEmailCommand cmd = new SendEmailCommand(0, dateTime);
                cmd.Execute();
            }
            else if (initDate.Day == 15)
            {
                SendEmailCommand cmd = new SendEmailCommand(2);
                cmd.Execute();
            }
            else if (initDate.Day == end.Day)
            {
                SendEmailCommand cmd = new SendEmailCommand(2);
                cmd.Execute();
            }
        }
    }
}
