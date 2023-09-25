using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcultancyCRM.Models
{
    public class LeadComments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [ForeignKey("LeadInfo")]
        public int LeadInfoId { get; set; }
        public enumLeadStatus Status { get; set; }
        public DateTime TxnDate { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string EmpName { get; set; }
        public virtual LeadInfo LeadInfo { get; set; }
        public virtual Employee Employee { get; set; }

    }
}