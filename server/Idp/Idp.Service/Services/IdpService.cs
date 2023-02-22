using idp.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idp.Service.Services
{
    public class IdpService
    {
        private readonly ApplicationDbContext _db;

        public IdpService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IdpViewDto> AddIdpAsync(CreateIdpDto dto, string userId)
        {
            var result = new IdpPlan
            {
                Name = dto.Name,
                Year = dto.Year,
                ApplicationUserId = userId
            };

            _db.Idps.Add(result);
            await _db.SaveChangesAsync();

            return new IdpViewDto
            {
                Id = result.Id,
                Name = result.Name,
                Year = result.Year,
                UserId = result.ApplicationUserId
            };
        }

        public async Task<List<IdpViewDto>> GetIdpAsync(string userId)
        {
            var res = await _db.Idps.ToListAsync();
            return res.Where(m => m.ApplicationUserId == userId).Select(c => new IdpViewDto
            {
                Id = c.Id,
                Name = c.Name,
                Year = c.Year,
                UserId = c.ApplicationUserId
            }).ToList();
        }

        public async Task<List<IdpViewDto?>> GetByIdAsync(string userId)
        {
            var res = await _db.Idps.ToListAsync();
            return res.Where(m => m.ApplicationUserId == userId).Select(c => new IdpViewDto
            {
                Id = c.Id,
                Name = c.Name,
                Year = c.Year,
                UserId = c.ApplicationUserId
            }).ToList();
        }
    }
}
