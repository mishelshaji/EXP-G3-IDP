using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Dto
{
    public class UpdateEmployeeDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Mobile { get; set; }
        
        public string? Gender { get; set; }
        
        public string? Dob { get; set; }
    }
}