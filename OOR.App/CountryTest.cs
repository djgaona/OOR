using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OOR.Domain.Entities;

namespace OOR.App
{
    public class CountryTest
    {
        public static void InsertCountry()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<OORDbContext>(options =>
                    options.UseNpgsql("Host=localhost;Database=odds;Username=postgres;Password=123"))
                .BuildServiceProvider();

            using (var context = serviceProvider.GetRequiredService<OORDbContext>())
            {
                var newCountry = new Country
                {
                    Name = "Paraguay",
                    Code = "PY"
                };

                context.Countries.Add(newCountry);
                context.SaveChanges();

                Console.WriteLine("✅ Country inserted successfully!");
            }
        }
    }
}