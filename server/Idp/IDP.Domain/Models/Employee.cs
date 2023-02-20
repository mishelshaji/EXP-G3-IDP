﻿using Microsoft.AspNetCore.Identity;

namespace Idp.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public string Department { get; set; }

        public string EmployeeId { get; set; }

        public string ManagerEmployeeId { get; set; }

        public int ManagerId { get; set; }

        public DateTime Dob { get; set; }
    }
}