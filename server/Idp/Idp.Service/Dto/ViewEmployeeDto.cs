﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Dto
{
    public class ViewEmployeeDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }

        public string? Department { get; set; }

        public string? Designation { get; set; }

        public int EmployeeId { get; set; }

        public string? Gender { get; set; }

        public int Age { get; set; }

        public string? Dob { get; set; }

        public string? ManagerName { get; set; }

        public string? Role { get; set; }
    }
}
