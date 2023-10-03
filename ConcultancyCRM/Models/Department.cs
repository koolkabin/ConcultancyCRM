using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace ConcultancyCRM.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedName { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedName { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
