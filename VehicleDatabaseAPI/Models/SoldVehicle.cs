namespace VehicleDatabaseAPI.Models
{
    public class SoldVehicle
    {
        public int SoldVehicleID { get; set; }

        public decimal SoldPrice { get; set; }
        public int CustomerID { get; set; }
        public int VehicleID { get; set; }
        public Customers Customer { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
