using System.ComponentModel.DataAnnotations;


namespace VehicleDatabaseAPI.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(100)]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
