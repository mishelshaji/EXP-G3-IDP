using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Domain.Models
{
    [Index(nameof(EmployeeId), IsUnique = true)]

    public class Manager
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int EmployeeId { get; set; }
    }
}
