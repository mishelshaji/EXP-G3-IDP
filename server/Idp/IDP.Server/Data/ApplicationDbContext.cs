using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Data
{
    internal class ApplicationDbContext : DbContext
    {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        
        }
        
        //public DbSet<Employee> Categories { get; set; }
    }
}
