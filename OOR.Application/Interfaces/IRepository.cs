using System.Linq;
using System.Linq.Expressions;
using OOR.Domain.Entities;

namespace OOR.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByCodeAsync(string code);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task<bool> ExistsAsync(string code);

        IQueryable<T> Local { get; } // ✅ Add this line
        Task<SeasonType?> GetByNameAsync(string typeName);
        Task<SeasonType> AddAndReturnAsync(SeasonType seasonType);
        Task<Season?> GetByYearAndTypeAsync(int year, int id);
        Task<Venue?> GetByNameAndLocationAsync(string? name, string? location);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);

        Task<LineType?> GetLineTypeByNameAsync(string typeName);

        Task<T?> FindAsync(Expression<Func<T, bool>> predicate);


    }
}