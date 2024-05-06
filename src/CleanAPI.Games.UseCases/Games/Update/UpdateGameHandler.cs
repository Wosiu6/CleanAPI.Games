using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.GameAggregate;

namespace CleanAPI.Games.UseCases.Games.Update;

public class UpdateGameHandler(IRepository<Game> _repository)
  : ICommandHandler<UpdateGameCommand, Result<GameDTO>>
{
  public async Task<Result<GameDTO>> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
  {
    var existingContributor = await _repository.GetByIdAsync(request.ContributorId, cancellationToken);
    if (existingContributor == null)
    {
      return Result.NotFound();
    }

    existingContributor.UpdateName(request.NewName!);

    await _repository.UpdateAsync(existingContributor, cancellationToken);

    return Result.Success(new GameDTO(existingContributor.Id,
      existingContributor.Name, existingContributor.SteamUrl ?? ""));
  }
}
