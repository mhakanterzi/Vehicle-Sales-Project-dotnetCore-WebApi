using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleDatabaseAPI.Models
{
    public class SoldVehicle
    {
        [Key]
        public decimal SoldPrice { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [ForeignKey("Vehicle")]
        public string Plate { get; set; }
    }
}
