using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.GameAggregate;
using CleanAPI.Games.Core.GameAggregate.Specifications;

namespace CleanAPI.Games.UseCases.Games.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetGameHandler(IReadRepository<Game> _repository)
  : IQueryHandler<GetGameQuery, Result<GameDTO>>
{
  public async Task<Result<GameDTO>> Handle(GetGameQuery request, CancellationToken cancellationToken)
  {
    var spec = new GameByIdSpec(request.GameId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new GameDTO(entity.Id, entity.Name, entity.SteamUrl, entity.AchievementsMetaData.Achievements?.AsDtos() ?? []);
  }
}
