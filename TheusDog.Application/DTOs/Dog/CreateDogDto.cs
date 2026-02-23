namespace TheusDog.Application.DTOs.Dog;

public class CreateDogDto
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public DateTime BirthDate { get; set; }
    public float Weight { get; set; }
    public DogSize Size { get; set; }
    public DogGender Gender { get; set; }
    public Guid TutorId { get; set; }
}