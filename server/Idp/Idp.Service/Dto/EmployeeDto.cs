using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Dto
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Designation { get; set; }

        public string Department { get; set; }

        public string EmployeeId { get; set; }

        public string ManagerEmployeeId { get; set; }

        public int ManagerId { get; set; }

        public string Role { get; set; }

        public DateTime Dob { get; set; }

        public string Gender { get; set; }
    }
}
