using CleanAPI.Games.Core.AchievementAggregate;

namespace CleanAPI.Games.UseCases.Achievements;

public record AchievementDTO(int Id, string Name, string? Description, double? GlobalPercentage)
{
  public static AchievementDTO FromToDoItem(Achievement achievement) => new(achievement.Id, achievement.Name, achievement.Description, achievement.GlobalPercentage);
}
