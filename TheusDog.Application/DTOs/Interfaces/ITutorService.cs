namespace TheusDog.Application.Interfaces;

using TheusDog.Application.DTOs.Tutor;

public interface ITutorService
{
    Task<TutorResponseDto> CreateAsync(CreateTutorDto dto);
    Task<TutorResponseDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<TutorResponseDto>> GetAllAsync();
    Task<TutorResponseDto> UpdateAsync(Guid id, UpdateTutorDto dto);
    Task DeleteAsync(Guid id);
}