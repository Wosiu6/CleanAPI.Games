using System.ComponentModel.DataAnnotations;

namespace CleanAPI.Games.Web.Achievements;

public class CreateAchievementRequest
{
  public const string Route = "/Achievements";

  [Required]
  public string? Name { get; set; }
  public string? Description { get; set; }
  public double GlobalPercentage { get; set; }
}
