using CleanAPI.Games.Core.UserAggregate;
using CleanAPI.Games.Core.GameAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanAPI.Games.Infrastructure.Data;

public static class SeedData
{
  public static readonly User User1 = new("Ardalis");
  public static readonly User User2 = new("Snowfrog");

  public static readonly Game Game1 = new("Witcher 3", "www.example.com");
  public static readonly Game Game2 = new("Cyberpunk", "www.example.com");

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      if (dbContext.Users.Any() && dbContext.Games.Any()) return; // DB has been seeded

      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var User in dbContext.Users)
    {
      dbContext.Remove(User);
    }
    
    foreach (var game in dbContext.Games)
    {
      dbContext.Remove(game);
    }

    dbContext.SaveChanges();

    dbContext.Users.Add(User1);
    dbContext.Users.Add(User2);

    dbContext.Games.Add(Game1);
    dbContext.Games.Add(Game2);

    dbContext.SaveChanges();
  }
}
