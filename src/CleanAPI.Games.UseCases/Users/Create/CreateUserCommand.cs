using Ardalis.Result;
using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.UseCases.Users.Create;

/// <summary>
/// Create a new User.
/// </summary>
/// <param name="Name"></param>
public record CreateUserCommand(string Name, List<Game>? Games) : Ardalis.SharedKernel.ICommand<Result<int>>;
