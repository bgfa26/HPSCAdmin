using adminsite.common;
using adminsite.common.entities;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace adminsite.model.timesheet
{
    public class DAOTimesheet : DAO
    {
        public List<Timesheet> GetTimesheetsByEmployee(Employee employee)
        {
            List<Timesheet> timesheetsList = new List<Timesheet>();
            DataTable dataTable = new DataTable();
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.employee, SqlDbType.VarChar, employee.id.ToString(), false));
                dataTable = ExecuteConsultStoredProcedure(TimesheetResources.GetAllTimesheetsByEmployeeStoredProcedure, parameters);
                Timesheet timesheet = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        timesheet = new Timesheet(Int32.Parse(row["ID"].ToString()),
                                                  Convert.ToDateTime(row["INITDATE"].ToString()),
                                                  Convert.ToDateTime(row["ENDDATE"].ToString()),
                                                  row["STATUS"].ToString(),
                                                  employee);
                        timesheetsList.Add(timesheet);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return timesheetsList;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Timesheet GetAllWorkloadsByTimesheet(Timesheet timesheet)
        {
            List<Workload> workloads = new List<Workload>();
            DataTable dataTable = new DataTable();
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.id, SqlDbType.VarChar, timesheet.id.ToString(), false));
                dataTable = ExecuteConsultStoredProcedure(TimesheetResources.GetAllWorkloadsByTimesheet, parameters);
                Workload workload = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        AccountCoursePermit accountCoursePermit = new AccountCoursePermit(row["IDACP"].ToString(), row["NAME"].ToString());
                        workload = new Workload(Int32.Parse(row["ID"].ToString()),
                                                Int32.Parse(row["DAY1"].ToString()),
                                                Int32.Parse(row["DAY2"].ToString()),
                                                Int32.Parse(row["DAY3"].ToString()),
                                                Int32.Parse(row["DAY4"].ToString()),
                                                Int32.Parse(row["DAY5"].ToString()),
                                                Int32.Parse(row["DAY6"].ToString()),
                                                Int32.Parse(row["DAY7"].ToString()),
                                                Int32.Parse(row["DAY8"].ToString()),
                                                Int32.Parse(row["DAY9"].ToString()),
                                                Int32.Parse(row["DAY10"].ToString()),
                                                Int32.Parse(row["DAY11"].ToString()),
                                                Int32.Parse(row["DAY12"].ToString()),
                                                Int32.Parse(row["DAY13"].ToString()),
                                                Int32.Parse(row["DAY14"].ToString()),
                                                Int32.Parse(row["DAY15"].ToString()),
                                                Int32.Parse(row["DAY16"].ToString()),
                                                timesheet,
                                                accountCoursePermit);
                        workloads.Add(workload);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                timesheet.workloads = workloads;
                return timesheet;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<AccountCoursePermit> GetAllACPPerOU(OrganizationalUnit unit)
        {
            List<AccountCoursePermit> accountCoursePermits = new List<AccountCoursePermit>();
            DataTable dataTable = new DataTable();
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.unit, SqlDbType.Int, unit.id.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.today, SqlDbType.Date, DateTime.Now.ToString("yyyy-MM-dd"), false));
                dataTable = ExecuteConsultStoredProcedure(TimesheetResources.GetAllACPPerOUStoredProcedure, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        AccountCoursePermit accountCoursePermit = new AccountCoursePermit(row["IDACP"].ToString(), row["NAME"].ToString());
                        accountCoursePermits.Add(accountCoursePermit);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return accountCoursePermits;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}