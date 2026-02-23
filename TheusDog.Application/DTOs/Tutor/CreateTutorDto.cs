namespace TheusDog.Application.DTOs.Tutor;

public class CreateTutorDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Document { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime BirthDate { get; set; }
}