using adminsite.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace adminsite.model.usermanagement
{
    public class DAOUserManagement : DAO
    {
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
                                                row["STATUS"].ToString(),
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
    }
}