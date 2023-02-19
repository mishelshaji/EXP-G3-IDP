using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Dto
{
    public class CreateManagerDto
    {
        public string? Name { get; set; }

        public int EmployeeId { get; set; }
    }
}
