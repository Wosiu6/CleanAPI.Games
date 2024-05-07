using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.AchievementAggregate;
using CleanAPI.Games.Core.AchievementAggregate.Specifications;

namespace CleanAPI.Games.UseCases.Achievements.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetAchievementHandler(IReadRepository<Achievement> _repository)
  : IQueryHandler<GetAchievementQuery, Result<AchievementDTO>>
{
  public async Task<Result<AchievementDTO>> Handle(GetAchievementQuery request, CancellationToken cancellationToken)
  {
    var spec = new AchievementByIdSpec(request.AchievementId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new AchievementDTO(entity.Id, entity.Name, entity.Description, entity.GlobalPercentage);
  }
}
