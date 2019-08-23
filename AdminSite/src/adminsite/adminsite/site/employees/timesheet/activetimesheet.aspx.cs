using adminsite.common.entities;
using adminsite.controller.timesheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace adminsite.site.employees.timesheet
{
    public partial class activetimesheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                    string timesheetString = (string)Session["CONSULTED_TIMESHEET"];
                    if (loggedEmployee != null)
                    {
                        if (timesheetString != null)
                        {
                            OrganizationalUnit organizationalUnit = new OrganizationalUnit(loggedEmployee.idOrganizationalUnit, loggedEmployee.organizationalUnit);
                            loadWorkloads();
                        }
                        else
                        {
                            Session.Remove("CONSULTED_TIMESHEET");
                            Response.Redirect("~/site/employees/timesheet/timesheetlist.aspx", false);
                        }
                    }
                    else
                    {
                        Session.RemoveAll();
                        Response.Redirect("~/site/usermanagement/login.aspx", false);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error procesando su solicitud', 'error')", true);
                }
            }
        }

        protected int parseDay(string day)
        {
            int result;
            if (Int32.TryParse(day, out result))
            {
                return result;
            }
            else
            {
                if (day.Equals(""))
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int CheckEndDay(Timesheet timesheet)
        {
            if (timesheet.endDate.Day == 31)
            {
                return 31;
            }
            else if (timesheet.endDate.Day == 30)
            {
                return 30;
            }
            else if (timesheet.endDate.Day == 29)
            {
                return 29;
            }
            else if (timesheet.endDate.Day == 15)
            {
                return 15;
            }
            else
            {
                return 28;
            }
        }

        protected void fillTotalPerDaysLbl(List<Workload> workloads)
        {
            int day1 = 0;
            int day2 = 0;
            int day3 = 0;
            int day4 = 0;
            int day5 = 0;
            int day6 = 0;
            int day7 = 0;
            int day8 = 0;
            int day9 = 0;
            int day10 = 0;
            int day11 = 0;
            int day12 = 0;
            int day13 = 0;
            int day14 = 0;
            int day15 = 0;
            int day16 = 0;
            foreach (Workload workload in workloads)
            {
                day1 += workload.day1;
                day2 += workload.day2;
                day3 += workload.day3;
                day4 += workload.day4;
                day5 += workload.day5;
                day6 += workload.day6;
                day7 += workload.day7;
                day8 += workload.day8;
                day9 += workload.day9;
                day10 += workload.day10;
                day11 += workload.day11;
                day12 += workload.day12;
                day13 += workload.day13;
                day14 += workload.day14;
                day15 += workload.day15;
                day16 += workload.day16;
            }
            header1.Text = day1.ToString();
            header2.Text = day2.ToString();
            header3.Text = day3.ToString();
            header4.Text = day4.ToString();
            header5.Text = day5.ToString();
            header6.Text = day6.ToString();
            header7.Text = day7.ToString();
            header8.Text = day8.ToString();
            header9.Text = day9.ToString();
            header10.Text = day10.ToString();
            header11.Text = day11.ToString();
            header12.Text = day12.ToString();
            header13.Text = day13.ToString();
            header14.Text = day14.ToString();
            header15.Text = day15.ToString();
            header16.Text = day16.ToString();
        }

        protected void loadWorkloads()
        {
            string timesheetString = (string)Session["CONSULTED_TIMESHEET"];
            if (timesheetString != null)
            {
                Timesheet timesheet = new Timesheet(Int32.Parse(timesheetString));
                GetAllWorkloadsByTimesheetCommand cmd = new GetAllWorkloadsByTimesheetCommand(timesheet);
                cmd.Execute();
                timesheet = cmd.GetResults();
                timesheetLbl.Text = timesheet.id.ToString();
                int count = timesheet.workloads.Count;
                if (timesheet.workloads.Count > 0)
                {
                    gridView.DataSource = timesheet.workloads;
                    gridView.DataBind();
                }
                else
                {
                    timesheet.workloads.Add(new Workload());
                    gridView.DataSource = timesheet.workloads;
                    gridView.DataBind();
                    int columncount = gridView.Rows[0].Cells.Count;
                }
                int endDay = CheckEndDay(timesheet);
                switch (endDay)
                {
                    case 31:
                        break;
                    case 30:
                        gridView.Columns[16].Visible = false;
                        break;
                    case 29:
                        gridView.Columns[16].Visible = false;
                        gridView.Columns[15].Visible = false;
                        break;
                    case 15:
                        gridView.Columns[16].Visible = false;
                        break;
                    case 28:
                        gridView.Columns[16].Visible = false;
                        gridView.Columns[15].Visible = false;
                        gridView.Columns[14].Visible = false;
                        break;
                }
                fillTotalPerDaysLbl(timesheet.workloads);
            }
            else
            {
                Session.Remove("CONSULTED_TIMESHEET");
                Response.Redirect("~/site/employees/timesheet/timesheetlist.aspx", false);
            }
        }

        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridView.EditIndex = e.NewEditIndex;
            loadWorkloads();
        }

        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Workload workload = null;
            string idWorksheet = gridView.DataKeys[e.RowIndex].Values["id"].ToString();
            try
            {
                string timesheetString = (string)Session["CONSULTED_TIMESHEET"];
                Timesheet timesheet = new Timesheet(Int32.Parse(timesheetString));
                GetAllWorkloadsByTimesheetCommand cmdTimesheet = new GetAllWorkloadsByTimesheetCommand(timesheet);
                cmdTimesheet.Execute();
                timesheet = cmdTimesheet.GetResults();
                DropDownList acpEditDl = (DropDownList)gridView.Rows[e.RowIndex].FindControl("acpEditDl");
                int day1Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day1Txt")).Text);
                int day2Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day2Txt")).Text);
                int day3Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day3Txt")).Text);
                int day4Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day4Txt")).Text);
                int day5Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day5Txt")).Text);
                int day6Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day6Txt")).Text);
                int day7Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day7Txt")).Text);
                int day8Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day8Txt")).Text);
                int day9Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day9Txt")).Text);
                int day10Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day10Txt")).Text);
                int day11Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day11Txt")).Text);
                int day12Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day12Txt")).Text);
                int day13Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day13Txt")).Text);
                int day14Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day14Txt")).Text);
                int day15Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day15Txt")).Text);
                int day16Txt = parseDay(((TextBox)gridView.Rows[e.RowIndex].FindControl("day16Txt")).Text);
                Workload oldWorkload = (Workload)Session["ROW_TO_EDIT"];
                if (!acpEditDl.Text.Equals(""))
                {
                    if ((day1Txt >= 0) && (day2Txt >= 0) && (day3Txt >= 0) && (day4Txt >= 0) && (day5Txt >= 0) && (day6Txt >= 0) && (day7Txt >= 0) && (day8Txt >= 0) &&
                        (day9Txt >= 0) && (day10Txt >= 0) && (day11Txt >= 0) && (day12Txt >= 0) && (day13Txt >= 0) && (day14Txt >= 0) && (day15Txt >= 0) && (day16Txt >= 0))
                    {
                        AccountCoursePermit accountCoursePermit = new AccountCoursePermit(acpEditDl.SelectedValue, acpEditDl.SelectedItem.Text);
                        workload = new Workload(Int32.Parse(idWorksheet),day1Txt, day2Txt, day3Txt, day4Txt, day5Txt, day6Txt, day7Txt, day8Txt, day9Txt,
                                                day10Txt, day11Txt, day12Txt, day13Txt, day14Txt, day15Txt, day16Txt, timesheet, accountCoursePermit);
                        UpdateWorkloadCommand cmd = new UpdateWorkloadCommand(workload);
                        cmd.Execute();
                        int result = cmd.GetResult();
                        if (result == 200)
                        {
                            gridView.EditIndex = -1;
                            loadWorkloads();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('No se ha podido modificar las horas en la hoja de trabajo', 'error')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Existen campos que poseen información inválida', 'error')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Debe seleccionar una cuenta/curso/permiso para poder registrar las horas', 'error')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error procesando su solicitud', 'error')", true);
            }

        }

        protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridView.EditIndex = -1;
            loadWorkloads();
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string workloadId = gridView.DataKeys[e.RowIndex].Values["id"].ToString();
                Workload workloadToDelete = new Workload(Int32.Parse(workloadId));
                DeleteWorkloadCommand cmd = new DeleteWorkloadCommand(workloadToDelete);
                cmd.Execute();
                int result = cmd.GetResult();
                if (result == 200)
                {
                    loadWorkloads();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert(No se ha podido eliminar la carga de trabajo', 'error')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error procesando su solicitud', 'error')", true);
            }
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                OrganizationalUnit organizationalUnit = new OrganizationalUnit(loggedEmployee.idOrganizationalUnit, loggedEmployee.organizationalUnit);
                GetAllACPPerOUCommand cmd = new GetAllACPPerOUCommand(organizationalUnit);
                cmd.Execute();

                string timesheetString = (string)Session["CONSULTED_TIMESHEET"];
                Timesheet timesheet = new Timesheet(Int32.Parse(timesheetString));
                GetAllWorkloadsByTimesheetCommand cmdTimesheet = new GetAllWorkloadsByTimesheetCommand(timesheet);
                cmdTimesheet.Execute();
                timesheet = cmdTimesheet.GetResults();
                int count = timesheet.workloads.Count;

                List<AccountCoursePermit> acpList = cmd.GetResults();
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    if (count == 0)
                    {
                        Label acpLbl = (e.Row.FindControl("acpLbl")) as Label;
                        ImageButton modify = (e.Row.FindControl("modify")) as ImageButton;
                        ImageButton delete = (e.Row.FindControl("delete")) as ImageButton;
                        modify.Visible = false;
                        delete.Visible = false;
                        for (int i = 1; i <= 16; i++)
                        {
                            Label dayLbl = (e.Row.FindControl("day" + i + "Lbl")) as Label;
                            dayLbl.Text = "";
                        }
                    }
                    if ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)))
                    {
                        DropDownList acpEditDl = (e.Row.FindControl("acpEditDl")) as DropDownList;
                        if (acpEditDl != null)
                        {
                            ListItem item;
                            foreach (AccountCoursePermit accountCoursePermit in acpList)
                            {
                                item = new ListItem(accountCoursePermit.name, accountCoursePermit.id.ToString());
                                acpEditDl.Items.Insert(acpEditDl.Items.Count, item);
                            }
                            Workload workload = (Workload)e.Row.DataItem;

                            acpEditDl.Items.FindByValue(workload.accountCoursePermit.id).Selected = true;
                            Session["ROW_TO_EDIT"] = workload;
                        }
                    }
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DropDownList acpNewDl = (e.Row.FindControl("acpNewDl")) as DropDownList;
                    if (acpNewDl != null)
                    {
                        ListItem item;
                        foreach (AccountCoursePermit accountCoursePermit in acpList)
                        {
                            item = new ListItem(accountCoursePermit.name, accountCoursePermit.id.ToString());
                            acpNewDl.Items.Insert(acpNewDl.Items.Count, item);
                        }
                    }
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    DateTime movableDate = timesheet.initDate;
                    int dayCounter = 1;
                    while (DateTime.Compare(movableDate, timesheet.endDate) != 1)
                    {
                        switch (dayCounter)
                        {
                            case 1:
                                e.Row.Cells[1].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 2:
                                e.Row.Cells[2].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 3:
                                e.Row.Cells[3].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 4:
                                e.Row.Cells[4].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 5:
                                e.Row.Cells[5].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 6:
                                e.Row.Cells[6].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 7:
                                e.Row.Cells[7].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 8:
                                e.Row.Cells[8].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 9:
                                e.Row.Cells[9].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 10:
                                e.Row.Cells[10].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 11:
                                e.Row.Cells[11].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 12:
                                e.Row.Cells[12].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 13:
                                e.Row.Cells[13].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 14:
                                e.Row.Cells[14].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 15:
                                e.Row.Cells[15].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                            case 16:
                                e.Row.Cells[16].Text = movableDate.ToString("dd/MM/yyyy");
                                break;
                        }
                        movableDate = movableDate.AddDays(1);
                        dayCounter++;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error procesando su solicitud', 'error')", true);
            }
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                Workload workload = null;
                try
                {
                    string timesheetString = (string)Session["CONSULTED_TIMESHEET"];
                    Timesheet timesheet = new Timesheet(Int32.Parse(timesheetString));
                    GetAllWorkloadsByTimesheetCommand cmdTimesheet = new GetAllWorkloadsByTimesheetCommand(timesheet);
                    cmdTimesheet.Execute();
                    timesheet = cmdTimesheet.GetResults();
                    DropDownList acpNewDl = (DropDownList)gridView.FooterRow.FindControl("acpNewDl");
                    int inDay1 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay1")).Text);
                    int inDay2 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay2")).Text);
                    int inDay3 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay3")).Text);
                    int inDay4 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay4")).Text);
                    int inDay5 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay5")).Text);
                    int inDay6 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay6")).Text);
                    int inDay7 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay7")).Text);
                    int inDay8 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay8")).Text);
                    int inDay9 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay9")).Text);
                    int inDay10 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay10")).Text);
                    int inDay11 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay11")).Text);
                    int inDay12 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay12")).Text);
                    int inDay13 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay13")).Text);
                    int inDay14 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay14")).Text);
                    int inDay15 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay15")).Text);
                    int inDay16 = parseDay(((TextBox)gridView.FooterRow.FindControl("inDay16")).Text);
                    int totalDay1 = Int32.Parse(header1.Text) + inDay1;
                    int totalDay2 = Int32.Parse(header2.Text) + inDay2;
                    int totalDay3 = Int32.Parse(header3.Text) + inDay3;
                    int totalDay4 = Int32.Parse(header4.Text) + inDay4;
                    int totalDay5 = Int32.Parse(header5.Text) + inDay5;
                    int totalDay6 = Int32.Parse(header6.Text) + inDay6;
                    int totalDay7 = Int32.Parse(header7.Text) + inDay7;
                    int totalDay8 = Int32.Parse(header8.Text) + inDay8;
                    int totalDay9 = Int32.Parse(header9.Text) + inDay9;
                    int totalDay10 = Int32.Parse(header10.Text) + inDay10;
                    int totalDay11 = Int32.Parse(header11.Text) + inDay11;
                    int totalDay12 = Int32.Parse(header12.Text) + inDay12;
                    int totalDay13 = Int32.Parse(header13.Text) + inDay13;
                    int totalDay14 = Int32.Parse(header14.Text) + inDay14;
                    int totalDay15 = Int32.Parse(header15.Text) + inDay15;
                    int totalDay16 = Int32.Parse(header16.Text) + inDay16;

                    if ((totalDay1 <= 24) && (totalDay2 <= 24) && (totalDay3 <= 24) && (totalDay4 <= 24) && (totalDay5 <= 24) && (totalDay6 <= 24) && 
                        (totalDay7 <= 24) && (totalDay8 <= 24) && (totalDay9 <= 24) && (totalDay10 <= 24) && (totalDay11 <= 24) && (totalDay12 <= 24) && 
                        (totalDay13 <= 24) && (totalDay14 <= 24) && (totalDay15 <= 24) && (totalDay16 <= 24))
                    {
                        if (!acpNewDl.Text.Equals(""))
                        {
                            if ((inDay1 >= 0) && (inDay2 >= 0) && (inDay3 >= 0) && (inDay4 >= 0) && (inDay5 >= 0) && (inDay6 >= 0) && (inDay7 >= 0) && (inDay8 >= 0) &&
                                (inDay9 >= 0) && (inDay10 >= 0) && (inDay11 >= 0) && (inDay12 >= 0) && (inDay13 >= 0) && (inDay14 >= 0) && (inDay15 >= 0) && (inDay16 >= 0))
                            {
                                AccountCoursePermit accountCoursePermit = new AccountCoursePermit(acpNewDl.SelectedValue, acpNewDl.SelectedItem.Text);
                                workload = new Workload(inDay1, inDay2, inDay3, inDay4, inDay5, inDay6, inDay7, inDay8, inDay9,
                                                        inDay10, inDay11, inDay12, inDay13, inDay14, inDay15, inDay16, timesheet, accountCoursePermit);
                                AddWorkloadToTimesheetCommand cmd = new AddWorkloadToTimesheetCommand(workload);
                                cmd.Execute();
                                int result = cmd.GetResult();
                                if (result == 200)
                                {
                                    loadWorkloads();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('No se ha podido cargar las horas en la hoja de trabajo', 'error')", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Existen campos que poseen información inválida', 'error')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Debe seleccionar una cuenta/curso/permiso para poder registrar las horas', 'error')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('No se pueden exceder las 24 horas del día', 'error')", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error procesando su solicitud', 'error')", true);
                }

            }
        }

        protected void sendBtn_Click(object sender, EventArgs e)
        {

        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            Session.Remove("CONSULTED_TIMESHEET");
            Response.Redirect("~/site/employees/timesheet/timesheetlist.aspx", false);
        }
    }
}