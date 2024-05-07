using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Achievements.Update;

public record UpdateAchievementCommand(int AchievementId, string NewName, string NewDescription, double NewGlobalPercentage) : ICommand<Result<AchievementDTO>>;
