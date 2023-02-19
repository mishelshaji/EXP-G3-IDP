using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Dto
{
     public class ObjectiveViewDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public string Category { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set;}
    }
}
