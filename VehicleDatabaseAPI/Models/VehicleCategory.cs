﻿namespace VehicleDatabaseAPI.Models
{
    public class VehicleCategory
    {
        public int VehicleID { get; set; }
        public int CategoryID { get; set; }
        public Vehicle Vehicle { get; set; }
        public Categories Category { get; set; }
    }
}
