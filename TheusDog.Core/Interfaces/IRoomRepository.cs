namespace TheusDog.Core.Interfaces;

public interface IRoomRepository : IRepository<Room>
{
    Task<IEnumerable<Room>> GetAvailableRoomsAsync();
    Task<IEnumerable<Room>> GetByTypeAsync(RoomType type);
}