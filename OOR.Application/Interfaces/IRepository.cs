using System.Linq;
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
    }
}