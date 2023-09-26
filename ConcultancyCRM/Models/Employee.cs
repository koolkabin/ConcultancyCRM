using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConcultancyCRM.Models
{
    public class VMEmployeeCreate : Employee
    {
        public string Password { get; set; }
    }
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
        [UIHint("YesNo")]
        public bool Status { get; set; }
        public bool Deleted { get; set; }
        public DateTime JoinDate { get; set; }
        public string UserId { get; set; }
        [UIHint("YesNo")]
        public bool IsAdmin { get; set; }
        [UIHint("YesNo")]
        public bool IsSalesRepresentative { get; set; }
        public virtual ICollection<AssignedLeads> AssignedLeads { get; set; }
        public virtual AppUserEmployeeInfo AppUserEmployeeInfo { get; set; }
    }
}