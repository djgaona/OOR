using Microsoft.EntityFrameworkCore;
using OOR.Application.Interfaces;
using OOR.Domain.Entities;
using OOR.Infrastructure.Context;

namespace OOR.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly OddsContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(OddsContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<T?> GetByCodeAsync(string code) =>
            await _dbSet.FirstOrDefaultAsync(e => EF.Property<string>(e, "Code") == code);

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public async Task<bool> ExistsAsync(string code) =>
            await _dbSet.AnyAsync(e => EF.Property<string>(e, "Code") == code);

        // ✅ Expose Local DbSet
        public IQueryable<T> Local => _dbSet.Local.AsQueryable();
        public async Task<SeasonType?> GetByNameAsync(string name)
        {
            return await _context.SeasonTypes.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<SeasonType> AddAndReturnAsync(SeasonType seasonType)
        {
            _context.SeasonTypes.Add(seasonType);
            await _context.SaveChangesAsync();
            return seasonType;
        }

        public async Task<Season?> GetByYearAndTypeAsync(int year, int seasonTypeId)
        {
            return await _context.Seasons
                .FirstOrDefaultAsync(s => s.Year == year && s.SeasonTypeId == seasonTypeId);
        }
        public async Task<Venue?> GetByNameAndLocationAsync(string? name, string? location)
        {
            return await _context.Venues
                .FirstOrDefaultAsync(v => v.Name == name && v.Location == location);
        }
    }
}