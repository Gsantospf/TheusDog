namespace TheusDog.Core.Entities;

public class Room : BaseEntity
{
    #region Constructors
    protected Room() { }
    public Room(string roomNumber, int maxCapacity, decimal dailyPrice,
                    RoomType type)
    {
        RoomNumber = roomNumber;
        MaxCapacity = maxCapacity;
        DailyPrice = dailyPrice;
        Type = type;
        Status = RoomStatus.Available;
        Bookings = new List<Booking>();
    }

    #endregion

    #region Properties

    public string RoomNumber { get; private set; }
    public string Description { get; private set; }
    public int MaxCapacity { get; private set; }
    public decimal DailyPrice { get; private set; }

    public RoomType Type { get; private set; }
    public RoomStatus Status { get; private set; }

    public virtual ICollection<Booking> Bookings { get; private set; }

    #endregion

    #region Methods

    public void UpdateStatus(RoomStatus newStatus)
    {
        Status = newStatus;
        UpdateTimestamps();
    }

    public void SetMaintenance()
    {
        Status = RoomStatus.Maintenance;
        UpdateTimestamps();
    }

    public void UpdateDescription(string description)
    {
        Description = description;
        UpdateTimestamps();
    }

    #endregion
}