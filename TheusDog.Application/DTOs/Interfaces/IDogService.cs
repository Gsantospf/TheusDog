namespace TheusDog.Application.Interfaces;

using TheusDog.Application.DTOs.Dog;

public interface IDogService
{
    Task<DogResponseDto> CreateAsync(CreateDogDto dto);
    Task<DogResponseDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<DogResponseDto>> GetByTutorIdAsync(Guid tutorId);
    Task<DogResponseDto> UpdateAsync(Guid id, UpdateDogDto dto);
    Task DeleteAsync(Guid id);
}