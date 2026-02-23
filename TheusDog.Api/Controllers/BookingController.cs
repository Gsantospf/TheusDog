namespace TheusDog.Api.Controllers;

using TheusDog.Application.DTOs.Booking;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var booking = await _bookingService.GetByIdAsync(id);
        if (booking is null) return NotFound();

        return Ok(booking);
    }

    [HttpGet("dog/{dogId:guid}")]
    public async Task<IActionResult> GetByDog(Guid dogId)
    {
        var bookings = await _bookingService.GetByDogIdAsync(dogId);
        return Ok(bookings);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto dto)
    {
        var booking = await _bookingService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
    }

    [HttpPatch("{id:guid}/confirm")]
    public async Task<IActionResult> Confirm(Guid id)
    {
        var booking = await _bookingService.ConfirmAsync(id);
        return Ok(booking);
    }

    [HttpPatch("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel(Guid id)
    {
        var booking = await _bookingService.CancelAsync(id);
        return Ok(booking);
    }
}