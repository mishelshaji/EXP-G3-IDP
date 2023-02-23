using IDP.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Dto
{
    public class AdminViewDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Designation { get; set; }

        public string Department { get; set; }

        public string IdpName { get; set; }

        public string ObjectiveName { get; set; }
    }
}
