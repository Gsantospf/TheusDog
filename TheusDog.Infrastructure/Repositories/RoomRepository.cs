namespace TheusDog.Infrastructure.Repositories;

public class RoomRepository : Repository<Room>, IRoomRepository
{
    public RoomRepository(DogHotelContext context) : base(context) { }

    public async Task<IEnumerable<Room>> GetAvailableRoomsAsync()
    {
        return await _dbSet
            .Where(r => r.Status == RoomStatus.Available && !r.IsDeleted)
            .ToListAsync();
    }

    public async Task<IEnumerable<Room>> GetByTypeAsync(RoomType type)
    {
        return await _dbSet
            .Where(r => r.Type == type && !r.IsDeleted)
            .ToListAsync();
    }
}