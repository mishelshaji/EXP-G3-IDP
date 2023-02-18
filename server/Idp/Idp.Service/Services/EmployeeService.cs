using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Services
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _db;

        private readonly IHostingEnvironment _webHost;

        public EmployeeService(
        ApplicationDbContext db,
        IHostingEnvironment webHost)
        {
            _db = db;
            _webHost = webHost;
        }

        public async Task<ServiceResponse<EmployeeViewDto>> CreateAsync(EmployeeUploadDto dto)
        {
            var result = new ServiceResponse<EmployeeViewDto>();

            // Saving employees image to disk.
            string fileNameByUser = dto.Image.FileName;
            string fileExtension = Path.GetExtension(fileNameByUser).ToLower();
            var allowedFileExtensions = new[] { ".jpg", ".jpeg", ".png" };

            if (!allowedFileExtensions.Contains(fileExtension))
            {
                result.AddError(nameof(dto.Image), "Invalid file type.");
                return result;
            }

            string staticFileDirs = _webHost.WebRootPath;
            string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            string uploadsDir = Path.Join(staticFileDirs, "uploads", uniqueFileName);

            using (var fileStream = new FileStream(uploadsDir, FileMode.Create))
            {
                await dto.Image.CopyToAsync(fileStream);
            }

            var employees = new Employee()
            {
                Image = Path.Combine(uniqueFileName)
            };
            _db.Employees.Add(employees);
            await _db.SaveChangesAsync();

            result.Result = new()
            {
                Id = employees.Id
            };
            return result;
        }
    }
}
