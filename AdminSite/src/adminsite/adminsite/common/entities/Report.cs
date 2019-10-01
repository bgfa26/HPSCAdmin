using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common.entities
{
    public class Report
    {
        public int id { get; set; }
        public string workerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string organizationalUnit { get; set; }
        public string accounts { get; set; }
        public int error { get; set; }

        public Report() { }

        public Report(int id, string firstName, string lastName, string organizationalUnit)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.organizationalUnit = organizationalUnit;
            this.error = 200;
        }
    }
}