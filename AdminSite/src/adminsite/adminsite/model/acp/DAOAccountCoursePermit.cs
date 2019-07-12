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
    }
}