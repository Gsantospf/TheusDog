using Microsoft.EntityFrameworkCore;
namespace TheusDog.Infrastructure.Data;


public class DogHotelContext : DbContext
{
    public DogHotelContext(DbContextOptions<DogHotelContext> options) : base(options) { }

    #region DbSets (Tabelas)

    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DogHotelContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}