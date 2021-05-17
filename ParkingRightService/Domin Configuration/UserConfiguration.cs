using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingRightService.Models;


namespace ParkingRightService.Domin_Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.Email)
              .IsRequired()
              .HasMaxLength(100);

            builder.Property(c => c.IsActive)
              .IsRequired();          
        }
    }
    
}
