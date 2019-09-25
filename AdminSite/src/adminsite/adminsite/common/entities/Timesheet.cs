using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common.entities
{
    public class Timesheet
    {
        public long id { get; set; }
        public DateTime initDate { get; set; }
        public DateTime endDate { get; set; }
        public string status { get; set; }
        public string comment { get; set; }
        public Employee employee { get; set; }
        public List<Workload> workloads { get; set; }

        public Timesheet() { }

        public Timesheet(long id, DateTime initDate, DateTime endDate, string status, Employee employee, string comment)
        {
            this.id = id;
            this.initDate = initDate;
            this.endDate = endDate;
            this.status = status;
            this.employee = employee;
            this.workloads = new List<Workload>();
            this.comment = comment;
        }

        public Timesheet(long id)
        {
            this.id = id;
        }
    }
}