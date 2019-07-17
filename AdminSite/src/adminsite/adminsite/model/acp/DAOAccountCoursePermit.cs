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
            List<AccountCoursePermit> accountsCoursesPermitsList = new List<AccountCoursePermit>();
            DataTable dataTable = new DataTable();

            try
            {
                dataTable = ExecuteConsultStoredProcedure(ACPResources.GetAllACPStoredProcedure);
                AccountCoursePermit accountCoursePermit = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        string typeStringFormat = "No Facturable";
                        int typeNumeric = Int32.Parse(row["TYPE"].ToString());
                        if (typeNumeric == 1)
                        {
                            typeStringFormat = "Facturable";
                        }
                        Employee employee = new Employee(Int32.Parse(row["EID"].ToString()), row["EFIRSTNAME"].ToString(), row["ELASTNAME"].ToString());
                        accountCoursePermit = new AccountCoursePermit(row["ACPID"].ToString(),
                                                                      row["NAME"].ToString(),
                                                                      typeNumeric,
                                                                      typeStringFormat,
                                                                      Convert.ToDateTime(row["INITDATE"].ToString()),
                                                                      Convert.ToDateTime(row["ENDDATE"].ToString()),
                                                                      Int32.Parse(row["STATUS"].ToString()),
                                                                      employee);
                        List<CostCenter> costCenters = new List<CostCenter>();
                        OrganizationalUnit organizationalUnit = new OrganizationalUnit(Int32.Parse(row["OUID"].ToString()), row["OUNAME"].ToString());
                        CostCenter costCenter = new CostCenter(organizationalUnit, row["ACPID"].ToString());
                        accountCoursePermit.associatedUnits = costCenters;
                        bool existAcp = false;
                        AccountCoursePermit account = new AccountCoursePermit();
                        int position = 0;
                        int positionAcp = 0;
                        foreach (AccountCoursePermit acp in accountsCoursesPermitsList)
                        {
                            if (acp.id.Equals(accountCoursePermit.id))
                            {
                                acp.associatedUnits.Add(costCenter);
                                existAcp = true;
                                positionAcp = position;
                                account = acp;
                            }
                            position++;
                        }
                        if (existAcp)
                        {
                            accountsCoursesPermitsList[positionAcp] = account;
                        }
                        else
                        {
                            accountCoursePermit.associatedUnits.Add(costCenter);
                            accountsCoursesPermitsList.Add(accountCoursePermit);
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return accountsCoursesPermitsList;
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
        /// Metodo que elimina los centros de costo asociados a una cuenta de la base de datos
        /// </summary>
        /// <returns>Retorna un entero</returns>
        /// <param name="accountCoursePermit">Cuenta/Curso/Permiso del cual se eliminaran los centros de costo asociados</param>
        public int DeleteCostCenter(AccountCoursePermit accountCoursePermit)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(ACPResources.id, SqlDbType.VarChar, accountCoursePermit.id, false));
                ExecuteStoredProcedure(ACPResources.DeleteCostCenterStoredProcedure, parameters);
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


        public int UpdateAccountCoursePermit(AccountCoursePermit acpToModify)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();

            try
            {
                parameters.Add(new ParameterDB(ACPResources.id, SqlDbType.VarChar, acpToModify.id.ToString(), false));
                parameters.Add(new ParameterDB(ACPResources.name, SqlDbType.VarChar, acpToModify.name, false));
                parameters.Add(new ParameterDB(ACPResources.type, SqlDbType.Int, acpToModify.type.ToString(), false));
                parameters.Add(new ParameterDB(ACPResources.initdate, SqlDbType.Date, acpToModify.initDate.ToString("yyyy-MM-dd"), false));
                parameters.Add(new ParameterDB(ACPResources.enddate, SqlDbType.Date, acpToModify.endDate.ToString("yyyy-MM-dd"), false));
                parameters.Add(new ParameterDB(ACPResources.fk_employee, SqlDbType.Int, acpToModify.administrator.id.ToString(), false));
                parameters.Add(new ParameterDB(ACPResources.exitvalue, SqlDbType.Int, true));
                List<ResultDB> results = ExecuteStoredProcedure(ACPResources.UpdateAccountCoursePermitStoredProcedure, parameters);
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


        public AccountCoursePermit GetAccountCoursePermit(AccountCoursePermit acpToConsult)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();
            AccountCoursePermit accountCoursePermit = null;
            DataTable dataTable = new DataTable();

            try
            {
                parameters.Add(new ParameterDB(ACPResources.id, SqlDbType.VarChar, acpToConsult.id.ToString(), false));
                dataTable = ExecuteConsultStoredProcedure(ACPResources.GetAccountCoursePermitStoredProcedure, parameters);
                DataRow row = dataTable.Rows[0];
                string typeStringFormat = "No Facturable";
                int typeNumeric = Int32.Parse(row["TYPE"].ToString());
                if (typeNumeric == 1)
                {
                    typeStringFormat = "Facturable";
                }
                Employee employee = new Employee(Int32.Parse(row["EID"].ToString()), row["EFIRSTNAME"].ToString(), row["ELASTNAME"].ToString());
                accountCoursePermit = new AccountCoursePermit(row["ACPID"].ToString(),
                                                              row["NAME"].ToString(),
                                                              typeNumeric,
                                                              typeStringFormat,
                                                              Convert.ToDateTime(row["INITDATE"].ToString()),
                                                              Convert.ToDateTime(row["ENDDATE"].ToString()),
                                                              Int32.Parse(row["STATUS"].ToString()),
                                                              employee);
                List<CostCenter> costCenters = new List<CostCenter>();
                foreach (DataRow unitRow in dataTable.Rows)
                {
                    try
                    {
                        OrganizationalUnit organizationalUnit = new OrganizationalUnit(Int32.Parse(unitRow["OUID"].ToString()), unitRow["OUNAME"].ToString());
                        CostCenter costCenter = new CostCenter(organizationalUnit, unitRow["ACPID"].ToString());
                        costCenters.Add(costCenter);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                accountCoursePermit.associatedUnits = costCenters;
                return accountCoursePermit;
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