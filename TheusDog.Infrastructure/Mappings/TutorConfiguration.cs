using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TutorConfiguration : IEntityTypeConfiguration<Tutor>
{
    public void Configure(EntityTypeBuilder<Tutor> builder)
    {
        builder.ToTable("Tutors");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.FullName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Document)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(t => t.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(t => t.Address)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(t => t.BirthDate)
            .IsRequired();

        builder.HasIndex(t => t.Email).IsUnique();
        builder.HasIndex(t => t.Document).IsUnique();
    }
}