using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_app.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeRoleId { get; set; }

        public string UserId { get; set; }
        
        public string Password { get; set; }
    }
}
