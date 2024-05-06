using CleanAPI.Games.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace CleanAPI.Games.Web.Users;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class UpdateUserValidator : Validator<UpdateUserRequest>
{
  public UpdateUserValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.UserId)
      .Must((args, UserId) => args.Id == UserId)
      .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
  }
}
