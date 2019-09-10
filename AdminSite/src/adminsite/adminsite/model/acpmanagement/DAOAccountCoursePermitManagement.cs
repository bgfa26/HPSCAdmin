using adminsite.common;
using adminsite.common.entities;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace adminsite.model.acpmanagement
{
    /// <summary>
    /// Clase encargada al acceso de datos para el manejo de las cuentas/cursos/permisos
    /// </summary>
    public class DAOAccountCoursePermitManagement : DAO
    {

        /// <summary>
        /// Metodo que obtiene de la base de datos la informacion de la carga de trabajo por cuenta/curso/permiso
        /// </summary>
        /// <returns>Retorna una lista de cargas de trabajo</returns>
        /// <param name="id">Id de la cuenta/curso/permiso</param>
        /// <param name="initDate">Fecha de inicio</param>
        /// <param name="endDate">Fecha de fin</param>
        public List<Workload> GetAllWorkloadsByACP(string id, DateTime initDate, DateTime endDate)
        {
            List<Workload> workloads = new List<Workload>();
            DataTable dataTable = new DataTable();
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(ACPManagementResources.id, SqlDbType.VarChar, id, false));
                parameters.Add(new ParameterDB(ACPManagementResources.initdate, SqlDbType.Date, initDate.ToString("yyyy-MM-dd"), false));
                parameters.Add(new ParameterDB(ACPManagementResources.enddate, SqlDbType.Date, endDate.ToString("yyyy-MM-dd"), false));
                dataTable = ExecuteConsultStoredProcedure(ACPManagementResources.GetWorkloadPerACPStoredProcedure, parameters);
                Workload workload = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        AccountCoursePermit accountCoursePermit = new AccountCoursePermit(id);
                        Timesheet timesheet = new Timesheet(Int64.Parse(row["TID"].ToString()));
                        Employee employee = new Employee(Int32.Parse(row["EID"].ToString()), row["EFIRSTNAME"].ToString(), row["ELASTNAME"].ToString());
                        timesheet.initDate = Convert.ToDateTime(initDate);
                        timesheet.endDate = Convert.ToDateTime(endDate);
                        timesheet.employee = employee;
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
                return workloads;
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