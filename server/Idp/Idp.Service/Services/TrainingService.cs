using IDP.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Service.Services
{
    public class TrainingService
    {
        private readonly ApplicationDbContext _db;

        public TrainingService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<TrainingViewDto>> GetAllAsync()
        {
            return await _db.Trainings
                .Select(c => new TrainingViewDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Link = c.Link,
                    Progress = c.Progress,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    ObjectiveId = c.ObjectiveId,
                    Description = c.Description,
                }).ToListAsync();
        }

        public async Task<List<TrainingViewDto>> GetByObjectiveAsync(int id)
        {
            return await _db.Trainings
                .Where(m => m.ObjectiveId == id)
                .Select(c => new TrainingViewDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Link = c.Link,
                    Progress = c.Progress,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    ObjectiveId = c.ObjectiveId,
                }).ToListAsync();
        }

        public async Task<TrainingViewDto> CreateAsync(TrainingCreateDto dto)
        {
            var Training = new Training
            {
                Name = dto.Name,
                Link = dto.Link,
                Progress = dto.Progress,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                ObjectiveId = dto.ObjectiveId,
                Description = dto.Description
            };
            _db.Trainings.Add(Training);
            await _db.SaveChangesAsync();
            return new TrainingViewDto
            {
                Id = Training.Id,
                Name = Training.Name,
                Link = Training.Link,
                Progress = Training.Progress,
                StartDate = Training.StartDate,
                EndDate = Training.EndDate,
                ObjectiveId = Training.ObjectiveId,
                Description = Training.Description
            };

        }

        public async Task<TrainingViewDto?> GetByIdAsync(int id)
        {
            Training? training = await _db.Trainings.FindAsync(id);
            return training == null ? null : new TrainingViewDto
            {
                Id = training.Id,
                Name = training.Name,
                Link = training.Link,
                Progress = training.Progress,
                StartDate = training.StartDate,
                EndDate = training.EndDate,
                ObjectiveId = training.ObjectiveId,
                Description = training.Description
            };
        }

        public async Task<ServiceResponse<TrainingViewDto>?> UpdateAsync(int id, TrainingUpdateDto dto)
        {
            var response = new ServiceResponse<TrainingViewDto>();

            var category = await _db.Trainings.FindAsync(id);
            if (category == null)
                return null;

            if (!response.IsValid)
                return response;

            category.Progress = dto.Progress;
            await _db.SaveChangesAsync();

            response.Result = new TrainingViewDto
            {
                Id = category.Id,
                Name = category.Name,
                Link = category.Link,
                Progress = category.Progress,
                StartDate = category.StartDate,
                EndDate = category.EndDate,
            };
            return response;
        }
    }
}
