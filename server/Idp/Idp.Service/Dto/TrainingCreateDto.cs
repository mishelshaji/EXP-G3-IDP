using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Service.Dto
{
    public class TrainingCreateDto
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int Progress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public int IdpId { get; set; }
        public int ObjectiveId { get; set; }
     
    }
}
