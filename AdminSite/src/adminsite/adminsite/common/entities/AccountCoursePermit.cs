using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common.entities
{
    /// <summary>
    /// Objeto para almacenar la informacion de las cuentas cursos y permisos
    /// </summary>
    public class AccountCoursePermit
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public DateTime initDate { get; set; }
        public DateTime endDate { get; set; }
        public string status { get; set; }
        public Employee administrator { get; set; }
        public int error { get; set; }

        public AccountCoursePermit() { }
        public AccountCoursePermit(int id, string name, string type, DateTime initDate, DateTime endDate, string status, Employee administrator)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.initDate = initDate;
            this.endDate = endDate;
            this.status = status;
            this.administrator = administrator;
            this.error = 200;
        }
        public AccountCoursePermit(int id, string name, string type, DateTime initDate, DateTime endDate, string status)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.initDate = initDate;
            this.endDate = endDate;
            this.status = status;
            this.error = 200;
        }
        public AccountCoursePermit(int id)
        {
            this.id = id;
            this.error = 200;
        }
    }
}


