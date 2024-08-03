namespace VehicleDatabaseAPI.Models
{
    public class ReceivedVehicle
    {
        public int ReceivedVehicleID { get; set; } 

        public decimal ReceivedPrice { get; set; }
        public int CustomerID { get; set; }
        public int VehicleID { get; set; }
        public string OnSale { get; set; } = "yes";


        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
