using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcultancyCRM.Models
{
    public class EmployeeHRDetail
    {
        [ForeignKey("Employee")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [ForeignKey("Designation")]
        public int DesignationID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Designation Designation { get; set; }
    }
}