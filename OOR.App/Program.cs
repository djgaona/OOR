// Create the host
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OOR.Application.Interfaces;
using OOR.Application.Interfaces.OOR.Application.Interfaces;
using OOR.Infrastructure.Context;
using OOR.Infrastructure.DataSeeders;
using OOR.Infrastructure.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<OddsContext>(options =>
            options.UseNpgsql("Host=localhost;Database=odds;Username=postgres;Password=123;MaxPoolSize=200"));

        services.AddHttpClient<IOpticOddsApiClient, HttpClientOpticOddsApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.opticodds.com/api/v3/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "1183340c-d160-4f77-9447-90416c7ff363");
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<SeedDataService>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

var context = services.GetRequiredService<OddsContext>();
await context.Database.MigrateAsync();

var seeder = services.GetRequiredService<SeedDataService>();

var fixtures = await context.Fixtures
    .AsNoTracking()
    .Where(f => f.StartDate >= DateTime.SpecifyKind(new DateTime(2025, 5, 6, 23, 20, 0), DateTimeKind.Utc))
    .ToListAsync();

Console.WriteLine($"Seeding odds for {fixtures.Count} fixtures...");

// Define the number of fixtures per batch
const int batchSize = 1000;

var parallelOptions = new ParallelOptions
{
    MaxDegreeOfParallelism = 20  // Set to 20 threads explicitly
};

// Split the fixtures into batches of 1000
var fixtureBatches = fixtures
    .Select((fixture, index) => new { fixture, index })
    .GroupBy(x => x.index / batchSize)
    .Select(group => group.Select(x => x.fixture).ToList())
    .ToList();

// Pass the host services to parallel loop
var rootServiceProvider = host.Services;

await Parallel.ForEachAsync(fixtureBatches, parallelOptions, async (batch, cancellationToken) =>
{
    using var batchScope = rootServiceProvider.CreateScope();
    var scopedServices = batchScope.ServiceProvider;
    var scopedSeeder = scopedServices.GetRequiredService<SeedDataService>();

    try
    {
        Console.WriteLine($"[Thread {Environment.CurrentManagedThreadId}] Starting batch of {batch.Count} fixtures...");
        await scopedSeeder.SeedOddsForFixturesAsync(batch, cancellationToken);
        Console.WriteLine($"[Thread {Environment.CurrentManagedThreadId}] Batch of {batch.Count} fixtures seeded successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[Thread {Environment.CurrentManagedThreadId}] Error seeding batch: {ex.Message}");
    }
});

Console.WriteLine("All odds seeding completed.");
