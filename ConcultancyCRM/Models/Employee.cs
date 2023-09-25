﻿using System.ComponentModel.DataAnnotations;

namespace ConcultancyCRM.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(255)]
        public string Mobile { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
        public DateTime JoinDate { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSalesRepresentative { get; set; }
    }
    public class AssignedLeads
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LeadInfoId { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<LeadInfo> LeadInfo { get; set; }
    }
}