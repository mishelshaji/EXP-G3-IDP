using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string? Image { get; set; }
    }
}
