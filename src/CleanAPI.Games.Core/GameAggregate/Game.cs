using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Newtonsoft.Json;

namespace CleanAPI.Games.Core.GameAggregate;

public class Game(string name, string? steamUrl) : EntityBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public string? SteamUrl { get; private set; } = Guard.Against.NullOrEmpty(steamUrl, nameof(steamUrl));
  public GameStatus Status { get; private set; } = GameStatus.New;
  public AchievementsMetaData? AchievementsMetaData { get; private set; }
  

  public void SetAchievements(string achievements)
  {
    AchievementsMetaData = JsonConvert.DeserializeObject<AchievementsMetaData>(achievements);
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

public class AchievementsMetaData
{
  public List<Achievement>? Achievements { get; private set; }
}

public class Achievement : ValueObject
{
  public string Name { get; private set; } = string.Empty;
  public string? Description { get; private set; } = string.Empty;
  public double? GlobalPercentage { get; private set; } = null;

  public Achievement(string name,
    string description,
    double? globalPercentage)
  {
    Name = name;
    Description = description;
    GlobalPercentage = globalPercentage;
  }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Name;
    yield return Description ?? string.Empty;
    yield return GlobalPercentage ?? 0;
  }
}
