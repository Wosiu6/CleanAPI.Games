using CleanAPI.Games.Core.ContributorAggregate;
using CleanAPI.Games.Core.GameAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanAPI.Games.Infrastructure.Data;

public static class SeedData
{
  public static readonly Contributor Contributor1 = new("Ardalis");
  public static readonly Contributor Contributor2 = new("Snowfrog");

  public static readonly Game Game1 = new("Witcher 3", "www.example.com");
  public static readonly Game Game2 = new("Cyberpunk", "www.example.com");

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      if (dbContext.Contributors.Any() && dbContext.Games.Any()) return; // DB has been seeded

      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var contributor in dbContext.Contributors)
    {
      dbContext.Remove(contributor);
    }
    
    foreach (var game in dbContext.Games)
    {
      dbContext.Remove(game);
    }

    dbContext.SaveChanges();

    dbContext.Contributors.Add(Contributor1);
    dbContext.Contributors.Add(Contributor2);

    dbContext.Games.Add(Game1);
    dbContext.Games.Add(Game2);

    dbContext.SaveChanges();
  }
}
