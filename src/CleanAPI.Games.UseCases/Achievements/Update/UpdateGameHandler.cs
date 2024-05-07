using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.AchievementAggregate;

namespace CleanAPI.Games.UseCases.Achievements.Update;

public class UpdateAchievementHandler(IRepository<Achievement> _repository)
  : ICommandHandler<UpdateAchievementCommand, Result<AchievementDTO>>
{
  public async Task<Result<AchievementDTO>> Handle(UpdateAchievementCommand request, CancellationToken cancellationToken)
  {
    var existingAchievement = await _repository.GetByIdAsync(request.AchievementId, cancellationToken);
    if (existingAchievement == null)
    {
      return Result.NotFound();
    }

    existingAchievement.UpdateName(request.NewName!);

    await _repository.UpdateAsync(existingAchievement, cancellationToken);

    return Result.Success(new AchievementDTO(existingAchievement.Id,
      existingAchievement.Name, existingAchievement.Description, existingAchievement.GlobalPercentage));
  }
}
