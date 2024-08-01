using System.ComponentModel.DataAnnotations;

namespace VehicleDatabaseAPI.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }

        [StringLength(100)]
        public string Brand { get; set; }

        [StringLength(100)]
        public string Models { get; set; }
        public int Year { get; set; }
        public string Plate { get; set; }
    }
}
