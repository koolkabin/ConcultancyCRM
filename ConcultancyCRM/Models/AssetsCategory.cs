using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcultancyCRM.Models
{
    public class AssetsCategory
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [UIHint("ActiveInActive")]
        public bool Status { get; set; }
        [UIHint("YesNo")]
        public bool Deleted { get; set; }
        public DateTime CreatedBy { get; set; } = DateTime.Now;
        public DateTime CreatedName { get; set; }
        [NotMapped]
        public DateTime UpdatedDate { get; set; }
        [NotMapped] 
        public String UpdatedName { get; set; }
        [NotMapped]
        public virtual ICollection<Assets> Assets { get; set; }

    }
}
