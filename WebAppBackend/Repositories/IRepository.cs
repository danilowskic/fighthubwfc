namespace WebAppBackend.Repositories;

/// <summary>
///     CRUD repository interface
/// </summary>
/// <typeparam name="T">T can be every every type present in database</typeparam>
public interface IRepository<T> where T : class
{
    Task AddAsync(T t);                // (C)reate
    Task<T> GetByIdAsync(long id);     // (R)ead
    Task<IEnumerable<T>> GetAllAsync();// (R)ead
    Task UpdateAsync(T t);             // (U)pdate
    Task DeleteAsync(T t);             // (D)elete
}