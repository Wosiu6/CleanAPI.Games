using FastEndpoints;
using FluentValidation;

namespace CleanAPI.Games.Web.Achievements;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetAchievementValidator : Validator<GetAchievementByIdRequest>
{
  public GetAchievementValidator()
  {
    RuleFor(x => x.AchievementId)
      .GreaterThan(0);
  }
}
