using Microsoft.AspNetCore.Hosting;
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

        private readonly IHostingEnvironment _webHost;

        public ObjectiveActionServices(
        ApplicationDbContext db,
        IHostingEnvironment webHost)
        {
            _db = db;
            _webHost = webHost;
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
                    Description = c.Certificate
                })
                .ToListAsync();
        }
        public async Task<List<ViewActionDto>> GetByObjectiveAsync(int id)
        {
            return await _db.ObjectiveActions
                .Where(m => m.ObjId == id)
                .Select(c => new ViewActionDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    EndDate = c.EndDate,
                    StartDate = c.StartDate,
                    Progress = c.Progress,
                    Description = c.Certificate,
                    ObjectiveId = c.ObjId
                })
                .ToListAsync();
        }

        public async Task<ServiceResponse<ViewActionDto>> CreateAsync(AddActionDto dto)
        {

            var result = new ServiceResponse<ViewActionDto>();

            // Saving File to disk.
            string fileNameByUser = dto.Certificate.FileName;
            string fileExtension = Path.GetExtension(fileNameByUser).ToLower();
            var allowedFileExtensions = new[] { ".pdf" };

            if (!allowedFileExtensions.Contains(fileExtension))
            {
                result.AddError(nameof(dto.Certificate), "Invalid file type.");
                return result;
            }

            string staticFileDirs = _webHost.WebRootPath;
            string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            string uploadsDir = Path.Join(staticFileDirs, "uploads", uniqueFileName);

            using (var fileStream = new FileStream(uploadsDir, FileMode.Create))
            {
                await dto.Certificate.CopyToAsync(fileStream);
            }

            var action = new ObjectiveAction
            {
                Name = dto.Name,
                Description = dto.Description,
                EndDate = dto.EndDate,
                StartDate = dto.StartDate,
                Progress = dto.Progress,
                Certificate = Path.Combine(uniqueFileName),
                ObjId = dto.ObjectiveId
            };

            _db.ObjectiveActions.Add(action);
            await _db.SaveChangesAsync();

            result.Result = new ViewActionDto
            {
                Id = action.Id,
                Name = dto.Name,
                Description = dto.Description,
                EndDate = dto.EndDate,
                StartDate = dto.StartDate,
                Progress = dto.Progress,
                Certificate = Path.Combine(uniqueFileName),
                ObjectiveId = dto.ObjectiveId,
            };

            return result;
        }

    }
}


