namespace TheusDog.Core.Entities;

public class Booking : BaseEntity
{
    #region Constructors
    protected Booking() { }

    public Booking(Guid dogId, Room room, DateTime startDate, DateTime endDate)
    {
        if (endDate <= startDate)
            throw new ArgumentException("A data de saída deve ser maior que a data de entrada.");

        DogId = dogId;
        RoomId = room.Id;
        Room = room;
        StartDate = startDate;
        EndDate = endDate;
        Status = BookingStatus.Pending;

        CalculateTotal(room.DailyPrice);
    }


    #endregion

    #region Properties

    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }

    public Guid DogId { get; private set; }
    public virtual Dog Dog { get; private set; }

    public Guid RoomId { get; private set; }
    public virtual Room Room { get; private set; }

    #endregion

    #region Methods

    public void CalculateTotal(decimal dailyPrice)
    {
        var totalDays = (EndDate - StartDate).Days;
        if (totalDays <= 0)
            totalDays = 1;

        TotalPrice = totalDays * dailyPrice;
    }

    public void ConfirmBooking()
    {
        Status = BookingStatus.Confirmed;
        UpdateTimestamps();
    }

    public void CancelBooking()
    {
        Status = BookingStatus.Canceled;
        UpdateTimestamps();
    }

    #endregion
}