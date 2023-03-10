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

        public StatusType Status { get; set; }

        public int CategoryId { get; set; }

        public int IdpId { get; set; }

        public DateTime? StartDate { get; set; } 

        public DateTime? EndDate { get; set;}

        public string? UserId { get; set; }
    }
}
