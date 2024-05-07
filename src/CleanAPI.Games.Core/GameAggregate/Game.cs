using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.AchievementAggregate;
using CleanAPI.Games.Core.AchievementAggregate.Events;

namespace CleanAPI.Games.Core.GameAggregate;

public class Game(string name, string? steamUrl) : EntityBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public string? SteamUrl { get; private set; } = Guard.Against.NullOrEmpty(steamUrl, nameof(steamUrl));
  public GameStatus Status { get; private set; } = GameStatus.New;

  private List<Achievement> _achievements = new List<Achievement>();
  public IEnumerable<Achievement> Achievements => _achievements.AsReadOnly();

  public void AddAchievement(Achievement newAchievement)
  {
    Guard.Against.Null(newAchievement, nameof(newAchievement));
    _achievements.Add(newAchievement);

    var newAchievementAddedEvent = new NewAchievementAddedEvent(this, newAchievement);
    //dispatch
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }

  public void UpdateSteamUrl(string newUrl)
  {
    SteamUrl = Guard.Against.NullOrEmpty(newUrl, nameof(newUrl));
  }
}
