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
                .Where(m => m.IdpId == id && m.Status == StatusType.pending)
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
                IdpId = dto.IdpId,
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
                IdpId = dto.IdpId,
            };
        }

        public async Task<List<ObjectiveProgressDto>> GetProgress(string userId, int year)
        {
            int idpId = _db.Idps.FirstOrDefault(m => m.Year == year).Id;

            var objectiveProgressList = new List<ObjectiveProgressDto>();

            var objectiveList = _db.Objectives
                .Include(m => m.Trainings)
                .Include(m => m.ObjectiveActions)
                .Where(m => m.IdpId == idpId)
                .Take(4)
                .ToList();
            foreach (var item in objectiveList)
            {
                var trainingPogress = item.Trainings.Sum(m => m.Progress);
                var actionPogress = item.Trainings.Sum(m => m.Progress);

                var training = item.Trainings.Count();
                var action = item.Trainings.Count();

                if (training + action != 0)
                {
                    objectiveProgressList.Add(new ObjectiveProgressDto
                    {
                        Name = item.Name,
                        Progress = (trainingPogress + actionPogress) / (training + action),
                    });
                }
            }

            return objectiveProgressList;
        }
    }
}