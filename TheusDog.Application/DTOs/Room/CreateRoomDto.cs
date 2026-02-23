namespace TheusDog.Application.DTOs.Room;

public class CreateRoomDto
{
    public string RoomNumber { get; set; }
    public string Description { get; set; }
    public int MaxCapacity { get; set; }
    public decimal DailyPrice { get; set; }
    public RoomType Type { get; set; }
}