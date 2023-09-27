using System.ComponentModel.DataAnnotations;
namespace ConcultancyCRM.Models
{
    public class AssestCategory
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
        public DateTime LastUpdatedByDate { get; set; }
        public DateTime LastUpdatedByName { get; set; }
    }
}
