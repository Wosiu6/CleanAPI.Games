using CleanAPI.Games.UseCases.Games;
using CleanAPI.Games.UseCases.Games.List;
using Microsoft.EntityFrameworkCore;

namespace CleanAPI.Games.Infrastructure.Data.Queries;

public class ListGamesQueryService(AppDbContext _db) : IListGamesQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries -
  // this is just an example

  public async Task<IEnumerable<GameDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider!
    var result = await _db.Database.SqlQuery<GameDTO>(
      $"SELECT Id, Name, SteamUrl FROM Games") // don't fetch other big columns
      .ToListAsync();

    return result;
  }
}
