using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.UseCases.Games.Create;

public class CreateGameHandler(IRepository<Game> _repository)
  : ICommandHandler<CreateGameCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateGameCommand request,
    CancellationToken cancellationToken)
  {
    var newGame = new Game(request.Name, request.SteamUrl);
    if (request.Achievements is not null)
    {
      newGame.SetAchievements(request.Achievements);
    }
    var createdItem = await _repository.AddAsync(newGame, cancellationToken);

    return createdItem.Id;
  }
}
