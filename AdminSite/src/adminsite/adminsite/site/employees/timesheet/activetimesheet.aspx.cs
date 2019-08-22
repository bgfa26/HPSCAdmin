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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "randomText", "errorSweetAlert('Se ha generado un error procesando su solicitud, 'error'')", true);
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
            //if (e.CommandName.Equals("AddNew"))
            //{
            //    TextBox instorid = (TextBox)gridView.FooterRow.FindControl("instorid");
            //    TextBox inname = (TextBox)gridView.FooterRow.FindControl("inname");
            //    TextBox inaddress = (TextBox)gridView.FooterRow.FindControl("inaddress");
            //    TextBox incity = (TextBox)gridView.FooterRow.FindControl("incity");
            //    TextBox instate = (TextBox)gridView.FooterRow.FindControl("instate");
            //    TextBox inzip = (TextBox)gridView.FooterRow.FindControl("inzip");
            //    con.Open();
            //    SqlCommand cmd =
            //        new SqlCommand(
            //            "insert into stores(stor_id,stor_name,stor_address,city,state,zip) values('" + instorid.Text + "','" +
            //            inname.Text + "','" + inaddress.Text + "','" + incity.Text + "','" + instate.Text + "','" + inzip.Text + "')", con);
            //    int result = cmd.ExecuteNonQuery();
            //    con.Close();
            //    if (result == 1)
            //    {
            //        loadStores();
            //        lblmsg.BackColor = Color.Green;
            //        lblmsg.ForeColor = Color.White;
            //        lblmsg.Text = instorid.Text + "      Added successfully......    ";
            //    }
            //    else
            //    {
            //        lblmsg.BackColor = Color.Red;
            //        lblmsg.ForeColor = Color.White;
            //        lblmsg.Text = instorid.Text + " Error while adding row.....";
            //    }
            //}
        }
    }
}