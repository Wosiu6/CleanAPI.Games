using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Users.Delete;

public record DeleteUserCommand(int UserId) : ICommand<Result>;
