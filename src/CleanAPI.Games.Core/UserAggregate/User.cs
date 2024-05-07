using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.Core.UserAggregate;

public class User(string name) : EntityBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));

  private List<Game> _games = new List<Game>();
  public IEnumerable<Game> Games => _games.AsReadOnly();
  public UserStatus Status { get; private set; } = UserStatus.Elite;

  public void AddItem(Game newGame)
  {
    Guard.Against.Null(newGame, nameof(newGame));
    _games.Add(newGame);
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
