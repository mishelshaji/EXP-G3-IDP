using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Services
{
    public class EmployeeServices
    {
        private readonly ApplicationDbContext _db;

        public EmployeeServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ViewEmployeeDto>> GetAllAsync()
        {
            return await _db.Employees
                .Select(c => new ViewEmployeeDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Age = c.Age,
                    Dob = c.Dob,
                    Email = c.Email,
                    Mobile = c.Mobile,
                    Department = c.Department,
                    Designation = c.Designation,
                    EmployeeId = c.EmployeeId,
                    Gender = c.Gender,
                    Role = c.Role,
                })
                .ToListAsync();
        }

        public async Task<ViewEmployeeDto?> GetByIdAsync(int id)
        {
            // Check if the employee exists.
            var employee = await _db.Employees.FindAsync(id);

            if (employee == null)
                return null;

            employee = await _db.Employees.FindAsync(id);
            return employee == null ? null : new ViewEmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age,
                Dob = employee.Dob,
                Email = employee.Email,
                Mobile = employee.Mobile,
                Department = employee.Department,
                Designation = employee.Designation,
                EmployeeId = employee.EmployeeId,
                Gender = employee.Gender,
                Role = employee.Role,
            };
        }

        public async Task<ServiceResponse<ViewEmployeeDto>?> UpdateAsync(int id, UpdateEmployeeDto dto)
        {
            var response = new ServiceResponse<ViewEmployeeDto>();

            // Check if the employee exists.
            var employee = await _db.Employees.FindAsync(id);
            if (employee == null)
                return null;

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Dob = dto.Dob;
            employee.Mobile = dto.Mobile;

            await _db.SaveChangesAsync();

            response.Result = new ViewEmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Dob = employee.Dob,
                Mobile = employee.Mobile,
            };
            return response;
        }

        public async Task<ViewEmployeeDto> CreateAsync(AddEmployeeDto dto)
        {
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Mobile = dto.Mobile,
                Department = dto.Department,
                Designation = dto.Designation,
                EmployeeId = dto.EmployeeId,
                Gender = dto.Gender,
                Age = dto.Age,
                Dob = dto.Dob,
                Role = dto.Role,
                ManagerId = dto.ManagerId
            };

            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();

            return new ViewEmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Mobile = employee.Mobile,
                Department = employee.Department,
                Designation = employee.Designation,
                EmployeeId = employee.EmployeeId,
                Gender = employee.Gender,
                Age = employee.Age,
                Dob = employee.Dob,
                Role = employee.Role,
            };
        }

    }
}
