using CleanAPI.Games.UseCases.Games;
using CleanAPI.Games.UseCases.Games.List;

namespace CleanAPI.Games.Infrastructure.Data.Queries;

public class FakeListGamesQueryService : IListGamesQueryService
{
  public Task<IEnumerable<GameDTO>> ListAsync()
  {
    List<GameDTO> result =
        [new GameDTO(1, "Fake Game 1", "", []),
        new GameDTO(2, "Fake Game 2", "", [])];

    return Task.FromResult(result.AsEnumerable());
  }
}
