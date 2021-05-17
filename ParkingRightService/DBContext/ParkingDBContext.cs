using Microsoft.EntityFrameworkCore;
using ParkingRightService.Domin_Configuration;
using ParkingRightService.Models;

namespace ParkingRightService.DBContext
{
    /// <summary>
    /// Parking Request DB Context
    /// </summary>
    public class ParkingDBContext : DbContext 
    {

        public ParkingDBContext(DbContextOptions<ParkingDBContext> options)
        : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<ParkingZone> ParkingZone { get; set; }

        public DbSet<ParkingRequest> ParkingRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ParkingZoneConfiguration());
            modelBuilder.ApplyConfiguration(new ParkingRquestConfiguration());
            modelBuilder.Entity<ParkingZone>().HasData(
                new ParkingZone
                {
                    id=1,
                    Zone = "EAST",
                    IsActive=true

                },
                new ParkingZone
                {
                    id = 2,
                    Zone = "WEST",
                    IsActive=true
                }

                );

        }

    }
}
