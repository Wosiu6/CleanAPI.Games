using Ardalis.Specification;

namespace CleanAPI.Games.Core.AchievementAggregate.Specifications;

public class AchievementByIdSpec : Specification<Achievement>
{
  public AchievementByIdSpec(int achievementId)
  {
    Query
        .Where(achievement => achievement.Id == achievementId);
  }
}
