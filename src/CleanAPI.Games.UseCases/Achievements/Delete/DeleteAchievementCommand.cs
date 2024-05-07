using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanAPI.Games.UseCases.Achievements.Delete;

public record DeleteAchievementCommand(int AchievementId) : ICommand<Result>;
