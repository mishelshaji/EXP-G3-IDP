using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Domain.Models
{
    public class ObjectiveAction
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Certificate { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Progress { get; set; }

        [ForeignKey(nameof(ObjId))]
        public int ObjId { get; set; }
        public Objective? Obj { get; set; }
    }
}