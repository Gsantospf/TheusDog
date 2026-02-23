namespace TheusDog.Application.Services;

using TheusDog.Application.DTOs.Dog;
using TheusDog.Application.Interfaces;

public class DogService : IDogService
{
    private readonly IDogRepository _dogRepository;
    private readonly ITutorRepository _tutorRepository;

    public DogService(IDogRepository dogRepository, ITutorRepository tutorRepository)
    {
        _dogRepository = dogRepository;
        _tutorRepository = tutorRepository;
    }

    public async Task<DogResponseDto> CreateAsync(CreateDogDto dto)
    {
        var tutor = await _tutorRepository.GetByIdAsync(dto.TutorId);
        if (tutor is null)
            throw new InvalidOperationException("Tutor não encontrado.");

        var dog = new Dog(dto.Name, dto.Breed, dto.BirthDate,
                          dto.Weight, dto.Size, dto.Gender, dto.TutorId);

        await _dogRepository.AddAsync(dog);
        return MapToResponse(dog, tutor.FullName);
    }

    public async Task<DogResponseDto?> GetByIdAsync(Guid id)
    {
        var dog = await _dogRepository.GetWithTutorAsync(id);
        if (dog is null) return null;

        return MapToResponse(dog, dog.Tutor.FullName);
    }

    public async Task<IEnumerable<DogResponseDto>> GetByTutorIdAsync(Guid tutorId)
    {
        var tutor = await _tutorRepository.GetByIdAsync(tutorId);
        if (tutor is null)
            throw new InvalidOperationException("Tutor não encontrado.");

        var dogs = await _dogRepository.GetByTutorIdAsync(tutorId);
        return dogs.Select(d => MapToResponse(d, tutor.FullName));
    }

    public async Task<DogResponseDto> UpdateAsync(Guid id, UpdateDogDto dto)
    {
        var dog = await _dogRepository.GetWithTutorAsync(id);
        if (dog is null)
            throw new InvalidOperationException("Cachorro não encontrado.");

        dog.UpdateWeight(dto.Weight);
        dog.UpdateObservations(dto.Observations);

        await _dogRepository.UpdateAsync(dog);
        return MapToResponse(dog, dog.Tutor.FullName);
    }

    public async Task DeleteAsync(Guid id)
    {
        var dog = await _dogRepository.GetByIdAsync(id);
        if (dog is null)
            throw new InvalidOperationException("Cachorro não encontrado.");

        await _dogRepository.DeleteAsync(id);
    }

    private static DogResponseDto MapToResponse(Dog dog, string tutorName) => new()
    {
        Id = dog.Id,
        Name = dog.Name,
        Breed = dog.Breed,
        BirthDate = dog.BirthDate,
        Weight = dog.Weight,
        Observations = dog.Observations,
        Size = dog.Size,
        Gender = dog.Gender,
        TutorId = dog.TutorId,
        TutorName = tutorName
    };
}