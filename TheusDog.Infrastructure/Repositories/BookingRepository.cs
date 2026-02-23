namespace TheusDog.Infrastructure.Repositories;

public class BookingRepository : Repository<Booking>, IBookingRepository
{
    public BookingRepository(DogHotelContext context) : base(context) { }

    public async Task<IEnumerable<Booking>> GetByDogIdAsync(Guid dogId)
    {
        return await _dbSet
            .Where(b => b.DogId == dogId && !b.IsDeleted)
            .ToListAsync();
    }

    public async Task<IEnumerable<Booking>> GetByRoomIdAsync(Guid roomId)
    {
        return await _dbSet
            .Where(b => b.RoomId == roomId && !b.IsDeleted)
            .ToListAsync();
    }

    public async Task<bool> HasConflictingBookingAsync(Guid roomId, DateTime startDate, DateTime endDate)
    {
        return await _dbSet.AnyAsync(b =>
            b.RoomId == roomId &&
            !b.IsDeleted &&
            b.Status != BookingStatus.Canceled &&
            b.StartDate < endDate &&
            b.EndDate > startDate);
    }

    public async Task<Booking?> GetWithDetailsAsync(Guid bookingId)
    {
        return await _dbSet
            .Include(b => b.Dog)
            .Include(b => b.Room)
            .FirstOrDefaultAsync(b => b.Id == bookingId && !b.IsDeleted);
    }
}