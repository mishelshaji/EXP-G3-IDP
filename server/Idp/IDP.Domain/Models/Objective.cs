using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Domain.Models
{
    public class Objective
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string? Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(Idp))]
        public int IdpId { get; set; }
        public IdpPlan Idp { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(UserId))]
        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }

        public StatusType Status { get; set; }

        public IEnumerable<Training> Trainings { get; set; }

        public IEnumerable<ObjectiveAction> ObjectiveActions { get; set; }
    }
}