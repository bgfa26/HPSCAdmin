using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetCreationProcess.common;
using TimesheetCreationProcess.common.entities;
using TimesheetProcess.model.timesheet;

namespace TimesheetCreationProcess.model.timesheet
{
    /// <summary>
    /// Clase que hereda de la clase abstracta DAO usada para manejar las hojas de tiempo de cada empleado
    /// </summary>
    class DAOTimesheet : DAO
    {
        /// <summary>
        /// Metodo que agrega a la base de datos las hojas de tiempo
        /// </summary>
        /// <returns>Retorna un entero</returns>
        public int AddTimesheetsPerEmployee(DateTime initDate, DateTime endDate, List<Employee> employees)
        {
            try
            {
                foreach (Employee employee in employees)
                {
                    List<ParameterDB> parameters = new List<ParameterDB>();
                    string idTimesheet = employee.id.ToString() + endDate.Day.ToString() + endDate.Month.ToString() + endDate.Year.ToString();
                    long id = Int64.Parse(idTimesheet);
                    parameters.Add(new ParameterDB(TimesheetResources.id, SqlDbType.BigInt, id.ToString(), false));
                    parameters.Add(new ParameterDB(TimesheetResources.initdate, SqlDbType.Date, initDate.ToString("yyyy-MM-dd"), false));
                    parameters.Add(new ParameterDB(TimesheetResources.enddate, SqlDbType.Date, endDate.ToString("yyyy-MM-dd"), false));
                    parameters.Add(new ParameterDB(TimesheetResources.status, SqlDbType.VarChar, "ABIERTA", false));
                    parameters.Add(new ParameterDB(TimesheetResources.fk_employee, SqlDbType.Int, employee.id.ToString(), false));
                    parameters.Add(new ParameterDB(TimesheetResources.exitvalue, SqlDbType.Int, true));
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
