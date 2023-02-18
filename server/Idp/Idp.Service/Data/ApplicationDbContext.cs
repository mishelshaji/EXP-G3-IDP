using Idp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<ObjectiveAction> ObjectiveActions { get; set; }
        public DbSet<IDP> Idps { get; set; }

    }
}
