using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DogConfiguration : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.ToTable("Dogs");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Breed)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.Size)
            .HasConversion<string>();

        builder.HasOne(d => d.Tutor)
            .WithMany(t => t.Dogs)
            .HasForeignKey(d => d.TutorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}