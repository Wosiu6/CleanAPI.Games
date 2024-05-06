using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Users.List;

public record ListUsersQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<UserDTO>>>;
