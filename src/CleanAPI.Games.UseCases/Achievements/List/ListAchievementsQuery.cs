using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Achievements.List;

public record ListAchievementsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<AchievementDTO>>>;
