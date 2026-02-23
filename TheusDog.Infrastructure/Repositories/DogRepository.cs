namespace TheusDog.Infrastructure.Repositories;

public class DogRepository : Repository<Dog>, IDogRepository
{
    public DogRepository(DogHotelContext context) : base(context) { }

    public async Task<IEnumerable<Dog>> GetByTutorIdAsync(Guid tutorId)
    {
        return await _dbSet
            .Where(d => d.TutorId == tutorId && !d.IsDeleted)
            .ToListAsync();
    }

    public async Task<Dog?> GetWithTutorAsync(Guid dogId)
    {
        return await _dbSet
            .Include(d => d.Tutor)
            .FirstOrDefaultAsync(d => d.Id == dogId && !d.IsDeleted);
    }
}