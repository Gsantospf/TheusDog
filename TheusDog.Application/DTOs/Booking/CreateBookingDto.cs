namespace TheusDog.Application.DTOs.Booking;

public class CreateBookingDto
{
    public Guid DogId { get; set; }
    public Guid RoomId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}