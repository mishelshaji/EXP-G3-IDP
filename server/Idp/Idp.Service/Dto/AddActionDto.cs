using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Dto
{
    public class AddActionDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set;}

        public int Progress { get; set; }

        public string? Certificate { get; set; }

    }
}
