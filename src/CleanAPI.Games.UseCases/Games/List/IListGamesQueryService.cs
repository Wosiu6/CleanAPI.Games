namespace CleanAPI.Games.UseCases.Games.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListGamesQueryService
{
  Task<IEnumerable<GameDTO>> ListAsync();
}
