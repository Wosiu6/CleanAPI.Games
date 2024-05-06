using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.Core.UserAggregate;

public class User(string name, List<Game>? games = null) : EntityBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public List<Game> Games { get; private set; } = Guard.Against.Null(games, nameof(games));
  public UserStatus Status { get; private set; } = UserStatus.Elite;

  public void SetGames(List<Game> games)
  {
    Games = Guard.Against.Null(games, nameof(games));
  }

  public void AddGame(Game game)
  {
    Games.Add(game);
  }

  public void RemoveGame(Game game)
  {
    Games.Remove(game);
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
