using Ardalis.Specification;

namespace CleanAPI.Games.Core.GameAggregate.Specifications;

public class GameByIdSpec : Specification<Game>
{
  public GameByIdSpec(int gameId)
  {
    Query
        .Where(game => game.Id == gameId);
  }
}
