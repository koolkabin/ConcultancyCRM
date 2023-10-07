using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcultancyCRM.Models
{
    public class VMEmployeeCreate : Employee
    {
        public string Password { get; set; }
    }
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(255)]
        public string Mobile { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [UIHint("ActiveInActive")]
        public bool Status { get; set; }
        [UIHint("YesNo")]
        public bool Deleted { get; set; }
        public DateTime JoinDate { get; set; }
        public string UserId { get; set; }
        [UIHint("YesNo")]
        public bool IsAdmin { get; set; }
        [UIHint("YesNo")]
        public bool IsSalesRepresentative { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<AssignedLeads> AssignedLeads { get; set; }
        public virtual ICollection<AssetsItemsAssigned> AssetsItemsAssigned { get; set; }
        public virtual ICollection<LeadComments> LeadComments { get; set; }
        public virtual AppUserEmployeeInfo AppUserEmployeeInfo { get; set; }
    }
}