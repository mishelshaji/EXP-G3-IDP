﻿using CartSharp.Domain.Types;
using IDP.Domain.Models;
using IDP.Service.Data;
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
        private readonly ApplicationDBContext _db;

        public TrainingService(ApplicationDBContext db)
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
                    UserId = c.UserId,
                    IdpId = c.IdpId,
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
                UserId = dto.UserId,
                ObjectiveId = dto.ObjectiveId,
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
                UserId = Training.UserId,
                ObjectiveId = Training.ObjectiveId,
            };

        }
        public async Task<TrainingViewDto?> GetByIdAsync(int id)
        {
            Training? training = await _db.Trainings.FindAsync(id);
            return training == null ? null : new TrainingViewDto
            {
                Id = training.Id,
                Name = training.Name,
                Link= training.Link,
                Progress = training.Progress,
                StartDate = training.StartDate,
                EndDate = training.EndDate,
                UserId = training.UserId,
                ObjectiveId = training.ObjectiveId,

            };
        }

        public async Task<ServiceResponse<TrainingViewDto>?> UpdateAsync(int id, TrainingViewDto dto)
        {
            var response = new ServiceResponse<TrainingViewDto>();

            var category = await _db.Trainings.FindAsync(id);
            if (category == null)
                return null;

            if (await _db.Trainings.AnyAsync(m => m.Name == dto.Name))
            {
                response.AddError("Name", "A category with the same name already exists.");
            }

            if (!response.IsValid)
                return response;

            category.Name = dto.Name;
            category.Link = dto.Link;
            category.Progress = dto.Progress;
            category.StartDate = dto.StartDate;
            category.EndDate = dto.EndDate;
            category.UserId = dto.UserId;
            category.ObjectiveId = dto.ObjectiveId;
            await _db.SaveChangesAsync();

            response.Result = new TrainingViewDto
            {
                Id = category.Id,
                Name = category.Name,
                Link = category.Link,
                Progress = category.Progress,
                StartDate = category.StartDate,
                EndDate = category.EndDate,
                UserId = dto.UserId,
                ObjectiveId = dto.ObjectiveId,
            };
            return response;
        }

        public Task<TrainingViewDto> UpdateAsync(int id, TrainingCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}