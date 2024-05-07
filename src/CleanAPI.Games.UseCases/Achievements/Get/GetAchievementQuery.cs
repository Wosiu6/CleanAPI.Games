using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Achievements.Get;

public record GetAchievementQuery(int AchievementId) : IQuery<Result<AchievementDTO>>;
