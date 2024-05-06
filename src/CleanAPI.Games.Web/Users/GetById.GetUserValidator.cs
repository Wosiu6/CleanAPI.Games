using FastEndpoints;
using FluentValidation;

namespace CleanAPI.Games.Web.Users;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetUserValidator : Validator<GetUserByIdRequest>
{
  public GetUserValidator()
  {
    RuleFor(x => x.UserId)
      .GreaterThan(0);
  }
}
