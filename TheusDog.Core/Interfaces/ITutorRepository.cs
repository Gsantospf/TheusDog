namespace TheusDog.Core.Interfaces;

public interface ITutorRepository : IRepository<Tutor>
{
    Task<Tutor?> GetByEmailAsync(string email);
    Task<Tutor?> GetByDocumentAsync(string document);
    Task<Tutor?> GetWithDogsAsync(Guid tutorId);
}