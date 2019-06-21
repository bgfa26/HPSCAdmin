using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common
{
    public class Employee
    {
        public int id { get; set; }
        public string workerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}