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
        public string CreatedName { get; set; }
        public DateTime UpdatedDate { get; set; } 
        public string UpdatedName { get; set; }
        public virtual ICollection<Assets> Assets { get; set; }

    }
}
