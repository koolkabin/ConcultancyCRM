using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using ConcultancyCRM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ConcultancyCRM.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLoginEnabled { get; set; }
        public DateTime RegisteredDate { get; set; }

    }
    public class MyDBContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        private readonly IConfiguration _myAppSettingsConfig;
        public MyDBContext(IConfiguration configFromAppSettings)
        {
            _myAppSettingsConfig = configFromAppSettings;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Use the connection string from appsettings.json
                optionsBuilder.UseSqlServer(_myAppSettingsConfig.GetConnectionString("ABCDatabase"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
