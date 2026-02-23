namespace TheusDog.Application.Services;

using TheusDog.Application.DTOs.Booking;
using TheusDog.Application.Interfaces;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IDogRepository _dogRepository;
    private readonly IRoomRepository _roomRepository;

    public BookingService(IBookingRepository bookingRepository,
                          IDogRepository dogRepository,
                          IRoomRepository roomRepository)
    {
        _bookingRepository = bookingRepository;
        _dogRepository = dogRepository;
        _roomRepository = roomRepository;
    }

    public async Task<BookingResponseDto> CreateAsync(CreateBookingDto dto)
    {
        var dog = await _dogRepository.GetByIdAsync(dto.DogId);
        if (dog is null)
            throw new InvalidOperationException("Cachorro não encontrado.");

        var room = await _roomRepository.GetByIdAsync(dto.RoomId);
        if (room is null)
            throw new InvalidOperationException("Quarto não encontrado.");

        if (room.Status != RoomStatus.Available)
            throw new InvalidOperationException("Quarto não está disponível.");

        var hasConflict = await _bookingRepository.HasConflictingBookingAsync(
            dto.RoomId, dto.StartDate, dto.EndDate);

        if (hasConflict)
            throw new InvalidOperationException("Quarto já reservado nesse período.");

        var booking = new Booking(dto.DogId, room, dto.StartDate, dto.EndDate);

        await _bookingRepository.AddAsync(booking);
        return MapToResponse(booking, dog.Name, room.RoomNumber);
    }

    public async Task<BookingResponseDto?> GetByIdAsync(Guid id)
    {
        var booking = await _bookingRepository.GetWithDetailsAsync(id);
        if (booking is null) return null;

        return MapToResponse(booking, booking.Dog.Name, booking.Room.RoomNumber);
    }

    public async Task<IEnumerable<BookingResponseDto>> GetByDogIdAsync(Guid dogId)
    {
        var dog = await _dogRepository.GetByIdAsync(dogId);
        if (dog is null)
            throw new InvalidOperationException("Cachorro não encontrado.");

        var bookings = await _bookingRepository.GetByDogIdAsync(dogId);
        return bookings.Select(b => MapToResponse(b, dog.Name, string.Empty));
    }

    public async Task<BookingResponseDto> ConfirmAsync(Guid id)
    {
        var booking = await _bookingRepository.GetWithDetailsAsync(id);
        if (booking is null)
            throw new InvalidOperationException("Reserva não encontrada.");

        if (booking.Status != BookingStatus.Pending)
            throw new InvalidOperationException("Apenas reservas pendentes podem ser confirmadas.");

        booking.ConfirmBooking();
        await _bookingRepository.UpdateAsync(booking);
        return MapToResponse(booking, booking.Dog.Name, booking.Room.RoomNumber);
    }

    public async Task<BookingResponseDto> CancelAsync(Guid id)
    {
        var booking = await _bookingRepository.GetWithDetailsAsync(id);
        if (booking is null)
            throw new InvalidOperationException("Reserva não encontrada.");

        if (booking.Status == BookingStatus.Completed)
            throw new InvalidOperationException("Reservas concluídas não podem ser canceladas.");

        if (booking.Status == BookingStatus.Canceled)
            throw new InvalidOperationException("Reserva já está cancelada.");

        booking.CancelBooking();
        await _bookingRepository.UpdateAsync(booking);
        return MapToResponse(booking, booking.Dog.Name, booking.Room.RoomNumber);
    }

    private static BookingResponseDto MapToResponse(Booking booking, string dogName, string roomNumber) => new()
    {
        Id = booking.Id,
        StartDate = booking.StartDate,
        EndDate = booking.EndDate,
        TotalPrice = booking.TotalPrice,
        Status = booking.Status,
        DogId = booking.DogId,
        DogName = dogName,
        RoomId = booking.RoomId,
        RoomNumber = roomNumber
    };
}