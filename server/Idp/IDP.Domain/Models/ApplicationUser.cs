using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Domain.Models
{
    internal class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }

        public DateTime Dob { get; set; }

        public int ManagerId { get; set; }

        public Manager Manager { get; set; }

        public int EmployeeId { get; set; }