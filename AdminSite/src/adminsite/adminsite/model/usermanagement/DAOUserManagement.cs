using adminsite.common.entities;
using adminsite.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace adminsite.model.usermanagement
{
    /// <summary>
    /// Clase encargada al acceso de datos para el manejo de usuarios
    /// </summary>
    public class DAOUserManagement : DAO
    {
        /// <summary>
        /// Metodo que obtiene de la base de datos la informacion de un empleado dado un correo electronico
        /// </summary>
        /// <returns>Retorna un Empleado</returns>
        /// <param name="employee">Empleado del cual se quiere obtener informacion</param>
        public Employee GetEmployeeByEmail(Employee employee)
        {
            DataTable dataTable;
            List<ParameterDB> parameter = new List<ParameterDB>();

            try
            {

                parameter.Add(new ParameterDB(UserManagementResources.email, SqlDbType.VarChar, employee.email, false));

                dataTable = ExecuteConsultStoredProcedure(UserManagementResources.GetEmployeeByEmailStoredProcedure, parameter);
                Employee checkedEmployee = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        checkedEmployee = new Employee(
                                                Int32.Parse(row["ID"].ToString()),
                                                row["WORKERID"].ToString(),
                                                row["FIRSTNAME"].ToString(),
                                                row["LASTNAME"].ToString(),
                                                row["EMAIL"].ToString(),
                                                row["PASSWORD"].ToString(),
                                                Int32.Parse(row["STATUS"].ToString()),
                                                Int32.Parse(row["POSITIONID"].ToString()),
                                                row["POSITIONNAME"].ToString(),
                                                Int32.Parse(row["OUID"].ToString()),
                                                row["OUNAME"].ToString()
                                          );
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return checkedEmployee;
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
        /// Metodo para actualizar en la base de datos la contraseña de un empleado
        /// </summary>
        /// <returns>Retorna un Employee</returns>
        /// <param name="employee">Empleado que desea actualizar su contraseña</param>
        public int UpdateEmployeePassword(Employee employee)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(UserManagementResources.email, SqlDbType.VarChar, employee.email, false));
                parameters.Add(new ParameterDB(UserManagementResources.password, SqlDbType.VarChar, employee.password, false));
                parameters.Add(new ParameterDB(UserManagementResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(UserManagementResources.UpdateEmployeePasswordStoredProcedure, parameters);
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

        /// <summary>
        /// Metodo que valida en la base de datos si existe duplicado una cedula, correo o codigo de trabajador
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="employee">Empleado del cual se va a validar la informacion</param>
        public int ValidateDuplicatedIdEmail(Employee employee)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(UserManagementResources.id, SqlDbType.Int, employee.id.ToString(), false));
                parameters.Add(new ParameterDB(UserManagementResources.workerid, SqlDbType.VarChar, employee.workerId, false));
                parameters.Add(new ParameterDB(UserManagementResources.email, SqlDbType.VarChar, employee.email, false));
                parameters.Add(new ParameterDB(UserManagementResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(UserManagementResources.ValidateDuplicatedIDEmailStoredProcedure, parameters);
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

        /// <summary>
        /// Metodo para agregar en la base de datos un nuevo empleado
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="employee">Empleado que se va a registrar</param>
        public int AddEmployee(Employee employee)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(UserManagementResources.id, SqlDbType.Int, employee.id.ToString(), false));
                parameters.Add(new ParameterDB(UserManagementResources.workerid, SqlDbType.VarChar, employee.workerId, false));
                parameters.Add(new ParameterDB(UserManagementResources.firstname, SqlDbType.VarChar, employee.firstName, false));
                parameters.Add(new ParameterDB(UserManagementResources.lastname, SqlDbType.VarChar, employee.lastName, false));
                parameters.Add(new ParameterDB(UserManagementResources.email, SqlDbType.VarChar, employee.email, false));
                parameters.Add(new ParameterDB(UserManagementResources.password, SqlDbType.VarChar, employee.password, false));
                parameters.Add(new ParameterDB(UserManagementResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(UserManagementResources.CreateEmployeeStoredProcedure, parameters);
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