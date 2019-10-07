using adminsite.common;
using adminsite.common.entities;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace adminsite.model.hrm
{
    /// <summary>
    /// Clase que hereda de la clase abstracta DAO usada para el manejo de datos relacionados con recursos humanos
    /// </summary>
    public class DAOHumanResourcesManagement : DAO
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
        
        /// <summary>
        /// Metodo que lista todas las unidades organizacionales
        /// </summary>
        /// <returns>Retorna una lista</returns>
        public List<OrganizationalUnit> GetAllOrganizationalUnits()
        {
            List<OrganizationalUnit> ouList = new List<OrganizationalUnit>();
            DataTable dataTable = new DataTable();

            try
            {
                dataTable = ExecuteConsultStoredProcedure(HRMResources.GetAllOrganizationalUnitsStoredProcedure);
                OrganizationalUnit ou = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        string employeeId = row["EMPLOYEEID"].ToString();
                        if (!employeeId.Equals(""))
                        {
                            ou = new OrganizationalUnit(Int32.Parse(row["OUID"].ToString()),
                                                        row["OUNAME"].ToString(),
                                                        Int32.Parse(row["EMPLOYEEID"].ToString()));
                        }
                        else
                        {
                            ou = new OrganizationalUnit(Int32.Parse(row["OUID"].ToString()),
                                                        row["OUNAME"].ToString(),
                                                        0);
                        }
                        ouList.Add(ou);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return ouList;
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
        /// Metodo que lista todos los cargos de la organizacion
        /// </summary>
        /// <returns>Retorna una lista</returns>
        public List<Position> GetAllPositions()
        {
            List<Position> positionList = new List<Position>();
            DataTable dataTable = new DataTable();

            try
            {
                dataTable = ExecuteConsultStoredProcedure(HRMResources.GetAllPositionsStoredProcedure);
                Position position = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        position = new Position(Int32.Parse(row["POSITIONID"].ToString()),
                                                    row["POSITIONNAME"].ToString());

                        positionList.Add(position);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return positionList;
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
        /// Metodo para modificar el cargo de un empleado
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="employee">Empleado al que se le modificara el cargo</param>
        public int UpdateEmployeePositionUnit(Employee employee)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(HRMResources.id, SqlDbType.Int, employee.id.ToString(), false));
                parameters.Add(new ParameterDB(HRMResources.idposition, SqlDbType.Int, employee.idPosition.ToString(), false));
                parameters.Add(new ParameterDB(HRMResources.idou, SqlDbType.Int, employee.idOrganizationalUnit.ToString(), false));
                parameters.Add(new ParameterDB(HRMResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(HRMResources.UpdatePositionOrganizationalUnitStoredProcedure, parameters);
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
        /// Metodo para modificar el supervisor de una unidad organizacional
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="organizationalUnit">Unidad Organizacional a la cual se le modificara el supervisor</param>
        public int UpdateUnitOverseer(OrganizationalUnit organizationalUnit)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(HRMResources.idou, SqlDbType.Int, organizationalUnit.id.ToString(), false));
                parameters.Add(new ParameterDB(HRMResources.id, SqlDbType.Int, organizationalUnit.overseer.ToString(), false));
                parameters.Add(new ParameterDB(HRMResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(HRMResources.UpdateOrganizationalUnitOverseerStoredProcedure, parameters);
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
        /// Metodo para eliminar el supervisor de una unidad organizacional
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="organizationalUnit">Unidad Organizacional a la cual se le eliminara el supervisor</param>
        public int RemoveUnitOverseer(OrganizationalUnit organizationalUnit)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(HRMResources.idou, SqlDbType.Int, organizationalUnit.id.ToString(), false));
                parameters.Add(new ParameterDB(HRMResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(HRMResources.RemoveOrganizationalUnitOverseerStoredProcedure, parameters);
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
        /// Metodo para obtener las hojas de tiempo por empledo
        /// </summary>
        /// <returns>Retorna una lista de Hojas de Tiempo</returns>
        /// <param name="year">Año en el cual se buscarán las hojas de tiempo</param>
        public List<Timesheet> GetTimesheetsByEmployee(int year)
        {
            List<Timesheet> timesheetsList = new List<Timesheet>();
            DataTable dataTable = new DataTable();
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(HRMResources.year, SqlDbType.VarChar, year.ToString(), false));
                dataTable = ExecuteConsultStoredProcedure(HRMResources.GetAllTimesheetsHrmStoredProcedure, parameters);
                Timesheet timesheet = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        Employee employee = new Employee(Int32.Parse(row["EID"].ToString()), row["EFIRSTNAME"].ToString(), row["ELASTNAME"].ToString());
                        employee.email = row["EEMAIL"].ToString();
                        timesheet = new Timesheet(Int64.Parse(row["TID"].ToString()),
                                                  Convert.ToDateTime(row["TINITDATE"].ToString()),
                                                  Convert.ToDateTime(row["TENDDATE"].ToString()),
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

        public List<Report> GetManagerPendingACPHours(DateTime initDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Report> GetOverseerPendingTimesheets(DateTime initDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Report> GetTimesheetsReport(DateTime initDate, DateTime endDate, int reportType)
        {
            List<Report> reports = new List<Report>();
            DataTable dataTable = new DataTable();
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(HRMResources.initdate, SqlDbType.Date, initDate.ToString("yyyy-MM-dd"), false));
                parameters.Add(new ParameterDB(HRMResources.enddate, SqlDbType.Date, endDate.ToString("yyyy-MM-dd"), false));
                if (reportType == 0)
                {
                    dataTable = ExecuteConsultStoredProcedure(HRMResources.GetEmployeesWithOpenTimesheetsStoredProcedure, parameters);
                }
                else if (reportType == 1)
                {
                    dataTable = ExecuteConsultStoredProcedure(HRMResources.GetOverseersWithPendingApprovalsStoredProcedure, parameters);
                }
                else
                {
                    dataTable = ExecuteConsultStoredProcedure(HRMResources.GetManagersWithPendingApprovalsStoredProcedure1, parameters);
                }
                if ((reportType == 0) || (reportType == 1))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        try
                        {
                            Report report = new Report(Int32.Parse(row["EOID"].ToString()),
                                                       row["EOFIRSTNAME"].ToString(),
                                                       row["EOLASTNAME"].ToString(),
                                                       row["OUNAME"].ToString());
                            reports.Add(report);
                        }
                        catch (Exception ex)
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        try
                        {
                            Report consultedReport = new Report(Int32.Parse(row["EID"].ToString()),
                                                       row["EFIRSTNAME"].ToString(),
                                                       row["ELASTNAME"].ToString(),
                                                       row["ACPNAME"].ToString());
                            bool contain = reports.Contains(consultedReport);
                            if (contain)
                            {
                                foreach (Report report in reports)
                                {
                                    if (report.id == consultedReport.id)
                                    {
                                        if (!report.unitAccount.Contains(consultedReport.unitAccount))
                                        {
                                            report.unitAccount += ", " + consultedReport.unitAccount;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                reports.Add(consultedReport);
                            }
                        }
                        catch (Exception ex)
                        {
                            return null;
                        }
                    }
                }
                return reports;
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