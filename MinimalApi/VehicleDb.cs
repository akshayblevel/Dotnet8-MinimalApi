using Microsoft.EntityFrameworkCore;

namespace MinimalApi
{
    public class VehicleDb : DbContext
    {
        public VehicleDb(DbContextOptions<VehicleDb> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
