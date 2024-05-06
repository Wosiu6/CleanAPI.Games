using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Games.List;

public class ListGamesHandler(IListGamesQueryService _query)
  : IQueryHandler<ListGamesQuery, Result<IEnumerable<GameDTO>>>
{
  public async Task<Result<IEnumerable<GameDTO>>> Handle(ListGamesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
