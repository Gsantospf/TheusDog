namespace TheusDog.Application.DTOs.Room;

public class RoomResponseDto
{
    public Guid Id { get; set; }
    public string RoomNumber { get; set; }
    public string Description { get; set; }
    public int MaxCapacity { get; set; }
    public decimal DailyPrice { get; set; }
    public RoomType Type { get; set; }
    public RoomStatus Status { get; set; }
}