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
        private SqlConnection con = new SqlConnection("Data Source=LUISALEJANDROPE\\SQLEXPRESS;Initial Catalog=TestDatabase;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Employee loggedEmployee = (Employee)Session["MY_INFORMATION"];
                    OrganizationalUnit organizationalUnit = new OrganizationalUnit(loggedEmployee.idOrganizationalUnit, loggedEmployee.organizationalUnit);
                    loadWorkloads();
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

        protected void loadWorkloads()
        {
            string timesheetString = (string)Session["CONSULTED_TIMESHEET"];
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
        }
        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridView.EditIndex = e.NewEditIndex;
            loadWorkloads();
        }
        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //string stor_id = gridView.DataKeys[e.RowIndex].Values["stor_id"].ToString();
            //TextBox stor_name = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtname");
            //TextBox stor_address = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtaddress");
            //TextBox city = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtcity");
            //TextBox state = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtstate");
            //TextBox zip = (TextBox)gridView.Rows[e.RowIndex].FindControl("txtzip");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("update stores set stor_name='" + stor_name.Text + "', stor_address='" + stor_address.Text + "', city='" + city.Text + "', state='" + state.Text + "', zip='" + zip.Text + "' where stor_id=" + stor_id, con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //lblmsg.BackColor = Color.Blue;
            //lblmsg.ForeColor = Color.White;
            //lblmsg.Text = stor_id + "        Updated successfully........    ";
            //gridView.EditIndex = -1;
            //loadStores();
        }
        protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridView.EditIndex = -1;
            loadWorkloads();
        }
        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //string stor_id = gridView.DataKeys[e.RowIndex].Values["stor_id"].ToString();
            //con.Open();
            //SqlCommand cmd = new SqlCommand("delete from stores where stor_id=" + stor_id, con);
            //int result = cmd.ExecuteNonQuery();
            //con.Close();
            //if (result == 1)
            //{
            //    loadStores();
            //    lblmsg.BackColor = Color.Red;
            //    lblmsg.ForeColor = Color.White;
            //    lblmsg.Text = stor_id + "      Deleted successfully.......    ";
            //}
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
                    DropDownList acpEditDl = (e.Row.FindControl("acpEditDl")) as DropDownList;
                    if (e.Row.RowState == DataControlRowState.Edit)
                    {
                        DropDownList acpNewDl = (e.Row.FindControl("acpNewDl")) as DropDownList;
                        if (acpEditDl != null)
                        {
                            ListItem item;
                            foreach (AccountCoursePermit accountCoursePermit in acpList)
                            {
                                item = new ListItem(accountCoursePermit.name, accountCoursePermit.id.ToString());
                                acpEditDl.Items.Insert(acpEditDl.Items.Count, item);
                            }
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
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error procesando su solicitud, 'error'')", true);
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
                    if (!acpNewDl.Text.Equals("")) {
                        if ((inDay1 >= 0) && (inDay2 >= 0) && (inDay3 >= 0) && (inDay4 >= 0) && (inDay5 >= 0) && (inDay6 >= 0) && (inDay7 >= 0) && (inDay8 >= 0) &&
                            (inDay9 >= 0) && (inDay10 >= 0) && (inDay11 >= 0) && (inDay12 >= 0) && (inDay13 >= 0) && (inDay14 >= 0) && (inDay15 >= 0) && (inDay16 >= 0))
                        {
                            AccountCoursePermit accountCoursePermit = new AccountCoursePermit(acpNewDl.SelectedValue, acpNewDl.SelectedItem.Text);
                            workload = new Workload(inDay1, inDay2, inDay3, inDay4, inDay5, inDay6, inDay7, inDay8, inDay9,
                                                    inDay10, inDay11, inDay12, inDay13, inDay14, inDay15, inDay16, timesheet, accountCoursePermit);
                            AddWorkloadToTimesheetCommand cmd = new AddWorkloadToTimesheetCommand(workload);
                            cmd.Execute();
                            int result = cmd.GetResult();
                            if (result != 200)
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
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error procesando su solicitud', 'error')", true);
                }
                /*int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    loadStores();
                }
                else
                {
                    lblmsg.BackColor = Color.Red;
                    lblmsg.ForeColor = Color.White;
                    lblmsg.Text = instorid.Text + " Error while adding row.....";
                }*/
            }
        }
    }
}