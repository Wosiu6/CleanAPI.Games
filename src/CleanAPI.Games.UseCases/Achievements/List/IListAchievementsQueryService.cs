namespace CleanAPI.Games.UseCases.Achievements.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListAchievementsQueryService
{
  Task<IEnumerable<AchievementDTO>> ListAsync();
}
