using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingRightService.Models;

namespace ParkingRightService.Domin_Configuration
{
    /// <summary>
    /// Schema builder for ParkingRquest model
    /// </summary>
    public class ParkingRquestConfiguration : IEntityTypeConfiguration<ParkingRequest>
    {
        public void Configure(EntityTypeBuilder<ParkingRequest> builder)
        {
        builder.HasKey(c => c.id);
            builder.Property(c => c.LicensePlateNumber)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.StartDate)
               .IsRequired();

            builder.Property(c => c.EndDate)
              .IsRequired();

            builder.Property(c => c.Amount)
              .IsRequired();

            builder.Property(c => c.EndDate)
            .IsRequired();
            builder.HasOne<User>(s => s.User)
                .WithMany(g => g.ParkingRequests)
                .HasForeignKey(s => s.UserId);

            builder.HasOne<ParkingZone>(s => s.parkingZone)
                .WithMany(g => g.ParkingRequests)
                .HasForeignKey(g => g.ParkingZoneId);


        }
    }
}
