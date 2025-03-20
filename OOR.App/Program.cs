using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OOR.Application.Interfaces;
using OOR.Domain.Entities;
using OOR.Infrastructure.Context;
using OOR.Infrastructure.DataSeeders;
using OOR.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace OOR
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // Register your DbContext (adjust connection string as needed).
                    services.AddDbContext<OddsContext>(options =>
                        options.UseNpgsql("Host=localhost;Database=odds;Username=postgres;Password=123"));

                    // Register HttpClient for the API client.
                    services.AddHttpClient<IOpticOddsApiClient, HttpClientOpticOddsApiClient>(client =>
                    {
                        client.BaseAddress = new Uri("https://api.opticodds.com/api/v3/");
                    });

                    // When injecting IOpticOddsApiClient, pass the API key in the constructor of HttpClientOpticOddsApiClient.
                    services.AddSingleton<IOpticOddsApiClient>(provider =>
                    {
                        var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
                        var httpClient = httpClientFactory.CreateClient();
                        // Make sure your HttpClientOpticOddsApiClient accepts the API key as a parameter if needed.
                        return new HttpClientOpticOddsApiClient(httpClient);
                    });

                    // Register our seeding services.
                    services.AddScoped<ILeagueService, LeagueService>();
                    services.AddScoped<ISportsbookService, SportsbookService>();
                    services.AddScoped<IMarketService, MarketService>();
                })
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<OddsContext>();

                // Apply pending migrations.
                await context.Database.MigrateAsync();

                DataSeeder.SeedSports(context);


                // Run the seeding methods in the required order.
                // 1. Seed Leagues.
                var leagueService = services.GetRequiredService<ILeagueService>();
                await leagueService.SeedLeaguesAsync();

                // 2. Seed Sportsbooks.
                var sportsbookService = services.GetRequiredService<ISportsbookService>();
                await sportsbookService.SeedSportsbooksAsync();

                // 3. Seed Markets.
                var marketService = services.GetRequiredService<IMarketService>();
                await marketService.SeedMarketsAsync();
            }

            Console.WriteLine("Leagues, Markets, and Sportsbooks have been seeded (if not already present).");
            // Continue with your application...
        }
    }
}
