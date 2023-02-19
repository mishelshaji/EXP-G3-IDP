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
                    Category = c.Category,
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
                Category = objective.Category,
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
                Category = dto.Category,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };

            _db.Objectives.Add(objective);
            await _db.SaveChangesAsync();

            return new ObjectiveViewDto
            {
                Id = objective.Id,
                Name = objective.Name,
                Status = objective.Status,
                Category = objective.Category,
                StartDate = objective.StartDate,
                EndDate = objective.EndDate
            };
        }
        
        }


    }


