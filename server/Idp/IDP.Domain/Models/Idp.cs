using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Domain.Models
{
    public class IDP
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string? Name { get; set; }

        [ForeignKey(nameof(Year))]

        public int YearId { get; set; }

        public Year Year { get; set; }
    }
}
