using CsvHelper;
using Idp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
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
            var allowedFileExtensions = new[] { ".csv" };

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

            var employees = new EmployeeUpload()
            {
                Image = Path.Combine(uniqueFileName)
            };
            _db.EmployeesUpload.Add(employees);
            await _db.SaveChangesAsync();

            result.Result = new()
            {
                Id = employees.Id
            };

            var reader = new StreamReader(uploadsDir);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var employeesFile = csv.GetRecords<EmployeeDto>();

            var employeesList = new Employee();

            //foreach (var employee in employeesFile)
            //{
            //   employeesList = new Employee
            //   {
            //       Name = employee.Name,
            //       //Email= employee.Email,
            //       Department = employee.Department,
            //       Designation = employee.Designation,
            //       Dob= employee.Dob,
            //       //Phone= employee.Phone,
            //       EmployeeId= employee.EmployeeId,
            //       ManagerEmployeeId= employee.ManagerEmployeeId,
            //       ManagerId = employee.ManagerId,

            //   }
            //}

            return result;
        }
    }
}
