using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Dto
{
    public class CreateIdpDto
    {
        public string? Name { get; set; }

        public string? Year { get; set; }
    }
}
