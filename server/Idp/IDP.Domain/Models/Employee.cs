using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Domain.Models
{
    internal class Employee
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Department { get; set; }

        [StringLength(150)]
        public string Designation { get; set; }

        public int EmployeeId { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public DateTime Dob { get; set; }

        public int ManagerId { get; set; }

        public string Role { get; set; }
    }
}
