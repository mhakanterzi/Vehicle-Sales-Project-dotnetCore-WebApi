using Microsoft.AspNetCore.Mvc;
using VehicleDatabaseAPI.Models;
using VehicleDatabaseAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace VehicleDatabaseAPI.Controllers
{
    [Route("api/controller")]
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
            var solds = _context.SoldVehicle.ToList();
            return Ok(solds);
        }

        [HttpGet("{plate}")]
        public IActionResult GetSold(string plate)
        {
            var sold = _context.SoldVehicle.FirstOrDefault(s => s.Plate == plate);
            if(plate== null)
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
            if(plate != sold.Plate)
            {
                return NotFound();
            }
            _context.Entry(sold).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Plate}")]
        public IActionResult DeleteSold ( string plate)
        {
            var sold = _context.SoldVehicle.FirstOrDefault(s => s.Plate == plate);
            if(sold == null)
            {
                return NotFound();
            }
            _context.SoldVehicle.Remove(sold);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
