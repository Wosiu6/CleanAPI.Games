using FastEndpoints;
using FluentValidation;

namespace CleanAPI.Games.Web.Games;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class DeleteGameValidator : Validator<DeleteGameRequest>
{
  public DeleteGameValidator()
  {
    RuleFor(x => x.GameId)
      .GreaterThan(0);
  }
}
