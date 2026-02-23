namespace TheusDog.Application.DTOs.Dog;

public class DogResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public DateTime BirthDate { get; set; }
    public float Weight { get; set; }
    public string Observations { get; set; }
    public DogSize Size { get; set; }
    public DogGender Gender { get; set; }
    public Guid TutorId { get; set; }
    public string TutorName { get; set; }
}