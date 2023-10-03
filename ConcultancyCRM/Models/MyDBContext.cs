using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using ConcultancyCRM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ConcultancyCRM.Models
{
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

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeadInfo> LeadInfo { get; set; }
        public DbSet<AssignedLeads> AssignedLeads { get; set; }
        public DbSet<LeadStatus> LeadStatus { get; set; }
        public DbSet<LeadComments> LeadComments { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<EmployeeHRDetail> EmployeeHRDetails { get; set; }
        public DbSet<AppUserEmployeeInfo> AppUserEmployees { get; set; }
        public DbSet<AssetsCategory> AssestCategories { get; set; } 
        public DbSet<Assets> Assets { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
