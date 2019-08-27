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

        public int DeleteWorkload(Workload workloadToDelete)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.id, SqlDbType.Int, workloadToDelete.id.ToString(), false));
                ExecuteStoredProcedure(TimesheetResources.DeleteWorkloadStoredProcedure, parameters);
                int result = 200;
                return result;
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
                        timesheet.initDate = Convert.ToDateTime(row["INITDATE"].ToString());
                        timesheet.endDate = Convert.ToDateTime(row["ENDDATE"].ToString());
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
                                                row["STATUS"].ToString(),
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
                dataTable = ExecuteConsultStoredProcedure(TimesheetResources.GetTimesheetDatesStoredProcedure, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        timesheet.initDate = Convert.ToDateTime(row["INITDATE"].ToString());
                        timesheet.endDate = Convert.ToDateTime(row["ENDDATE"].ToString());
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
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
        
        public int AddWorkloadToTimesheet(Workload workloadToInsert)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.day1, SqlDbType.Int, workloadToInsert.day1.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day2, SqlDbType.Int, workloadToInsert.day2.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day3, SqlDbType.Int, workloadToInsert.day3.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day4, SqlDbType.Int, workloadToInsert.day4.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day5, SqlDbType.Int, workloadToInsert.day5.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day6, SqlDbType.Int, workloadToInsert.day6.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day7, SqlDbType.Int, workloadToInsert.day7.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day8, SqlDbType.Int, workloadToInsert.day8.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day9, SqlDbType.Int, workloadToInsert.day9.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day10, SqlDbType.Int, workloadToInsert.day10.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day11, SqlDbType.Int, workloadToInsert.day11.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day12, SqlDbType.Int, workloadToInsert.day12.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day13, SqlDbType.Int, workloadToInsert.day13.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day14, SqlDbType.Int, workloadToInsert.day14.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day15, SqlDbType.Int, workloadToInsert.day15.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day16, SqlDbType.Int, workloadToInsert.day16.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.fk_timesheet, SqlDbType.Int, workloadToInsert.timesheet.id.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.fk_accountcoursepermit, SqlDbType.VarChar, workloadToInsert.accountCoursePermit.id, false));
                parameters.Add(new ParameterDB(TimesheetResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(TimesheetResources.CreateWorkloadStoredProcedure, parameters);
                int result = Int32.Parse(results[0].value);
                return result;
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

        public int UpdateWorkload(Workload workloadToUpdate)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.id, SqlDbType.Int, workloadToUpdate.id.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day1, SqlDbType.Int, workloadToUpdate.day1.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day2, SqlDbType.Int, workloadToUpdate.day2.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day3, SqlDbType.Int, workloadToUpdate.day3.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day4, SqlDbType.Int, workloadToUpdate.day4.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day5, SqlDbType.Int, workloadToUpdate.day5.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day6, SqlDbType.Int, workloadToUpdate.day6.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day7, SqlDbType.Int, workloadToUpdate.day7.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day8, SqlDbType.Int, workloadToUpdate.day8.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day9, SqlDbType.Int, workloadToUpdate.day9.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day10, SqlDbType.Int, workloadToUpdate.day10.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day11, SqlDbType.Int, workloadToUpdate.day11.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day12, SqlDbType.Int, workloadToUpdate.day12.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day13, SqlDbType.Int, workloadToUpdate.day13.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day14, SqlDbType.Int, workloadToUpdate.day14.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day15, SqlDbType.Int, workloadToUpdate.day15.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day16, SqlDbType.Int, workloadToUpdate.day16.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.fk_timesheet, SqlDbType.Int, workloadToUpdate.timesheet.id.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.fk_accountcoursepermit, SqlDbType.VarChar, workloadToUpdate.accountCoursePermit.id, false));
                parameters.Add(new ParameterDB(TimesheetResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(TimesheetResources.UpdateWorkloadStoredProcedure, parameters);
                int result = Int32.Parse(results[0].value);
                return result;
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

        public int UpdateTimesheetStatus(Timesheet timesheetToUpdate)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.id, SqlDbType.Int, timesheetToUpdate.id.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.status, SqlDbType.VarChar, timesheetToUpdate.status, false));
                parameters.Add(new ParameterDB(TimesheetResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(TimesheetResources.UpdateTimesheetStatusStoredProcedure, parameters);
                int result = Int32.Parse(results[0].value);
                return result;
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

        public int UpdateWorkloadStatus(Workload workloadToUpdate)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.id, SqlDbType.Int, workloadToUpdate.id.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.status, SqlDbType.VarChar, workloadToUpdate.status, false));
                parameters.Add(new ParameterDB(TimesheetResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(TimesheetResources.UpdateWorkloadStatusStoredProcedure, parameters);
                int result = Int32.Parse(results[0].value);
                return result;
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