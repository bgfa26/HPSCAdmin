using adminsite.common.entities;
using adminsite.controller.timesheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.timesheet
{
    public partial class timesheetdata : System.Web.UI.Page
    {
        public Workload total = new Workload(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "",new Timesheet(), new AccountCoursePermit("final", "Total"));
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                try
                {
                    Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                    string timesheetString = (string)Session["CONSULTED_TIMESHEET"];
                    Timesheet timesheet = new Timesheet(Int32.Parse(timesheetString));

                    GetAllWorkloadsByTimesheetCommand cmd = new GetAllWorkloadsByTimesheetCommand(timesheet);
                    cmd.Execute();
                    timesheet = cmd.GetResults();
                    timesheetLbl.Text = timesheet.id.ToString();
                    foreach (Workload workload in timesheet.workloads)
                    {
                        total.day1 += workload.day1;
                        total.day2 += workload.day2;
                        total.day3 += workload.day3;
                        total.day4 += workload.day4;
                        total.day5 += workload.day5;
                        total.day6 += workload.day6;
                        total.day7 += workload.day7;
                        total.day8 += workload.day8;
                        total.day9 += workload.day9;
                        total.day10 += workload.day10;
                        total.day11 += workload.day11;
                        total.day12 += workload.day12;
                        total.day13 += workload.day13;
                        total.day14 += workload.day14;
                        total.day15 += workload.day15;
                        total.day16 += workload.day16;
                    }
                    repWorkloads.DataSource = timesheet.workloads;
                    repWorkloads.DataBind();
                    day1Lbl.Text = total.day1.ToString();
                    day2Lbl.Text = total.day2.ToString();
                    day3Lbl.Text = total.day3.ToString();
                    day4Lbl.Text = total.day4.ToString();
                    day5Lbl.Text = total.day5.ToString();
                    day6Lbl.Text = total.day6.ToString();
                    day7Lbl.Text = total.day7.ToString();
                    day8Lbl.Text = total.day8.ToString();
                    day9Lbl.Text = total.day9.ToString();
                    day10Lbl.Text = total.day10.ToString();
                    day11Lbl.Text = total.day11.ToString();
                    day12Lbl.Text = total.day12.ToString();
                    day13Lbl.Text = total.day13.ToString();
                    day14Lbl.Text = total.day14.ToString();
                    day15Lbl.Text = total.day15.ToString();
                    day16Lbl.Text = total.day16.ToString();
                    totalLbl.Text = total.TotalHoursPerACP().ToString();
                    DateTime movableDate = timesheet.initDate;
                    int dayCounter = 1;
                    while (DateTime.Compare(movableDate, timesheet.endDate) != 1)
                    {
                        switch (dayCounter)
                        {
                            case 1:
                                header1.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 2:
                                header2.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 3:
                                header3.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 4:
                                header4.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 5:
                                header5.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 6:
                                header6.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 7:
                                header7.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 8:
                                header8.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 9:
                                header9.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 10:
                                header10.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 11:
                                header11.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 12:
                                header12.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 13:
                                header13.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 14:
                                _header14.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 15:
                                _header15.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 16:
                                _header16.Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                        }
                        movableDate = movableDate.AddDays(1);
                        dayCounter++;
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Ha ocurrido un error al cargar la información', 'error')", true);
                }
            }
        }



        public int TotalHoursPerACP(Object day1_, Object day2_, Object day3_, Object day4_, Object day5_, Object day6_, Object day7_, Object day8_, Object day9_, Object day10_, Object day11_, Object day12_, Object day13_, Object day14_, Object day15_, Object day16_)
        {
            int day1 = (Int32)day1_;
            int day2 = (Int32)day2_;
            int day3 = (Int32)day3_;
            int day4 = (Int32)day4_;
            int day5 = (Int32)day5_;
            int day6 = (Int32)day6_;
            int day7 = (Int32)day7_;
            int day8 = (Int32)day8_;
            int day9 = (Int32)day9_;
            int day10 = (Int32)day10_;
            int day11 = (Int32)day11_;
            int day12 = (Int32)day12_;
            int day13 = (Int32)day13_;
            int day14 = (Int32)day14_;
            int day15 = (Int32)day15_;
            int day16 = (Int32)day16_;
            return (day1 + day2 + day3 + day4 + day5 + day6 + day7 + day8 +
                    day9 + day10 + day11 + day12 + day13 + day14 + day15 + day16);
        }

        [System.Web.Services.WebMethod]
        public static string CheckEndDate()
        {
            string timesheetString = (string)HttpContext.Current.Session["CONSULTED_TIMESHEET"];
            Timesheet timesheet = new Timesheet(Int32.Parse(timesheetString));
            GetAllWorkloadsByTimesheetCommand cmd = new GetAllWorkloadsByTimesheetCommand(timesheet);
            cmd.Execute();
            timesheet = cmd.GetResults();
            if (timesheet.endDate.Day == 31)
            {
                return "31";
            }
            else if (timesheet.endDate.Day == 30)
            {
                return "30";
            }
            else if (timesheet.endDate.Day == 29)
            {
                return "29";
            }
            else if (timesheet.endDate.Day == 15)
            {
                return "15";
            }
            else
            {
                return "28";
            }
        }
        
        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("CONSULTED_TIMESHEET");
            Response.Redirect("~/site/employees/timesheet/timesheetlist.aspx", false);
        }
    }
}