using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common
{
    /// <summary>
    /// Objeto para almacenar la informacion de los empleados
    /// </summary>
    public class Employee
    {
        public int id { get; set; }
        public string workerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int status { get; set; }
        public int idPosition { get; set; }
        public string positionName { get; set; }
        public int idOrganizationalUnit { get; set; }
        public string organizationalUnit { get; set; }
        public int error { get; set; }

        public Employee() { }

        public Employee(int id, string workerId, string firstName, string lastName, string email, string password,
                        int status, int idPosition, string positionName, int idOrganizationalUnit, string organizationalUnit)
        {
            this.id = id;
            this.workerId = workerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.status = status;
            this.idPosition = idPosition;
            this.positionName = positionName;
            this.idOrganizationalUnit = idOrganizationalUnit;
            this.organizationalUnit = organizationalUnit;
            this.error = 200;
        }

        public Employee(int id, string workerId, string firstName, string lastName, string email, string password,
                        int status, int idPosition, int idOrganizationalUnit)
        {
            this.id = id;
            this.workerId = workerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.status = status;
            this.idPosition = idPosition;
            this.idOrganizationalUnit = idOrganizationalUnit;
            this.error = 200;
        }

        public Employee(int id, string workerId, string firstName, string lastName, string email, string password, int status)
        {
            this.id = id;
            this.workerId = workerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.status = status;
            this.error = 200;
        }

        public Employee(int id, string workerId, string firstName, string lastName, string email, string password)
        {
            this.id = id;
            this.workerId = workerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.error = 200;
        }

        public Employee(string email, string password)
        {
            this.email = email;
            this.password = password;
            this.error = 200;
        }

        public Employee(string email)
        {
            this.email = email;
            this.error = 200;
        }

        public Employee(int id)
        {
            this.id = id;
            this.error = 200;
        }

        public Employee(int id, string workerId, string firstName, string lastName, string email, int status, int idPosition, 
                        string positionName, int idOrganizationalUnit, string organizationalUnit)
        {
            this.id = id;
            this.workerId = workerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.status = status;
            this.idPosition = idPosition;
            this.positionName = positionName;
            this.idOrganizationalUnit = idOrganizationalUnit;
            this.organizationalUnit = organizationalUnit;
            this.error = 200;
        }
    }
}