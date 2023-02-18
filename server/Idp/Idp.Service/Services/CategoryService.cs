using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<CategoryViewDto>> GetAllAsync()
        {
            return await _db.Categories
                .Select(c => new CategoryViewDto
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<CategoryViewDto?> GetByIdAsync(int id)
        {
            Category? category = await _db.Categories.FindAsync(id);
            return category == null ? null : new CategoryViewDto
            {
                Id = category.Id,
                Name = category.Name,
                
            };
        }
    }
}
