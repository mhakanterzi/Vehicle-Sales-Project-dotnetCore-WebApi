using Microsoft.EntityFrameworkCore;
using VehicleDatabaseAPI.Models;

namespace VehicleDatabaseAPI.Data
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customers> Customer { get; set; }
        public DbSet<Categories> Category { get; set; }
        // Diğer DbSet'leri buraya ekleyin

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlgili konfigürasyonlar buraya eklenebilir
        }
    }
}
