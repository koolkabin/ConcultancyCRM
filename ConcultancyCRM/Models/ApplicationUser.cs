using Microsoft.AspNetCore.Identity;

namespace ConcultancyCRM.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLoginEnabled { get; set; }
        public DateTime RegisteredDate { get; set; }
        public enumUserType UserType { get; set; }
        public int? RelatedId { get; set; }

    }
}
