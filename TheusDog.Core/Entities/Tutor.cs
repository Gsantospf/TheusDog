namespace TheusDog.Core.Entities;

public class Tutor : BaseEntity
{
    #region Constructors
    protected Tutor() { }
    public Tutor(string fullName, string email, string document, string phoneNumber, string address, DateTime birthDate)
    {
        FullName = fullName;
        Email = email;
        Document = document;
        PhoneNumber = phoneNumber;
        Address = address;
        BirthDate = birthDate;
        Dogs = new List<Dog>();
    }
    #endregion

    #region Properties

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string Document { get; private set; }
    public string PhoneNumber { get; private set; }
    public string EmergencyContact { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Address { get; private set; }
    public ICollection<Dog> Dogs { get; private set; }
    #endregion

    #region Methods
    public void UpdateAddress(string newAddress)
    {
        Address = newAddress;
        UpdateTimestamps();
    }

    public void UpdateContactInfo(string newEmail, string newPhoneNumber)
    {
        Email = newEmail;
        PhoneNumber = newPhoneNumber;
        UpdateTimestamps();
    }
    #endregion
}