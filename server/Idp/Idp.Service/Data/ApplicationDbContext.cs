using Idp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Idp.Service.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Seeding Roles
            var roles = new IdentityRole[]
            {
                new IdentityRole()
                {
                    Id = "e2a85572-7b8c-4a95-a862-c557c3b2e868",
                    ConcurrencyStamp = "e2a85572-7b8c-4a95-a862-c557c3b2e868",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Id = "e2a85572-7b8c-4a95-a862-c557c3b2e869",
                    ConcurrencyStamp = "e2a85572-7b8c-4a95-a862-c557c3b2e869",
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole()
                {
                    Id = "e2a85572-7b8c-4a95-a862-c557c3b2e870",
                    ConcurrencyStamp = "e2a85572-7b8c-4a95-a862-c557c3b2e870",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
            #endregion

            #region Seed admin User
            //var passwordHasher = new PasswordHasher<ApplicationUser>();
            //var user = new ApplicationUser
            //{
            //    Id = "e2a85572-7b8c-4a95-a862-c557c3b2e869",
            //    Email = "admin@mail.com",
            //    FirstName = "Admin",
            //    LastName = "User",
            //    EmailConfirmed = false,
            //    NormalizedEmail = "ADMIN@MAIL.COM",
            //    SecurityStamp = "e2a85572-7b8c-4a95-a862-c557c3b2e869",
            //    ConcurrencyStamp = "e2a85572-7b8c-4a95-a862-c557c3b2e869",
            //    UserName = "admin",
            //    NormalizedUserName = "Admin",
            //    LockoutEnabled = true,
            //    // Not a good practice. Set an empty password and ask admin to enter a password
            //    // when the user tries to login for the first time.
            //    //PasswordHash = "AQAAAAEAACcQAAAAEG09qLqexOh2KjF2ffM+XoY5wlk8jp+XYNpcJoxLCn9s1XUCtiNNu817MjrnYoR0yw=="
            //};
            //user.PasswordHash = passwordHasher.HashPassword(user, "Pass@123");
            //builder.Entity<ApplicationUser>().HasData(user);
            #endregion

        }

        public DbSet<ObjectiveAction> ObjectiveActions { get; set; }

        public DbSet<Objective> Objectives { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<IDP> Idps { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        
        public DbSet<Training> Trainings { get; set; }
    }
}