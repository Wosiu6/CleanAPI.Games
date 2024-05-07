using Ardalis.Result;
using CleanAPI.Games.Core.AchievementAggregate;

namespace CleanAPI.Games.UseCases.Achievements.Create;

/// <summary>
/// Create a new Achievement.
/// </summary>
/// <param name="Name"></param>
public record CreateAchievementCommand(string Name, string Description, double GlobalPercentage) : Ardalis.SharedKernel.ICommand<Result<int>>;
