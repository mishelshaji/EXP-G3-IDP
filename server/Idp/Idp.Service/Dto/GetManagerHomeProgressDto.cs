using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Dto
{
    public class GetManagerHomeProgressDto
    {
        public int TotalEmployee { get; set; }

        public int TotalCreatedIdp { get; set; }

        public int TotalPendingObjective { get; set; }

        public int TotalObjective { get; set; }
    }
}
