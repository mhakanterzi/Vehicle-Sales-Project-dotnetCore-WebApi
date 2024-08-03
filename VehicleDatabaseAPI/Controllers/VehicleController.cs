using Microsoft.AspNetCore.Mvc;
using VehicleDatabaseAPI.Models;
using VehicleDatabaseAPI.Data;
using System.Linq;

namespace VehicleDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public VehicleController(VehicleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            var vehicles = _context.Vehicle.ToList();
            return Ok(vehicles);
        }

        [HttpGet("{plate}")]
        public IActionResult GetVehicle(string plate)
        {
            var vehicle = _context.Vehicle.Find(plate);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult PostVehicle( Vehicle vehicle)
        {

                var category = _context.Category.FirstOrDefault(c => c.CategoryName == vehicle.CategoryName);
                if (category == null)
                {
                    return BadRequest("Invalid category");
                }

                vehicle.CategoryName = category.CategoryName;

                _context.Vehicle.Add(vehicle);
                _context.SaveChanges();
                return CreatedAtAction("GetVehicle", new { plate = vehicle.Plate }, vehicle);

        }


        [HttpPut("{plate}")]
        public IActionResult PutVehicle(Vehicle vehicle, string plate)
        {
            if (plate != vehicle.Plate)
            {
                return BadRequest();
            }
            _context.Entry(vehicle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{plate}")]
        public IActionResult DeleteVehicle(string plate)
        {
            var vehicle = _context.Vehicle.Find(plate);
            if (vehicle == null)
            {
                return NotFound();
            }
            _context.Vehicle.Remove(vehicle);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
