using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetCreationProcess.common;
using TimesheetCreationProcess.common.entities;

namespace TimesheetCreationProcess.model.timesheet
{
    class DAOTimesheet : DAO
    {

        public int AddTimesheetsPerEmployee(List<Employee> employees)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();
            DateTime initDate = new DateTime();
            DateTime endDate = new DateTime();
            try
            {
                foreach (Employee employee in employees)
                {
                    string idTimesheet = employee.id.ToString() + endDate.Day.ToString() + endDate.Month.ToString() + endDate.Year.ToString();
                    parameters.Add(new ParameterDB(TimesheetResources.id, SqlDbType.Int, idTimesheet.ToString(), false));
                    parameters.Add(new ParameterDB(TimesheetResources.initdate, SqlDbType.Date, initDate.ToString("yyyy-MM-dd"), false));
                    parameters.Add(new ParameterDB(TimesheetResources.enddate, SqlDbType.Int, endDate.ToString("yyyy-MM-dd"), false));
                    parameters.Add(new ParameterDB(TimesheetResources.status, SqlDbType.VarChar, "ABIERTA", false));
                    parameters.Add(new ParameterDB(TimesheetResources.fk_employee, SqlDbType.Int, employee.id.ToString(), false));
                    ExecuteStoredProcedure(TimesheetResources.CreateTimesheetStoredProcedure, parameters);
                }
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
    }
}
