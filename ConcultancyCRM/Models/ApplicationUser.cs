using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcultancyCRM.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLoginEnabled { get; set; }
        public DateTime RegisteredDate { get; set; }
        public enumUserType UserType { get; set; }
        public virtual AppUserEmployeeInfo AppUserEmployeeInfo { get; set; }

    }
    public class AppUserEmployeeInfo
    {
        [ForeignKey("ApplicationUser")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
