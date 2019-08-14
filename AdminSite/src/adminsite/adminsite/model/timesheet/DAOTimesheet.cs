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
    }
}