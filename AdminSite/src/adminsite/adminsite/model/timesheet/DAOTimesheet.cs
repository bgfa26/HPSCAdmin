﻿using adminsite.common;
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
    /// <summary>
    /// Clase encargada al acceso de datos para el manejo de hojas de trabajo
    /// </summary>
    public class DAOTimesheet : DAO
    {
        /// <summary>
        /// Metodo que obtiene de la base de datos la informacion de una hoja de tiempo dado un empleado
        /// </summary>
        /// <returns>Retorna una lista de Hojas de Tiempo</returns>
        /// <param name="employee">Empleado del cual se obtiene la hoja de tiempo</param>
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
                        timesheet = new Timesheet(Int64.Parse(row["ID"].ToString()),
                                                  Convert.ToDateTime(row["INITDATE"].ToString()),
                                                  Convert.ToDateTime(row["ENDDATE"].ToString()),
                                                  row["STATUS"].ToString(),
                                                  employee,
                                                  row["COMMENT"].ToString());
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
        /// Metodo que elimina de la base de datos la informacion de una carga de trabajo
        /// </summary>
        /// <returns>Retorna una entero</returns>
        /// <param name="workloadToDelete">Carga de trabajo a eliminar</param>
        public int DeleteWorkload(Workload workloadToDelete)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.id, SqlDbType.Int, workloadToDelete.id.ToString(), false));
                ExecuteStoredProcedure(TimesheetResources.DeleteWorkloadStoredProcedure, parameters);
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

        /// <summary>
        /// Metodo que obtiene de la base de datos la informacion de una carga de trabajo dada una hoja de tiempo
        /// </summary>
        /// <returns>Retorna una hoja de tiempo</returns>
        /// <param name="timesheet">Hoja de tiempo en donde se encuentran las cargas de trabajo</param>
        public Timesheet GetAllWorkloadsByTimesheet(Timesheet timesheet)
        {
            List<Workload> workloads = new List<Workload>();
            DataTable dataTable = new DataTable();
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.id, SqlDbType.BigInt, timesheet.id.ToString(), false));
                dataTable = ExecuteConsultStoredProcedure(TimesheetResources.GetAllWorkloadsByTimesheet, parameters);
                Workload workload = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        AccountCoursePermit accountCoursePermit = new AccountCoursePermit(row["IDACP"].ToString(), row["NAME"].ToString());
                        timesheet.initDate = Convert.ToDateTime(row["INITDATE"].ToString());
                        timesheet.endDate = Convert.ToDateTime(row["ENDDATE"].ToString());
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
                timesheet.workloads = workloads;
                dataTable = ExecuteConsultStoredProcedure(TimesheetResources.GetTimesheetByIDStoredProcedure, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        timesheet.initDate = Convert.ToDateTime(row["INITDATE"].ToString());
                        timesheet.endDate = Convert.ToDateTime(row["ENDDATE"].ToString());
                        timesheet.comment = row["COMMENT"].ToString();
                        timesheet.status = row["STATUS"].ToString();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
                return timesheet;
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
        /// Metodo que obtiene de la base de datos la informacion de una cuenta, curso o permiso por unidad organizacional
        /// </summary>
        /// <returns>Retorna una lista de cuentas,cursos y permisos</returns>
        /// <param name="unit">Unidad Organizacional que maneja las cuentas/cursos/permisos</param>
        public List<AccountCoursePermit> GetAllACPPerOU(OrganizationalUnit unit)
        {
            List<AccountCoursePermit> accountCoursePermits = new List<AccountCoursePermit>();
            DataTable dataTable = new DataTable();
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.unit, SqlDbType.Int, unit.id.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.today, SqlDbType.Date, DateTime.Now.ToString("yyyy-MM-dd"), false));
                dataTable = ExecuteConsultStoredProcedure(TimesheetResources.GetAllACPPerOUStoredProcedure, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        AccountCoursePermit accountCoursePermit = new AccountCoursePermit(row["IDACP"].ToString(), row["NAME"].ToString());
                        accountCoursePermits.Add(accountCoursePermit);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return accountCoursePermits;
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
        /// Metodo que agrega a la base de datos la información de una hoja de tiempo perteneciente a una carga de trabajo
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="workloadToInsert">Carga de trabajo a la cual se le va a insertar información</param>
        public int AddWorkloadToTimesheet(Workload workloadToInsert)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.day1, SqlDbType.Int, workloadToInsert.day1.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day2, SqlDbType.Int, workloadToInsert.day2.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day3, SqlDbType.Int, workloadToInsert.day3.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day4, SqlDbType.Int, workloadToInsert.day4.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day5, SqlDbType.Int, workloadToInsert.day5.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day6, SqlDbType.Int, workloadToInsert.day6.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day7, SqlDbType.Int, workloadToInsert.day7.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day8, SqlDbType.Int, workloadToInsert.day8.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day9, SqlDbType.Int, workloadToInsert.day9.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day10, SqlDbType.Int, workloadToInsert.day10.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day11, SqlDbType.Int, workloadToInsert.day11.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day12, SqlDbType.Int, workloadToInsert.day12.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day13, SqlDbType.Int, workloadToInsert.day13.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day14, SqlDbType.Int, workloadToInsert.day14.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day15, SqlDbType.Int, workloadToInsert.day15.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day16, SqlDbType.Int, workloadToInsert.day16.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.fk_timesheet, SqlDbType.BigInt, workloadToInsert.timesheet.id.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.fk_accountcoursepermit, SqlDbType.VarChar, workloadToInsert.accountCoursePermit.id, false));
                parameters.Add(new ParameterDB(TimesheetResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(TimesheetResources.CreateWorkloadStoredProcedure, parameters);
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
        /// Metodo que modifica de la base de datos la información de una carga de trabajo
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="workloadToUpdate">Carga de trabajo a la cual se le va a modificar información</param>
        public int UpdateWorkload(Workload workloadToUpdate)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.id, SqlDbType.Int, workloadToUpdate.id.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day1, SqlDbType.Int, workloadToUpdate.day1.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day2, SqlDbType.Int, workloadToUpdate.day2.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day3, SqlDbType.Int, workloadToUpdate.day3.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day4, SqlDbType.Int, workloadToUpdate.day4.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day5, SqlDbType.Int, workloadToUpdate.day5.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day6, SqlDbType.Int, workloadToUpdate.day6.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day7, SqlDbType.Int, workloadToUpdate.day7.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day8, SqlDbType.Int, workloadToUpdate.day8.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day9, SqlDbType.Int, workloadToUpdate.day9.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day10, SqlDbType.Int, workloadToUpdate.day10.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day11, SqlDbType.Int, workloadToUpdate.day11.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day12, SqlDbType.Int, workloadToUpdate.day12.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day13, SqlDbType.Int, workloadToUpdate.day13.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day14, SqlDbType.Int, workloadToUpdate.day14.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day15, SqlDbType.Int, workloadToUpdate.day15.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.day16, SqlDbType.Int, workloadToUpdate.day16.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.fk_timesheet, SqlDbType.BigInt, workloadToUpdate.timesheet.id.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.fk_accountcoursepermit, SqlDbType.VarChar, workloadToUpdate.accountCoursePermit.id, false));
                parameters.Add(new ParameterDB(TimesheetResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(TimesheetResources.UpdateWorkloadStoredProcedure, parameters);
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
        /// Metodo que modifica de la base de datos la información de una hoja de tiempo
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="timesheetToUpdate">Hoja de tiempo a la cual se le va a modificar información</param>
        public int UpdateTimesheetStatus(Timesheet timesheetToUpdate)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.id, SqlDbType.BigInt, timesheetToUpdate.id.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.status, SqlDbType.VarChar, timesheetToUpdate.status, false));
                parameters.Add(new ParameterDB(TimesheetResources.comment, SqlDbType.VarChar, timesheetToUpdate.comment, false));
                parameters.Add(new ParameterDB(TimesheetResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(TimesheetResources.UpdateTimesheetStatusStoredProcedure, parameters);
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
        /// Método que modifica de la base de datos el estatus de una carga de trabajo
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="workloadToUpdate">Carga de trabajo a la cual se le va a modificar el estatus</param>
        public int UpdateWorkloadStatus(Workload workloadToUpdate)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(TimesheetResources.id, SqlDbType.Int, workloadToUpdate.id.ToString(), false));
                parameters.Add(new ParameterDB(TimesheetResources.status, SqlDbType.VarChar, workloadToUpdate.status, false));
                parameters.Add(new ParameterDB(TimesheetResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(TimesheetResources.UpdateWorkloadStatusStoredProcedure, parameters);
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