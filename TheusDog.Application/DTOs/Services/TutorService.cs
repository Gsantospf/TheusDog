namespace TheusDog.Application.Services;

using TheusDog.Application.DTOs.Tutor;
using TheusDog.Application.Interfaces;

public class TutorService : ITutorService
{
    private readonly ITutorRepository _tutorRepository;

    public TutorService(ITutorRepository tutorRepository)
    {
        _tutorRepository = tutorRepository;
    }

    public async Task<TutorResponseDto> CreateAsync(CreateTutorDto dto)
    {
        var existingTutor = await _tutorRepository.GetByEmailAsync(dto.Email);
        if (existingTutor is not null)
            throw new InvalidOperationException("Já existe um tutor com esse e-mail.");

        var tutor = new Tutor(dto.FullName, dto.Email, dto.Document,
                              dto.PhoneNumber, dto.Address, dto.BirthDate);

        await _tutorRepository.AddAsync(tutor);
        return MapToResponse(tutor);
    }

    public async Task<TutorResponseDto?> GetByIdAsync(Guid id)
    {
        var tutor = await _tutorRepository.GetByIdAsync(id);
        if (tutor is null) return null;

        return MapToResponse(tutor);
    }

    public async Task<IEnumerable<TutorResponseDto>> GetAllAsync()
    {
        var tutors = await _tutorRepository.GetAllAsync();
        return tutors.Select(MapToResponse);
    }

    public async Task<TutorResponseDto> UpdateAsync(Guid id, UpdateTutorDto dto)
    {
        var tutor = await _tutorRepository.GetByIdAsync(id);
        if (tutor is null)
            throw new InvalidOperationException("Tutor não encontrado.");

        tutor.UpdateContactInfo(dto.Email, dto.PhoneNumber);
        tutor.UpdateAddress(dto.Address);

        await _tutorRepository.UpdateAsync(tutor);
        return MapToResponse(tutor);
    }

    public async Task DeleteAsync(Guid id)
    {
        var tutor = await _tutorRepository.GetByIdAsync(id);
        if (tutor is null)
            throw new InvalidOperationException("Tutor não encontrado.");

        await _tutorRepository.DeleteAsync(id);
    }

    private static TutorResponseDto MapToResponse(Tutor tutor) => new()
    {
        Id = tutor.Id,
        FullName = tutor.FullName,
        Email = tutor.Email,
        PhoneNumber = tutor.PhoneNumber,
        Address = tutor.Address,
        CreatedAt = tutor.CreatedAt
    };
}