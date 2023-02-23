using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Service.Dto
{
    public class EmailDto
    {
        public string fromAddress { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}
