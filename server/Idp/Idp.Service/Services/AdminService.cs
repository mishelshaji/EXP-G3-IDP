using Idp.Service.Dto;
using Idp.Service.Migrations;
using IDP.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _db;

        public AdminService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<AdminViewDto>> GetAll()
        {
            var res = await _db.Objectives
                .Include(m => m.User)
                .Include(m=>m.Idp)
                    .ToListAsync();

            var item = res.Select(s => new AdminViewDto
            {
                FirstName = s.User.FirstName,
                LastName = s.User.LastName,
                Designation = s.User.Designation,
                Department = s.User.Department,
                IdpName = s.Idp.Name,
                ObjectiveName = s.Name
            }).ToList();
            return item;

        }
    }
}

