using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Service
{
    public class ObjectiveService
    {
        private readonly ApplicationDbContext _db;

        public ObjectiveService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ObjectiveViewDto>> GetByIdpAsync(int id)
        {
            return await _db.Objectives
                .Include(m => m.Category)
                .Where(m => m.IdpId == id)
                .Select(c => new ObjectiveViewDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Status = c.Status,
                    IdpId= c.IdpId,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Category = new() 
                    { 
                        Name = c.Category.Name
                    }
                })
                .ToListAsync();
        }

        public async Task<ObjectiveViewDto?> GetByIdAsync(int id)
        {
            Objective? objective = await _db.Objectives.FindAsync(id);
            return objective == null ? null : new ObjectiveViewDto
            {
                Id = objective.Id,
                Name = objective.Name,
                Status = objective.Status,
                StartDate = objective.StartDate,
                EndDate = objective.EndDate
            };
        }

        public async Task<List<ObjectiveViewDto>> GetByPendingAsync(int id)
        {
            return await _db.Objectives
                .Include(m => m.Category)
                .Where(m => m.IdpId == id && m.Status == false)
                .Select(c => new ObjectiveViewDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Status = c.Status,
                    IdpId = c.IdpId,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    Category = new()
                    {
                        Name = c.Category.Name
                    }
                })
                .ToListAsync();
        }

        public async Task<ObjectiveViewDto> CreateAsync(ObjectiveCreateDto dto, string userId)
        {
            var objective = new Objective
            {
                Name = dto.Name,
                Status = dto.Status,
                CategoryId = dto.CategoryId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IdpId= dto.IdpId,
                UserId = userId,
            };

            _db.Objectives.Add(objective);
            await _db.SaveChangesAsync();

            return new ObjectiveViewDto
            {
                Id = objective.Id,
                Name = objective.Name,
                Status = objective.Status,
                StartDate = objective.StartDate,
                EndDate = objective.EndDate,
                IdpId= dto.IdpId,
            };
        }
    }
}