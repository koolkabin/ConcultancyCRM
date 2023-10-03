using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConcultancyCRM.Models
{
    public class Assets
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string AssetName { get; set; }
        [MaxLength(255)]
        public string AssetTag { get; set; }
        [MaxLength(255)]
        public string Model { get; set; }
        [MaxLength(255)]
        public string ModelNumber { get; set; }
        [MaxLength(255)]
        public string Manufacturer   { get; set; }
        [MaxLength(255)]
        public string Serial { get; set; }
        [MaxLength(255)]
        public string Location { get; set; }
        public int RAM { get; set; } 
        public int Processor { get; set; }   
        public int Storage { get; set; }
        public EnumHealthType Health { get; set; }
        [MaxLength(255)]
        public string Remarks { get; set; }
        [ForeignKey("AssetsCategory")]
        public int AssetsCategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedName { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedName { get; set; }
        public virtual AssetsCategory AssetsCategory { get; set; }
        public virtual AssetsItemsAssigned AssetsItemsAssigned { get; set; }

    }
    public enum EnumHealthType
    {
        Okay = 1,
        Bad = 2
    }
}
