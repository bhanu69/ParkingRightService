using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingRightService.Models;

namespace ParkingRightService.Domin_Configuration
{
    /// <summary>
    /// Schema builder for ParkingZone model
    /// </summary>
    public class ParkingZoneConfiguration : IEntityTypeConfiguration<ParkingZone>
    {
        public void Configure(EntityTypeBuilder<ParkingZone> builder)
        {
            builder.HasKey(c => c.id);

            builder.Property(c => c.Zone)
                .IsRequired()
                .HasMaxLength(500);


        }

    }
}
