using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Users.Update;

public record UpdateUserCommand(int UserId, string NewName) : ICommand<Result<UserDTO>>;
