using CleanAPI.Games.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace CleanAPI.Games.Web.Games;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class CreateGameValidator : Validator<CreateGameRequest>
{
  public CreateGameValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
  }
}
