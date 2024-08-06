using Microsoft.AspNetCore.Mvc;
using VehicleDatabaseAPI.Models;
using VehicleDatabaseAPI.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace VehicleDatabaseAPI.Controllers
{
    [Route("api/soldvehicles")]
    [ApiController]
    public class SoldVehicleController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public SoldVehicleController(VehicleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSolds()
        {
            var solds = _context.SoldVehicle.Include(s => s.CustomerID).Include(s => s.Plate).ToList();
            return Ok(solds);
        }

        [HttpGet("{plate}")]
        public IActionResult GetSold(string plate)
        {
            var sold = _context.SoldVehicle
                .Include(s => s.CustomerID)
                .Include(s => s.Plate)
                .FirstOrDefault(s => s.Plate == plate);

            if (sold == null)
            {
                return NotFound();
            }

            return Ok(sold);
        }

        [HttpPost]
        public IActionResult PostSold(SoldVehicle sold)
        {
            _context.SoldVehicle.Add(sold);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSold), new { plate = sold.Plate }, sold);
        }

        [HttpPut("{plate}")]
        public IActionResult PutSold(string plate, SoldVehicle sold)
        {
            if (plate != sold.Plate)
            {
                return BadRequest();
            }

            var existingSold = _context.SoldVehicle.Find(sold.Plate);
            if (existingSold == null)
            {
                return NotFound();
            }

            existingSold.SoldPrice = sold.SoldPrice;
            existingSold.CustomerID = sold.CustomerID;

            _context.Entry(existingSold).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{plate}")]
        public IActionResult DeleteSold(string plate)
        {            var sold = _context.SoldVehicle.FirstOrDefault(s => s.Plate == plate);
            if (sold == null)
            {
                return NotFound();
            }

            _context.SoldVehicle.Remove(sold);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
