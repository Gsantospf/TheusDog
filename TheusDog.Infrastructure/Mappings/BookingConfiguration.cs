using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.StartDate)
            .IsRequired();

        builder.Property(b => b.EndDate)
            .IsRequired();

        builder.Property(b => b.TotalPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(b => b.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.HasOne(b => b.Dog)
            .WithMany()
            .HasForeignKey(b => b.DogId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.Room)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}