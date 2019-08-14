using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common.entities
{
    public class Timesheet
    {
        public int id { get; set; }
        public DateTime initDate { get; set; }
        public DateTime endDate { get; set; }
        public string status { get; set; }
        public Employee employee { get; set; }
        //public List<Workload> workloads { get; set; }

        public Timesheet() { }

        public Timesheet(int id, DateTime initDate, DateTime endDate, string status, Employee employee)
        {
            this.id = id;
            this.initDate = initDate;
            this.endDate = endDate;
            this.status = status;
            this.employee = employee;
            //this.workload = new List<Workload>();
        }
    }
}