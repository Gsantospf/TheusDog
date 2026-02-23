namespace TheusDog.Core.Interfaces;

public interface IDogRepository : IRepository<Dog>
{
    Task<IEnumerable<Dog>> GetByTutorIdAsync(Guid tutorId);
    Task<Dog?> GetWithTutorAsync(Guid dogId);
}