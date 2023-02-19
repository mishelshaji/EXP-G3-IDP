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

        public async Task<List<ObjectiveViewDto>> GetAllAsync()
        {
            return await _db.Objectives
                .Select(c => new ObjectiveViewDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Status = c.Status,
                    CategoryId = c.CategoryId,
                    IdpId= c.IdpId,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate
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
                CategoryId = objective.CategoryId,
                StartDate = objective.StartDate,
                EndDate = objective.EndDate
            };
        }
        public async Task<ObjectiveViewDto> CreateAsync(ObjectiveCreateDto dto)
        {
            var objective = new Objective
            {
                Name = dto.Name,
                Status = dto.Status,
                CategoryId = dto.CategoryId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IdpId= dto.IdpId,
            };

            _db.Objectives.Add(objective);
            await _db.SaveChangesAsync();

            return new ObjectiveViewDto
            {
                Id = objective.Id,
                Name = objective.Name,
                Status = objective.Status,
                CategoryId = objective.CategoryId,
                StartDate = objective.StartDate,
                EndDate = objective.EndDate,
                IdpId= dto.IdpId,
            };
        }
    }
}