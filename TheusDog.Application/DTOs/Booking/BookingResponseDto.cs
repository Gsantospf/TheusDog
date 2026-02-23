namespace TheusDog.Application.DTOs.Booking;

public class BookingResponseDto
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public BookingStatus Status { get; set; }
    public Guid DogId { get; set; }
    public string DogName { get; set; }
    public Guid RoomId { get; set; }
    public string RoomNumber { get; set; }
}