using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.Core.AchievementAggregate;

public class Achievement(string name, string? description, double globalPercentage) : EntityBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public string Description { get; private set; } = Guard.Against.NullOrEmpty(description, nameof(description));
  public double GlobalPercentage { get; private set; } = Guard.Against.Null(globalPercentage, nameof(globalPercentage));

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }

  public void UpdateDescription(string description)
  {
    Description = Guard.Against.NullOrEmpty(description, nameof(description));
  }

  public void UpdateGlobalPercentage(double globalPercentage)
  {
    GlobalPercentage = Guard.Against.Null(globalPercentage, nameof(globalPercentage));
  }
}
