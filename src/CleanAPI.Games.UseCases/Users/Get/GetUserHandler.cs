using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.UserAggregate;
using CleanAPI.Games.Core.UserAggregate.Specifications;
using CleanAPI.Games.UseCases.Games;

namespace CleanAPI.Games.UseCases.Users.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetUserHandler(IReadRepository<User> _repository)
  : IQueryHandler<GetUserQuery, Result<UserDTO>>
{
  public async Task<Result<UserDTO>> Handle(GetUserQuery request, CancellationToken cancellationToken)
  {
    var spec = new UserByIdSpec(request.UserId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    var ga = entity.Games;

    return new UserDTO(entity.Id, entity.Name, entity.Games.Select(GameDTO.FromToDoItem).ToList());
  }
}
