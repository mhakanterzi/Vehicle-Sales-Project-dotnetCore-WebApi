using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleDatabaseAPI.Models
{
    public class SoldVehicle
    {
        [Required]
        public decimal SoldPrice { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public string Plate { get; set; }

    }
}
