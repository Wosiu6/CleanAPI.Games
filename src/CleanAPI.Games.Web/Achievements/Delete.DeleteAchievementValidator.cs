using FastEndpoints;
using FluentValidation;

namespace CleanAPI.Games.Web.Achievements;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class DeleteAchievementValidator : Validator<DeleteAchievementRequest>
{
  public DeleteAchievementValidator()
  {
    RuleFor(x => x.AchievementId)
      .GreaterThan(0);
  }
}
