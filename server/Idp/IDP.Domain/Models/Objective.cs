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
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int IdpId { get; set; }

        public int UserId { get; set; }

        public bool Status { get; set; }

    }
}
