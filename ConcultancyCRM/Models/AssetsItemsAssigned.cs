using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcultancyCRM.Models
{
    public class AssetsItemsAssigned
    {
        [Key]
        public int Id { get; set; } 
        public DateTime AssignedDate { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId {  get; set; } 
        [ForeignKey("Employee")]
        public int AssignedToId { get; set; }
        [ForeignKey("Assets")]
        public int AssetsId { get; set; }  
        public DateTime CreatedDate { get; set; }
        public string CreatedName { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Assets Assets { get; set; }
        public virtual Department Department { get; set; }
    }
}
