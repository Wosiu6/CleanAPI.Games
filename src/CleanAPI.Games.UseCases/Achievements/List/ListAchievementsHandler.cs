using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Achievements.List;

public class ListGamesHandler(IListAchievementsQueryService _query)
  : IQueryHandler<ListAchievementsQuery, Result<IEnumerable<AchievementDTO>>>
{
  public async Task<Result<IEnumerable<AchievementDTO>>> Handle(ListAchievementsQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
