using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.UseCases.Games.Update;

public class UpdateGameHandler(IRepository<Game> _repository)
  : ICommandHandler<UpdateGameCommand, Result<GameDTO>>
{
  public async Task<Result<GameDTO>> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
  {
    var existingGame = await _repository.GetByIdAsync(request.GameId, cancellationToken);
    if (existingGame == null)
    {
      return Result.NotFound();
    }

    existingGame.UpdateName(request.NewName!);

    await _repository.UpdateAsync(existingGame, cancellationToken);

    return Result.Success(new GameDTO(existingGame.Id,
      existingGame.Name, existingGame.SteamUrl ?? "", existingGame.AchievementsMetaData.Achievements.AsDtos()));
  }
}
