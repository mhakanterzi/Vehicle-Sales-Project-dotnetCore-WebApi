using Microsoft.AspNetCore.Mvc;
using VehicleDatabaseAPI.Models;
using VehicleDatabaseAPI.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace VehicleDatabaseAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class VehicleSaleInfoController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public VehicleSaleInfoController(VehicleDbContext context)
        {
            _context = context;
        }

        
    }
}
