using OOR.Domain.Entities;

namespace OOR.Infrastructure.DataSeeders
{
    public static class DataSeeder
    {
        public static void SeedSports(OORDbContext context)
        {
            // Define the list of sports you want to insert.
            var sportsToSeed = new List<Sport>
            {
                new Sport { Code = "baseball", Name = "Baseball" },
                new Sport { Code = "soccer",   Name = "Soccer" },
                new Sport { Code = "tennis",   Name = "Tennis" }
            };

            // For each sport, check if it exists using the unique Code.
            foreach (var sport in sportsToSeed.Where(sport => !context.Sports.Any(s => s.Code == sport.Code)))
            {
                context.Sports.Add(sport);
            }
            context.SaveChanges();
        }
    }
}