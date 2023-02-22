using Idp.Domain.Models;
using Idp.Domain.Types;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Service.Services
{
    public class AccountsService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public AccountsService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signinManager,
            IConfiguration configuration,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            _configuration = configuration;
            _db = db;
        }

        public async Task<ServiceResponse<string>> LoginAsync(LoginDto dto)
        {
            var response = new ServiceResponse<string>();

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                response.AddError(nameof(dto.Email), "An account with this email does not exist.");
                return response;
            }

            var signin = await _signinManager.CheckPasswordSignInAsync(user, dto.Password, true);
            if (signin.Succeeded)
            {
                response.Result = GenerateToken(user);
                return response;
            }

            // If the signin failed, generate error messages.
            if (signin.IsLockedOut)
                response.AddError("", "Account locked.");
            else if (signin.IsNotAllowed)
                response.AddError("", "You are not allowed to signin.");
            else
                response.AddError("", "Invalid email/password.");

            return response;
        }

        public async Task<ProfileViewDto> GetProfileAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return new ProfileViewDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Department = user.Department,
                Designation = user.Designation,
                EmployeeId = user.EmployeeId,
                Dob = user.Dob,
                Gender = user.Gender,
            };
        }

        public async Task<List<ProfileViewDto>> GetManagerProfileAsync()
        {
            var managers = await _userManager.GetUsersInRoleAsync("Manager");
            var managerList = new List<ProfileViewDto>();
            foreach (var user in managers)
            {
                managerList.Add(new ProfileViewDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Department = user.Department,
                    Designation = user.Designation,
                    EmployeeId = user.EmployeeId,
                    Dob = user.Dob,
                    Gender = user.Gender,
                });
            }
            return managerList;
        }

        private string GenerateToken(ApplicationUser user)
        {
            var role = _userManager.GetRolesAsync(user)
            .GetAwaiter()
            .GetResult()
            .First();

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, role),
                new Claim("userrole", role)
            };

            string issuer = _configuration["Jwt:Issuer"];
            string audience = _configuration["Jwt:Audience"];
            string key = _configuration["Jwt:Key"];

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(signingKey, "HS256");

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
