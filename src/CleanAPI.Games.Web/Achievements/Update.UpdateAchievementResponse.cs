namespace CleanAPI.Games.Web.Achievements;

public class UpdateAchievementResponse(AchievementRecord Achievement)
{
  public AchievementRecord Achievement { get; set; } = Achievement;
}
