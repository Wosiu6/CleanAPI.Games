using CleanAPI.Games.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace CleanAPI.Games.Web.Achievements;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class CreateAchievementValidator : Validator<CreateAchievementRequest>
{
  public CreateAchievementValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
  }
}
