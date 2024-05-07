using CleanAPI.Games.UseCases.Achievements;
using CleanAPI.Games.UseCases.Achievements.List;

namespace CleanAPI.Games.Infrastructure.Data.Queries;

public class FakeListAchievementsQueryService : IListAchievementsQueryService
{
  public Task<IEnumerable<AchievementDTO>> ListAsync()
  {
    List<AchievementDTO> result =
        [new AchievementDTO(1, "Fake Achiev 1", "Fake Desc 1", 54),
        new AchievementDTO(2, "Fake Achiev 2", "Fake Desc 1", 3.2)];

    return Task.FromResult(result.AsEnumerable());
  }
}
