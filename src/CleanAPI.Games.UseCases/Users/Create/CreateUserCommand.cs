using Ardalis.Result;
using CleanAPI.Games.Core.GameAggregate;
using CleanAPI.Games.Core.UserAggregate;

namespace CleanAPI.Games.UseCases.Users.Create;

/// <summary>
/// Create a new User.
/// </summary>
/// <param name="Name"></param>
public record CreateUserCommand(string Name) : Ardalis.SharedKernel.ICommand<Result<int>>;
