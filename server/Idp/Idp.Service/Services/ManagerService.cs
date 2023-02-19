using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Services
{
    public class ManagerService
    {
        private readonly ApplicationDbContext _db;

        public ManagerService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ViewManagerDto>> GetAllAsync()
        {
            return await _db.Managers
                .Select(c => new ViewManagerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    EmployeeId = c.EmployeeId,
                })
                .ToListAsync();
        }

        public async Task<ViewManagerDto?> GetByIdAsync(int id)
        {
            var action = await _db.Managers.FindAsync(id);

            if (action == null)
                return null;

            action = await _db.Managers.FindAsync(id);
            return action == null ? null : new ViewManagerDto
            {
                Id = action.Id,
                Name = action.Name,
                EmployeeId = action.EmployeeId,
            };
        }

        public async Task<ViewManagerDto> CreateAsync(CreateManagerDto dto)
        {
            var action = new Manager
            {
                Name = dto.Name,
                EmployeeId = dto.EmployeeId,
            };

            _db.Managers.Add(action);
            await _db.SaveChangesAsync();

            return new ViewManagerDto
            {
                Id = action.Id,
                Name = dto.Name,
                EmployeeId = dto.EmployeeId,
            };
        }

    }
}


