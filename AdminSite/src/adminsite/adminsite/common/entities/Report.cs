using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common.entities
{
    public class Report : IEquatable<Report>
    {
        public int id { get; set; }
        public string workerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string unitAccount { get; set; }
        public int error { get; set; }

        public Report() { }

        public Report(int id, string firstName, string lastName, string unitAccount)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.unitAccount = unitAccount;
            this.error = 200;
        }

        public bool Equals(Report other)
        {
            return this.id.Equals(other.id);
        }
    }
}