using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.UseCases.Games;
public record GameDTO(int Id, string Name, string? SteamUrl)
{
  public static GameDTO FromToDoItem(Game game) => new(game.Id, game.Name, game.SteamUrl);
}
