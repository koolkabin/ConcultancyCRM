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
        public DateTime CreatedDate { get; set; }
        public String CreatedName { get; set; }
        public DateTime UpdatedDate { get; set; }
        public String UpdatedName { get; set; }
        public virtual ICollection<AssetsItemsAssigned> AssestsItemsAssigned { get; set; }
    }
}
