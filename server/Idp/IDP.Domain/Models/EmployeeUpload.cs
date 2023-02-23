using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Domain.Models
{
    public class EmployeeUpload
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string? File { get; set; }
    }
}
