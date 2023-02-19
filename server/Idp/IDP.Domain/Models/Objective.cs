using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Domain.Models
{
    public class Objective
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string? Name { get; set; }

        public string? Category { get; set; }

        [ForeignKey(nameof(Idp))]

        public int IdpId { get; set; }

        public Idp Idp { get; set; }

        public bool Status { get; set; }

    }
}