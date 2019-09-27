using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetCreationProcess.common;
using TimesheetCreationProcess.common.entities;
using TimesheetProcess.model.employee;

namespace TimesheetCreationProcess.model.employee
{
    /// <summary>
    /// Clase que hereda de la clase abstracta DAO para manejar la información de los empleados
    /// </summary>
    class DAOEmployee : DAO
    {
        /// <summary>
        /// Metodo que obtiene los empleados de la base de datos 
        /// </summary>
        /// <returns>Retorna una Lista de Empleados</returns>
        public List<Employee> GetEmployees()
        {
            List<Employee> employeesList = new List<Employee>();
            DataTable dataTable = new DataTable();

            try
            {
                dataTable = ExecuteConsultStoredProcedure(HRMResources.GetEmployeesStoredProcedure);
                Employee employee = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        employee = new Employee(Int32.Parse(row["ID"].ToString()),
                                                row["WORKERID"].ToString(),
                                                row["FIRSTNAME"].ToString(),
                                                row["LASTNAME"].ToString(),
                                                row["EMAIL"].ToString(),
                                                Int32.Parse(row["STATUS"].ToString()),
                                                Int32.Parse(row["PID"].ToString()),
                                                row["POSITIONNAME"].ToString(),
                                                Int32.Parse(row["OUID"].ToString()),
                                                row["OUNAME"].ToString());
                        if (employee.status != 0)
                        {
                            employeesList.Add(employee);
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return employeesList;
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

        /// <summary>
        /// Metodo que obtiene los empleados de la base de datos que no han entregado la hoja de tiempo
        /// </summary>
        /// <returns>Retorna una Lista de Empleados</returns>
        public List<Employee> GetEmployeesOpenTimesheet(DateTime endDate)
        {
            List<Employee> employeesList = new List<Employee>();
            DataTable dataTable = new DataTable();
            List<ParameterDB> parameters = new List<ParameterDB>();
            try
            {
                parameters.Add(new ParameterDB(HRMResources.enddate, SqlDbType.Date, endDate.ToString("yyyy-MM-dd"), false));
                dataTable = ExecuteConsultStoredProcedure(HRMResources.GetOpenTimesheetEmployees, parameters);
                Employee employee = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        employee = new Employee(row["EMAIL"].ToString());

                        employeesList.Add(employee);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return employeesList;
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
