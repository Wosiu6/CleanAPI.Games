using CleanAPI.Games.UseCases.Users;
using CleanAPI.Games.UseCases.Users.List;
using Microsoft.EntityFrameworkCore;

namespace CleanAPI.Games.Infrastructure.Data.Queries;

public class ListUserQueryService(AppDbContext _db) : IListUsersQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries -
  // this is just an example

  public async Task<IEnumerable<UserDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider!
    var result = await _db.Database.SqlQuery<UserDTO>(
      $"SELECT Id, Name, PhoneNumber_Number AS PhoneNumber FROM Users") // don't fetch other big columns
      .ToListAsync();

    return result;
  }
}
