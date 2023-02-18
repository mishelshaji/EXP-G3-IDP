using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Domain.Models
{
    public class Training
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Link { get; set; }

        public int Progress { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(Idp))]

        public int IdpId { get; set; }

        public Idp Idp { get; set; }

        [ForeignKey(nameof(Objective))]

        public int ObjectiveId { get; set; }

        public Objective Objective { get; set; }
    }
}