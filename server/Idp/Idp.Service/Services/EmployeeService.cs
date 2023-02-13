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
                })
                .ToListAsync();
        }

        //public async Task<List<ViewEmployeeDto>> UpdateAsync(int id, AddEmployeeDto dto)
        //{
        //    return await _db.Employees
        //        .Select(c => new ViewEmployeeDto
        //        {
        //            FirstName = dto.FirstName,
        //            LastName = dto.LastName,
        //            Mobile = dto.Mobile,
        //            Gender = dto.Gender,
        //            Age = dto.Age,
        //            Dob = dto.Dob,
        //        })
        //        .ToListAsync();
        //}

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
            };
        }

    }
}
