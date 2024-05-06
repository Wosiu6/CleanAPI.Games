using CleanAPI.Games.UseCases.Users;
using CleanAPI.Games.UseCases.Users.List;

namespace CleanAPI.Games.Infrastructure.Data.Queries;

public class FakeListUserQueryService : IListUsersQueryService
{
  public Task<IEnumerable<UserDTO>> ListAsync()
  {
    List<UserDTO> result =
        [new UserDTO(1, "Fake User 1", new List<UseCases.Games.GameDTO>()),
        new UserDTO(2, "Fake User 2", new List<UseCases.Games.GameDTO>())];

    return Task.FromResult(result.AsEnumerable());
  }
}
