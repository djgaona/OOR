using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOR.Application.Interfaces;
using OOR.Domain.Entities;
using OOR.Infrastructure.Context;

namespace OOR.Infrastructure.Services
{
    public class SportsbookService : ISportsbookService
    {
        private readonly OddsContext _context;
        private readonly IOpticOddsApiClient _apiClient;

        public SportsbookService(OddsContext context, IOpticOddsApiClient apiClient)
        {
            _context = context;
            _apiClient = apiClient;
        }

        public async Task SeedSportsbooksAsync()
        {
            var sportsbooksFromApi = await _apiClient.GetSportsbooksAsync();
            foreach (var apiSportsbook in sportsbooksFromApi)
            {
                bool exists = await _context.Sportsbooks.AnyAsync(s => s.Code == apiSportsbook.Code);
                if (!exists)
                {
                    _context.Sportsbooks.Add(apiSportsbook);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sportsbook>> GetAllSportsbooksAsync()
        {
            return await _context.Sportsbooks.ToListAsync();
        }
    }
}