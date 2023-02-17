using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Services
{
    public class ObjectiveActionServices
    {
        private readonly ApplicationDbContext _db;

        public ObjectiveActionServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ViewActionDto>> GetAllAsync()
        {
            return await _db.ObjectiveActions
                .Select(c => new ViewActionDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    EndDate = c.EndDate,
                    StartDate = c.StartDate,
                    Progress = c.Progress,
                    Description = c.Certificate,
                })
                .ToListAsync();
        }

        public async Task<ViewActionDto?> GetByIdAsync(int id)
        {
            var action = await _db.ObjectiveActions.FindAsync(id);

            if (action == null)
                return null;

            action = await _db.ObjectiveActions.FindAsync(id);
            return action == null ? null : new ViewActionDto
            {
                Id = action.Id,
                Name = action.Name,
                EndDate = action.EndDate,
                StartDate = action.StartDate,
                Progress = action.Progress,
                Description = action.Certificate,
            };
        }

        public async Task<ViewActionDto> CreateAsync(AddActionDto dto)
        {
            var action = new ObjectiveAction
            {
                Name = dto.Name,
                Description = dto.Description,
                EndDate = dto.EndDate,
                StartDate = dto.StartDate,
                Progress = dto.Progress,
                Certificate = dto.Certificate,
            };

            _db.ObjectiveActions.Add(action);
            await _db.SaveChangesAsync();

            return new ViewActionDto
            {
                Id = action.Id,
                Name = dto.Name,
                Description = dto.Description,
                EndDate = dto.EndDate,
                StartDate = dto.StartDate,
                Progress = dto.Progress,
                Certificate = dto.Certificate,
            };
        }

    }
}


