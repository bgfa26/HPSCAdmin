using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TimesheetCreationProcess.common;
using System.Data.SqlClient;

namespace TimesheetCreationProcess.model
{
    /// <summary>
    /// Clase abstracta DAO, todos los dao deben heredar de ella
    /// </summary>
    abstract public class DAO
    {
        // El String de conexión se encuentra en el archivo Web.config
        protected string connectionString = ConfigurationManager.ConnectionStrings["bdConnection"].ConnectionString;
        protected SqlConnection connection { set; get; }
        protected SqlCommand command { set; get; }

        #region Metodos para la conexion y desconexion a la base de datos

        /// <summary>
        /// Metodo para realizar la conexion a la base de datos
        /// Excepciones posibles: 
        /// SqlException: Atrapa los errores que pueden existir en el sql server internamente
        /// </summary>
        public SqlConnection Connect()
        {
            try
            {
                connection = new SqlConnection(connectionString);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return connection;
        }

        /// <summary>
        /// Metodo para cerrar la sesion con la base de datos
        /// Excepciones posibles: 
        /// SqlException: Atrapa los errores que pueden existir en el sql server internamente
        /// </summary>
        public void Disconnect()
        {
            try
            {
                this.connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para cerrar la sesion con la base de datos pasando la conexion por parametro
        /// Excepciones posibles: 
        /// SqlException: Atrapa los errores que pueden existir en el SQL Server internamente
        /// </summary>
        public void Disconnect(SqlConnection _connection)
        {
            try
            {
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Metodos para ejecutar procedimientos almacenados en la base de datos

        /// <summary>
        /// Metodo para ejecutar un procedimiento almacenado en la bd
        /// </summary>
        /// <param name="parameter">Lista de parametros que se le va a asociar</param>
        /// <param name="query">Cadena con el query a ejecutar</param>
        public List<ResultDB> ExecuteStoredProcedure(string query, List<ParameterDB> parameters)
        {
            try
            {
                Connect();
                List<ResultDB> results = new List<ResultDB>();
                using (connection)
                {

                    command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    AssignParameters(parameters);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    command.ExecuteNonQuery();
                    if (command.Parameters != null)
                    {
                        foreach (SqlParameter parameter in command.Parameters)
                        {
                            if (parameter.Direction.Equals(ParameterDirection.Output))
                            {
                                ResultDB result = new ResultDB(parameter.ParameterName, parameter.Value.ToString());
                                results.Add(result);
                            }
                        }
                        if (results != null)
                        {
                            return results;
                        }
                    }

                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }


        /// <summary>
        /// Metodo para ejecutar un procedimiento almacenado en la bd que va a devolver una consulta
        /// </summary>
        /// <param name="query">Cadena con el query a ejecutar</param>
        public DataTable ExecuteConsultStoredProcedure(string query)
        {

            try
            {
                Connect();
                DataTable dataTable = new DataTable();
                using (connection)
                {
                    command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        System.Diagnostics.Debug.WriteLine(dataAdapter);
                        System.Diagnostics.Debug.WriteLine(dataTable);
                    }
                    return dataTable;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }



        /// <summary>
        /// Metodo para ejecutar un procedimiento almacenado en la bd que va a devolver una consulta
        /// </summary>
        /// <param name="parameters">Lista de parametros que se le va a asociar</param>
        /// <param name="query">Cadena con el query a ejecutar</param>
        public DataTable ExecuteConsultStoredProcedure(string query, List<ParameterDB> parameters)
        {
            try
            {
                Connect();
                DataTable dataTable = new DataTable();
                using (connection)
                {
                    command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    AssignParameters(parameters);
                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                        System.Diagnostics.Debug.WriteLine(dataAdapter);
                        System.Diagnostics.Debug.WriteLine(dataTable);
                    }
                    return dataTable;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }


        /// <summary>
        /// Metodo para asignar los parametros a un command
        /// </summary>
        /// <param name="parameters">Lista de parametros que se le va a asociar</param>
        public void AssignParameters(List<ParameterDB> parameters)
        {
            foreach (ParameterDB parameter in parameters)
            {
                if (parameter != null && parameter.tag != null && parameter.dataType != null &&
                    parameter.itsOutput != null)
                {
                    if (parameter.itsOutput)
                    {
                        command.Parameters.Add(parameter.tag, parameter.dataType, 32000);
                        command.Parameters[parameter.tag].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        if (parameter.value != null)
                        {
                            command.Parameters.Add(new SqlParameter(parameter.tag, parameter.dataType, 32000));
                            command.Parameters[parameter.tag].Value = parameter.value;
                        }
                        else
                        {
                            throw new ArgumentNullException();
                        }
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }

            }
        }

        #endregion
    }
}
