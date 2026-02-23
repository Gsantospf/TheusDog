namespace TheusDog.Application.Services;

using TheusDog.Application.DTOs.Room;
using TheusDog.Application.Interfaces;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<RoomResponseDto> CreateAsync(CreateRoomDto dto)
    {
        var room = new Room(dto.RoomNumber, dto.MaxCapacity,
                            dto.DailyPrice, dto.Type);

        if (!string.IsNullOrWhiteSpace(dto.Description))
            room.UpdateDescription(dto.Description);

        await _roomRepository.AddAsync(room);
        return MapToResponse(room);
    }

    public async Task<RoomResponseDto?> GetByIdAsync(Guid id)
    {
        var room = await _roomRepository.GetByIdAsync(id);
        if (room is null) return null;

        return MapToResponse(room);
    }

    public async Task<IEnumerable<RoomResponseDto>> GetAllAsync()
    {
        var rooms = await _roomRepository.GetAllAsync();
        return rooms.Select(MapToResponse);
    }

    public async Task<IEnumerable<RoomResponseDto>> GetAvailableRoomsAsync()
    {
        var rooms = await _roomRepository.GetAvailableRoomsAsync();
        return rooms.Select(MapToResponse);
    }

    public async Task DeleteAsync(Guid id)
    {
        var room = await _roomRepository.GetByIdAsync(id);
        if (room is null)
            throw new InvalidOperationException("Quarto não encontrado.");

        await _roomRepository.DeleteAsync(id);
    }

    private static RoomResponseDto MapToResponse(Room room) => new()
    {
        Id = room.Id,
        RoomNumber = room.RoomNumber,
        Description = room.Description,
        MaxCapacity = room.MaxCapacity,
        DailyPrice = room.DailyPrice,
        Type = room.Type,
        Status = room.Status
    };
}