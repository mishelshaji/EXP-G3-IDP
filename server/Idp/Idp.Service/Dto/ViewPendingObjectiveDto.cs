using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Dto
{
    public class ViewPendingObjectiveDto
    {
        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public string? Department { get; set; }

        public string? ObjectiveName { get; set; }

        public StatusType Remark { get; set; }
    }
}
