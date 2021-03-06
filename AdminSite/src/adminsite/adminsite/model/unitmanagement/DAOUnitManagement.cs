﻿using adminsite.common;
using adminsite.common.entities;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace adminsite.model.unitmanagement
{
    /// <summary>
    /// Clase encargada al acceso de datos para el manejo de unidades organizacionales
    /// </summary>
    public class DAOUnitManagement : DAO
    {
        /// <summary>
        /// Metodo que obtiene de la base de datos la informacion de una hoja de tiempo dada una unidad organizacional
        /// </summary>
        /// <returns>Retorna una lista de Hojas de Tiempo</returns>
        /// <param name="employee">Empleado que supervisa la unidad</param>
        public List<Timesheet> GetTimesheetsByUnit(Employee employee)
        {
            List<Timesheet> timesheetsList = new List<Timesheet>();
            DataTable dataTable = new DataTable();
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(UnitManagementResources.id, SqlDbType.Int, employee.id.ToString(), false));
                dataTable = ExecuteConsultStoredProcedure(UnitManagementResources.GetTimesheetsByUnitStoredProcedure, parameters);
                Timesheet timesheet = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        Employee supervisedEmployee = new Employee(Int32.Parse(row["EID"].ToString()), row["EFIRSTNAME"].ToString(), row["ELASTNAME"].ToString());
                        timesheet = new Timesheet(Int64.Parse(row["TID"].ToString()),
                                                  Convert.ToDateTime(row["TINITDATE"].ToString()),
                                                  Convert.ToDateTime(row["TENDDATE"].ToString()),
                                                  row["STATUS"].ToString(),
                                                  supervisedEmployee,
                                                  row["TCOMMENT"].ToString());
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

        /// <summary>
        /// Metodo que obtiene de la base de datos la informacion del supervisor de una unidad organizacional
        /// </summary>
        /// <returns>Retorna una unidad organizacional</returns>
        /// <param name="ouConsult">Empleado que supervisa la unidad</param>
        public OrganizationalUnit GetOverseerUnit(OrganizationalUnit ouConsult)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();
            OrganizationalUnit organizationalUnit = new OrganizationalUnit(-1);
            DataTable dataTable = new DataTable();

            try
            {
                parameters.Add(new ParameterDB(UnitManagementResources.id, SqlDbType.VarChar, ouConsult.overseer.ToString(), false));
                dataTable = ExecuteConsultStoredProcedure(UnitManagementResources.GetOverseerUnitStoredProcedure, parameters);

                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        organizationalUnit = new OrganizationalUnit(Int32.Parse(row["OUID"].ToString()), row["OUNAME"].ToString(), Int32.Parse(row["IDEMPLOYEE"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return organizationalUnit;
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