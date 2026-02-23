using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.RoomNumber).IsRequired().HasMaxLength(10);

        builder.Property(r => r.DailyPrice).HasColumnType("decimal(18,2)").IsRequired();

        builder.Property(r => r.Type).HasConversion<string>();
        builder.Property(r => r.Status).HasConversion<string>();

        builder.HasMany(r => r.Bookings)
            .WithOne(b => b.Room)
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}