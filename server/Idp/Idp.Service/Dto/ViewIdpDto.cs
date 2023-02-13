using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Dto
{
    public class ViewIdpDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime Year { get; set; }
    }
}
