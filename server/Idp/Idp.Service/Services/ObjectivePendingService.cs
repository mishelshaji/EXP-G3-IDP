using idp.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idp.Service.Services
{
    public class ObjectivePendingService
    {
        private readonly ApplicationDbContext _db;

        public ObjectivePendingService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ViewPendingObjectiveDto> GetAll(string managerId)
        {
            var res = _db.Objectives.Include(m => m.Idp)
            .Include(m => m.User).Where(m => m.User.ManagerId == managerId)
            .Select(c => new ViewPendingObjectiveDto
            {
                UserId = c.User.Id,
                UserName = c.User.FirstName + " " + c.User.LastName,
                Department = c.User.Department,
                IdpName = c.Idp.Name,
                ObjectiveName = c.Name,
                Remark = c.Status
            }).ToList();
            return res;
        }
    }
}
