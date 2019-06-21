using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace adminsite.model.usermanagement
{
    abstract public class DAO
    {
        // El String de conexion se encuentra en el archivo Web.config
        protected string connectionString = ConfigurationManager.ConnectionStrings["bdConnection"].ConnectionString;
        protected SqlConnection connection { set; get; }
        protected SqlCommand command { set; get; }

        #region Conexion a la base de datos
        /// <summary>
        /// Metodo para realizar la conexion a la base de datos
        /// Excepciones posibles: 
        /// SqlException: Excepciones sql
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
        #endregion
    }
}