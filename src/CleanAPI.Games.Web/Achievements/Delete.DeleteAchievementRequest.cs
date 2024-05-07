using CleanAPI.Games.Core.AchievementAggregate;

namespace CleanAPI.Games.Web.Achievements;

public record DeleteAchievementRequest
{
  public const string Route = "/Achievements/{AchievementId:int}";
  public static string BuildRoute(int AchievementId) => Route.Replace("{AchievementId:int}", AchievementId.ToString());

  public int AchievementId { get; set; }
}
