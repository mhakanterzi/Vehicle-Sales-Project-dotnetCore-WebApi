namespace VehicleDatabaseAPI.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Brand { get; set; }
        public string Models { get; set; }
        public int Year { get; set; }
        public string Plate { get; set; }
        public string OnSale { get; set; }
    }
}
