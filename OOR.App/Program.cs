// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using OOR.Domain.Entities;
using OOR.Infrastructure.DataSeeders;

Console.WriteLine("Hello, World!");


using var context = new OORDbContext();
// Optionally apply any pending migrations
context.Database.Migrate();

// Seed the sports data each time the app starts.
DataSeeder.SeedSports(context);