using System.ComponentModel.DataAnnotations;

namespace CleanAPI.Games.Web.Achievements;

public class UpdateAchievementRequest
{
  public const string Route = "/Achievements/{AchievementId:int}";
  public static string BuildRoute(int AchievementId) => Route.Replace("{AchievementId:int}", AchievementId.ToString());

  public int AchievementId { get; set; }

  [Required]
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }
  public string? Desciption { get; set; }
  public double GlobalPercentage { get; set; }
}
