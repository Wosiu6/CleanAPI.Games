using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.AchievementAggregate;

namespace CleanAPI.Games.UseCases.Achievements.Create;

public class CreateAchievementHandler(IRepository<Achievement> _repository)
  : ICommandHandler<CreateAchievementCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateAchievementCommand request,
    CancellationToken cancellationToken)
  {
    var newGame = new Achievement(request.Name, request.Description, request.GlobalPercentage);
    var createdItem = await _repository.AddAsync(newGame, cancellationToken);

    return createdItem.Id;
  }
}
