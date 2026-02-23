namespace TheusDog.Api.Controllers;

using TheusDog.Application.DTOs.Room;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rooms = await _roomService.GetAllAsync();
        return Ok(rooms);
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailable()
    {
        var rooms = await _roomService.GetAvailableRoomsAsync();
        return Ok(rooms);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var room = await _roomService.GetByIdAsync(id);
        if (room is null) return NotFound();

        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoomDto dto)
    {
        var room = await _roomService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _roomService.DeleteAsync(id);
        return NoContent();
    }
}