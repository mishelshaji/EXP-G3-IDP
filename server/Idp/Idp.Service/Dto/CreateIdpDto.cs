using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idp.Service.Dto
{
    public class CreateIdpDto
    {
        public string Name { get; set; }

        public DateTime Year { get; set; }

        public int UserId { get; set; }
    }
}
