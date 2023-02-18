using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Dto
{
    public class ObjectiveCreateDto
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public string Category { get; set; }

        public DateTime? StartDate { get; set; } 
    }
}
