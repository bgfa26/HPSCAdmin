using adminsite.common;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace adminsite.model.hrm
{
    public class DAOHumanResourcesManagement : DAO
    {
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



        /// <summary>
        /// Metodo que cambia el estatus de activo a eliminado en la base de datos
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="employee">Empleado que se va a eliminar</param>
        public int DeleteEmployee(Employee employee)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(HRMResources.id, SqlDbType.Int, employee.id.ToString(), false));
                ExecuteStoredProcedure(HRMResources.DeleteEmployeeStoredProcedure, parameters);
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