namespace TheusDog.Core.Interfaces;

public interface IBookingRepository : IRepository<Booking>
{
    Task<IEnumerable<Booking>> GetByDogIdAsync(Guid dogId);
    Task<IEnumerable<Booking>> GetByRoomIdAsync(Guid roomId);
    Task<bool> HasConflictingBookingAsync(Guid roomId, DateTime startDate, DateTime endDate);
    Task<Booking?> GetWithDetailsAsync(Guid bookingId);
}