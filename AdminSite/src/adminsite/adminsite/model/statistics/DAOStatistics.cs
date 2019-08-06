using adminsite.common;
using adminsite.common.entities;
using adminsite.model.usermanagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace adminsite.model.statistics
{
    /// <summary>
    /// Clase que hereda de la clase abstracta DAO usada para obtener los datos estadísticos de la empresa
    /// </summary>
    public class DAOStatistics : DAO
    {
        private int TotalHoursPerRow(DataRow row)
        {
            int day1 = Int32.Parse(row["DAY1"].ToString());
            int day2 = Int32.Parse(row["DAY2"].ToString());
            int day3 = Int32.Parse(row["DAY3"].ToString());
            int day4 = Int32.Parse(row["DAY4"].ToString());
            int day5 = Int32.Parse(row["DAY5"].ToString());
            int day6 = Int32.Parse(row["DAY6"].ToString());
            int day7 = Int32.Parse(row["DAY7"].ToString());
            int day8 = Int32.Parse(row["DAY8"].ToString());
            int day9 = Int32.Parse(row["DAY9"].ToString());
            int day10 = Int32.Parse(row["DAY10"].ToString());
            int day11 = Int32.Parse(row["DAY11"].ToString());
            int day12 = Int32.Parse(row["DAY12"].ToString());
            int day13 = Int32.Parse(row["DAY13"].ToString());
            int day14 = Int32.Parse(row["DAY14"].ToString());
            int day15 = Int32.Parse(row["DAY15"].ToString());
            int day16 = Int32.Parse(row["DAY16"].ToString());
            return day1 + day2 + day3 + day4 + day5 + day6 + day7 + day8 + day9 + day10 + day11 + day12 + day13 + day14 + day15 + day16;
        }

        public List<Statistic> GetTotalHoursPerMonth(int year)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();
            List<Statistic> statistics = new List<Statistic>();
            Statistic january = new Statistic("2019-01", 0);
            Statistic february = new Statistic("2019-02", 0);
            Statistic march = new Statistic("2019-03", 0);
            Statistic april = new Statistic("2019-04", 0);
            Statistic may = new Statistic("2019-05", 0);
            Statistic june = new Statistic("2019-06", 0);
            Statistic july = new Statistic("2019-07", 0);
            Statistic august = new Statistic("2019-08", 0);
            Statistic september = new Statistic("2019-09", 0);
            Statistic october = new Statistic("2019-10", 0);
            Statistic november = new Statistic("2019-11", 0);
            Statistic december = new Statistic("2019-12", 0);
            DataTable dataTable = new DataTable();

            try
            {
                parameters.Add(new ParameterDB(StatisticsResources.year, SqlDbType.Int, year.ToString(), false));
                dataTable = ExecuteConsultStoredProcedure(StatisticsResources.GetTotalHoursPerMonthStoredProcedure, parameters);
                OrganizationalUnit unit = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        string date = row["INITDATE"].ToString();
                        int totalHours = TotalHoursPerRow(row);
                        DateTime initDate = Convert.ToDateTime(date);
                        if (initDate.Month == 1)
                        {
                            january.value += totalHours;
                        }
                        else if (initDate.Month == 2)
                        {
                            february.value += totalHours;
                        }
                        else if (initDate.Month == 3)
                        {
                            march.value += totalHours;
                        }
                        else if (initDate.Month == 4)
                        {
                            april.value += totalHours;
                        }
                        else if (initDate.Month == 5)
                        {
                            may.value += totalHours;
                        }
                        else if (initDate.Month == 6)
                        {
                            june.value += totalHours;
                        }
                        else if (initDate.Month == 7)
                        {
                            july.value += totalHours;
                        }
                        else if (initDate.Month == 8)
                        {
                            august.value += totalHours;
                        }
                        else if (initDate.Month == 9)
                        {
                            september.value += totalHours;
                        }
                        else if (initDate.Month == 10)
                        {
                            october.value += totalHours;
                        }
                        else if (initDate.Month == 11)
                        {
                            november.value += totalHours;
                        }
                        else if (initDate.Month == 12)
                        {
                            december.value += totalHours;
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
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

            statistics.Add(january);
            statistics.Add(february);
            statistics.Add(march);
            statistics.Add(april);
            statistics.Add(may);
            statistics.Add(june);
            statistics.Add(july);
            statistics.Add(august);
            statistics.Add(september);
            statistics.Add(october);
            statistics.Add(november);
            statistics.Add(december);
            return statistics;
        }

        public List<Statistic> GetTotalHoursPerOrganizationalUnit(int month, int year)
        {
            List<ParameterDB> parameters = new List<ParameterDB>();
            List<Statistic> statistics = new List<Statistic>();
            DataTable dataTable = new DataTable();

            try
            {
                parameters.Add(new ParameterDB(StatisticsResources.month, SqlDbType.Int, month.ToString(), false));
                parameters.Add(new ParameterDB(StatisticsResources.year, SqlDbType.Int, year.ToString(), false));
                dataTable = ExecuteConsultStoredProcedure(StatisticsResources.GetHoursPerOUStoredProcedure, parameters);
                OrganizationalUnit unit = null;
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        string ou  = row["OUNAME"].ToString();
                        int totalHours = TotalHoursPerRow(row);
                        Statistic organizationalUnit = new Statistic(ou, totalHours);
                        bool contain = statistics.Contains(organizationalUnit);
                        if (contain)
                        {
                            foreach (Statistic statistic in statistics)
                            {
                                if (statistic.title.Equals(organizationalUnit.title))
                                {
                                    statistic.value += organizationalUnit.value;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            statistics.Add(organizationalUnit);
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
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
            return statistics;
        }
    }
}