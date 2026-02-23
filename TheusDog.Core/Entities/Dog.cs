namespace TheusDog.Core.Entities;

public class Dog : BaseEntity
{
    #region Constructors
    protected Dog() { }

    public Dog(string name, string breed, DateTime birthDate, float weight,
                   DogSize size, DogGender gender, Guid tutorId)
    {
        Name = name;
        Breed = breed;
        BirthDate = birthDate;
        Weight = weight;
        Size = size;
        Gender = gender;
        TutorId = tutorId;
    }
    #endregion

    #region Properties

    public string Name { get; private set; }
    public string Breed { get; private set; }
    public DateTime BirthDate { get; private set; }
    public float Weight { get; private set; }
    public string Observations { get; private set; }

    public DogSize Size { get; private set; }
    public DogGender Gender { get; private set; }

    public Guid TutorId { get; private set; }
    public virtual Tutor Tutor { get; private set; }

    #endregion

    #region Methods

    public void UpdateObservations(string newObservations)
    {
        Observations = newObservations;
        UpdateTimestamps();
    }

    public void UpdateWeight(float newWeight)
    {
        Weight = newWeight;
        UpdateTimestamps();
    }

    #endregion
}