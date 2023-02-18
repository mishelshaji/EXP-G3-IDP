using IDP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Service.Dto
{
    public class TrainingViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int Progress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public int IdpId { get; set; }
        public int ObjectiveId { get; set; }
        public TrainingViewDto()
        {

        }
        public TrainingViewDto(Training training)
        {
            Id = training.Id;
            Name = training.Name;
            Link = training.Link;
            Progress = training.Progress;
            StartDate = training.StartDate;
            EndDate = training.EndDate;
            UserId = training.UserId;
            IdpId = training.IdpId;
            ObjectiveId = training.ObjectiveId;

        }
    }
}


