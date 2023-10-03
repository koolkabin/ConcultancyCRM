using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcultancyCRM.Models
{
    public class AssetsItemsAssigned
    {
        public DateTime AssignedDate { get; set; }
        [ForeignKey("Employee")]
        public int AssignedToId { get; set; }
        [Key]
        [ForeignKey("Assets")]
        public int AssetsId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedName { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Assets Assets { get; set; }
    }
}
