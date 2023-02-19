using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Domain.Models
{
    [Index(nameof(Name), IsUnique = true)]

    public class IdpPlan
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string? Name { get; set; }

        public DateTime Year { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public string ApplicationUserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
