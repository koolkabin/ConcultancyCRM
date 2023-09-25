using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcultancyCRM.Models
{
    public class AssignedLeads
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("LeadInfo")]
        public int LeadInfoId { get; set; }
        public DateTime AssignedDate { get; set; }
        [MaxLength(255)]
        public string AssignedByName { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual LeadInfo LeadInfo { get; set; }
    }
}