using CleanAPI.Games.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace CleanAPI.Games.Web.Games;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class UpdateGameValidator : Validator<UpdateGameRequest>
{
  public UpdateGameValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.GameId)
      .Must((args, GameId) => args.Id == GameId)
      .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
  }
}
