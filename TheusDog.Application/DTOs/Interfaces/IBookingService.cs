namespace TheusDog.Application.Interfaces;

using TheusDog.Application.DTOs.Booking;

public interface IBookingService
{
    Task<BookingResponseDto> CreateAsync(CreateBookingDto dto);
    Task<BookingResponseDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookingResponseDto>> GetByDogIdAsync(Guid dogId);
    Task<BookingResponseDto> ConfirmAsync(Guid id);
    Task<BookingResponseDto> CancelAsync(Guid id);
}