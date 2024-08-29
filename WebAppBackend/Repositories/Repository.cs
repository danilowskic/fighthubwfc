using Microsoft.EntityFrameworkCore;

namespace WebAppBackend.Repositories;

public class Repository<T> : IRepository<T> where T : class
{

    protected readonly DbContext _dbContext;
    protected readonly DbSet<T> _dbSet;
        
    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }
    
    public async Task AddAsync(T t)
    {
        await _dbSet.AddAsync(t);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task UpdateAsync(T t)
    {
        _dbSet.Update(t);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T t)
    {
        _dbSet.Remove(t);
        await _dbContext.SaveChangesAsync();
    }
}