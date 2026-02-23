namespace TheusDog.Application.Interfaces;

using TheusDog.Application.DTOs.Room;

public interface IRoomService
{
    Task<RoomResponseDto> CreateAsync(CreateRoomDto dto);
    Task<RoomResponseDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<RoomResponseDto>> GetAllAsync();
    Task<IEnumerable<RoomResponseDto>> GetAvailableRoomsAsync();
    Task DeleteAsync(Guid id);
}