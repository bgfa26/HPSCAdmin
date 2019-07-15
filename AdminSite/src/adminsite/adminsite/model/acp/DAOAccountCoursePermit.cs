using adminsite.common;
using adminsite.common.entities;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace adminsite.model.acp
{
    public class DAOAccountCoursePermit : DAO
    {
        public List<OrganizationalUnit> GetOrganizationalUnits()
        {
            List<OrganizationalUnit> unitsList = new List<OrganizationalUnit>();
            DataTable dataTable = new DataTable();

            try
            {
                dataTable = ExecuteConsultStoredProcedure(ACPResources.GetOrganizationalUnitsCommand);
                OrganizationalUnit unit = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        unit = new OrganizationalUnit(Int32.Parse(row["OUID"].ToString()),
                                                      row["OUNAME"].ToString());
                        unitsList.Add(unit);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return unitsList;
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
        /// Metodo para agregar en la base de datos un nuevo ACP
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="acpToInsert">ACP que se va a registrar</param>
        public int AddAccountCoursePermit(AccountCoursePermit acpToInsert)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(ACPResources.id, SqlDbType.VarChar, acpToInsert.id.ToString(), false));
                parameters.Add(new ParameterDB(ACPResources.name, SqlDbType.VarChar, acpToInsert.name, false));
                parameters.Add(new ParameterDB(ACPResources.type, SqlDbType.Int, acpToInsert.type.ToString(), false));
                parameters.Add(new ParameterDB(ACPResources.initdate, SqlDbType.Date, acpToInsert.initDate.ToString("yyyy-MM-dd"), false));
                parameters.Add(new ParameterDB(ACPResources.enddate, SqlDbType.Date, acpToInsert.endDate.ToString("yyyy-MM-dd"), false));
                parameters.Add(new ParameterDB(ACPResources.fk_employee, SqlDbType.Int, acpToInsert.administrator.id.ToString(), false));
                parameters.Add(new ParameterDB(ACPResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(ACPResources.CreateACPStoredProcedure, parameters);
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
        /// Metodo para agregar en la base de datos un nuevo ACP
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="costCenter">Centro de costo que se va a registrar</param>
        public int AddCostCenter (CostCenter costCenter)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(ACPResources.fk_ou, SqlDbType.Int, costCenter.fk_ou.ToString(), false));
                parameters.Add(new ParameterDB(ACPResources.fk_acp, SqlDbType.VarChar, costCenter.fk_acp, false));
                parameters.Add(new ParameterDB(ACPResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(ACPResources.CreateCostCenterStoredProcedure, parameters);
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
        /// Metodo que cambia el estatus de activo a eliminado en la base de datos
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="acpToDelete">Cuenta/Curso/Permiso que se va a eliminar</param>
        public int DeleteAccountCoursePermit(AccountCoursePermit acpToDelete)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(ACPResources.id, SqlDbType.VarChar, acpToDelete.id, false));
                ExecuteStoredProcedure(ACPResources.DeleteACPStoredProcedure, parameters);
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


        public List<AccountCoursePermit> GetAllAccountsCoursesPermits()
        {
            List<AccountCoursePermit> accountscoursespermitsList = new List<AccountCoursePermit>();
            DataTable dataTable = new DataTable();

            try
            {
                dataTable = ExecuteConsultStoredProcedure(ACPResources.GetAllACPStoredProcedure);
                AccountCoursePermit accountcoursepermit = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        Employee employee = new Employee(Int32.Parse(row["EID"].ToString()), row["EFIRSTNAME"].ToString(), row["ELASTNAME"].ToString());
                        accountcoursepermit = new AccountCoursePermit(row["ACPID"].ToString(),
                                                                      row["NAME"].ToString(),
                                                                      Int32.Parse(row["TYPE"].ToString()),
                                                                      Convert.ToDateTime(row["INITDATE"].ToString()),
                                                                      Convert.ToDateTime(row["ENDDATE"].ToString()),
                                                                      Int32.Parse(row["STATUS"].ToString()),
                                                                      employee);

                        accountscoursespermitsList.Add(accountcoursepermit);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return accountscoursespermitsList;
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