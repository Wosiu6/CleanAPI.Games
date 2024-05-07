using CleanAPI.Games.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace CleanAPI.Games.Web.Achievements;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class UpdateAchievementValidator : Validator<UpdateAchievementRequest>
{
  public UpdateAchievementValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.AchievementId)
      .Must((args, AchievementId) => args.Id == AchievementId)
      .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
  }
}
