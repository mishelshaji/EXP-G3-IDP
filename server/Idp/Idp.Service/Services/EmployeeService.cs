using CsvHelper;
using Idp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly IConfiguration _configuration;

        private readonly ApplicationDbContext _db;

        private readonly IHostingEnvironment _webHost;

        public EmployeeService(
        ApplicationDbContext db,
        IHostingEnvironment webHost,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        SignInManager<ApplicationUser> signinManager,
        IConfiguration configuration)
        {
            _db = db;
            _webHost = webHost;
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            _configuration = configuration;
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
                Id = employees.Id,
                
            };

            var reader = new StreamReader(uploadsDir);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var allEmployees = csv.GetRecords<EmployeeDto>().ToList();

            var managers = allEmployees.Where(m => m.Role == "Manager").ToList();

            var others = allEmployees.Where(m => m.Role == "Employee").ToList();

            var registeredManagers = new List<ApplicationUser>();
            foreach (var item in managers)
            {
                var user = new ApplicationUser()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    NormalizedEmail = item.Email.ToUpper(),
                    PhoneNumber = item.Phone,
                    Department = item.Department,
                    Gender = item.Gender,
                    Designation = item.Designation,
                    Dob = item.Dob,
                    EmployeeId = item.EmployeeId,
                    UserName = item.EmployeeId,
                    NormalizedUserName = item.EmployeeId.ToUpper(),
                };

                var hasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = hasher.HashPassword(user, "Pass@123");
                await _db.Users.AddAsync(user);
                registeredManagers.Add(user);
            }
            await _db.SaveChangesAsync();

            foreach (var manager in registeredManagers)
            {
                await _userManager.AddToRoleAsync(manager, "Manager");
            }

            // Add users.
            foreach (var item in others)
            {
                var user = new ApplicationUser()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    NormalizedEmail = item.Email.ToUpper(),
                    PhoneNumber = item.Phone,
                    Department = item.Department,
                    Gender = item.Gender,
                    Designation = item.Designation,
                    Dob = item.Dob,
                    EmployeeId = item.EmployeeId,
                    UserName = item.EmployeeId,
                    NormalizedUserName = item.EmployeeId.ToUpper(),
                    ManagerId = registeredManagers.FirstOrDefault(m => m.EmployeeId == item.ManagerEmployeeId).Id
                };

                var hasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = hasher.HashPassword(user, "Pass@123");
                await _db.Users.AddAsync(user);
                registeredManagers.Add(user);
            }
            await _db.SaveChangesAsync();

            foreach (var user in registeredManagers)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result;
        }
    }
}
