using Microsoft.AspNetCore.Mvc;
using VehicleDatabaseAPI.Models;
using VehicleDatabaseAPI.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public IActionResult PostVehicle(Vehicle vehicle)
        {
            _context.Vehicle.Add(vehicle);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("plate")]
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

        [HttpPut("{plate}")]
        public async Task<IActionResult> PutVehicle(string plate, [FromBody] Vehicle vehicle)
        {
            if (plate != vehicle.Plate)
            {
                return BadRequest();
            }

            _context.Entry(vehicle).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Vehicle.Any(e => e.Plate == plate))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{plate}")]
        public async Task<IActionResult> DeleteVehicle(string plate)
        {
            var vehicle = await _context.Vehicle.FindAsync(plate);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
