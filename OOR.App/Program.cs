using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OOR.Application.Interfaces;
using OOR.Infrastructure.Context;
using OOR.Infrastructure.DataSeeders;
using OOR.Infrastructure.Services;
using System;
using System.Threading.Tasks;
using OOR.Application.Interfaces.OOR.Application.Interfaces;

namespace OOR
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // Register your DbContext
                    services.AddDbContext<OddsContext>(options =>
                        options.UseNpgsql("Host=localhost;Database=odds;Username=postgres;Password=123"));

                    // Register HttpClient for OpticOdds API
                    services.AddHttpClient<IOpticOddsApiClient, HttpClientOpticOddsApiClient>(client =>
                    {
                        client.BaseAddress = new Uri("https://api.opticodds.com/api/v3/");
                    });

                    // Register Unit of Work
                    services.AddScoped<IUnitOfWork, UnitOfWork>();

                    // Register seeding service
                    services.AddScoped<SeedDataService>();
                })
                .Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            // Apply any pending migrations
            var context = services.GetRequiredService<OddsContext>();
            await context.Database.MigrateAsync();

            // Run the seeding
            var seeder = services.GetRequiredService<SeedDataService>();
            await seeder.SeedAllAsync();

            Console.WriteLine("Data seeding completed.");
        }
    }
}