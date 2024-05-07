using CleanAPI.Games.UseCases.Achievements;
using CleanAPI.Games.UseCases.Achievements.List;
using CleanAPI.Games.UseCases.Games;
using CleanAPI.Games.UseCases.Games.List;
using Microsoft.EntityFrameworkCore;

namespace CleanAPI.Games.Infrastructure.Data.Queries;

public class ListAchievementsQueryService(AppDbContext _db) : IListAchievementsQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries -
  // this is just an example

  public async Task<IEnumerable<AchievementDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider!
    var result = await _db.Database.SqlQuery<AchievementDTO>(
      $"SELECT Id, Name, Description, GlobalPercentage FROM Achievements") // don't fetch other big columns
      .ToListAsync();

    return result;
  }
}
