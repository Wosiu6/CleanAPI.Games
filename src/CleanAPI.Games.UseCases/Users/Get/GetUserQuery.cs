using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Users.Get;

public record GetUserQuery(int UserId) : IQuery<Result<UserDTO>>;
