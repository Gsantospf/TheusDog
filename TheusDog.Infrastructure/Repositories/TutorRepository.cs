namespace TheusDog.Infrastructure.Repositories;

public class TutorRepository : Repository<Tutor>, ITutorRepository
{
    public TutorRepository(DogHotelContext context) : base(context) { }

    public async Task<Tutor?> GetByEmailAsync(string email)
    {
        return await _dbSet
            .FirstOrDefaultAsync(t => t.Email == email && !t.IsDeleted);
    }

    public async Task<Tutor?> GetByDocumentAsync(string document)
    {
        return await _dbSet
            .FirstOrDefaultAsync(t => t.Document == document && !t.IsDeleted);
    }

    public async Task<Tutor?> GetWithDogsAsync(Guid tutorId)
    {
        return await _dbSet
            .Include(t => t.Dogs.Where(d => !d.IsDeleted))
            .FirstOrDefaultAsync(t => t.Id == tutorId && !t.IsDeleted);
    }
}