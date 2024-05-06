using FastEndpoints;
using FluentValidation;

namespace CleanAPI.Games.Web.Games;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetGameValidator : Validator<GetGameByIdRequest>
{
  public GetGameValidator()
  {
    RuleFor(x => x.GameId)
      .GreaterThan(0);
  }
}
