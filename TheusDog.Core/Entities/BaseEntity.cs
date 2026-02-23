namespace TheusDog.Core.Entities;

public abstract class BaseEntity
{
    #region Constructors
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }
    #endregion

    #region Properties
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    #endregion

    #region Methods

    public void UpdateTimestamps()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    #endregion
}