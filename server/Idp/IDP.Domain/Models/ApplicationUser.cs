using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Idp.Domain.Models
{
    [Index(nameof(EmployeeId), IsUnique = true)]

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }

        public string Gender { get; set; }

        public DateTime Dob { get; set; }

        [ForeignKey(nameof(Manager))]
        public int ManagerId { get; set; }
        public Manager? Manager { get; set; }

        public int EmployeeId { get; set; }
    }
}