using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcultancyCRM.Models
{
    public class LeadStatus
    {
        [ForeignKey("LeadInfo")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public enumLeadStatus Status { get; set; }
        public DateTime LastUpdatedByDate { get; set; }
        [MaxLength(255)]
        public string LastUpdatedByName { get; set; }
        public virtual LeadInfo LeadInfo { get; set; }
    }
}