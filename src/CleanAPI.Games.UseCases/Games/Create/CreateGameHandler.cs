using Ardalis.Result;
using Ardalis.SharedKernel;
using CleanAPI.Games.Core.ContributorAggregate;

namespace CleanAPI.Games.UseCases.Games.Create;

public class CreateGameHandler(IRepository<Contributor> _repository)
  : ICommandHandler<CreateGameCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateGameCommand request,
    CancellationToken cancellationToken)
  {
    var newContributor = new Contributor(request.Name);
    if (!string.IsNullOrEmpty(request.SteamUrl))
    {
      newContributor.SetPhoneNumber(request.SteamUrl);
    }
    var createdItem = await _repository.AddAsync(newContributor, cancellationToken);

    return createdItem.Id;
  }
}
