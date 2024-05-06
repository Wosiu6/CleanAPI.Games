using Ardalis.Result;
using CleanAPI.Games.UseCases.Games.Get;
using CleanAPI.Games.Web.Games;
using FastEndpoints;
using MediatR;

namespace CleanAPI.Games.Web.Games;

/// <summary>
/// Get a Game by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Game record.
/// </remarks>
public class GetById(IMediator _mediator)
  : Endpoint<GetGameByIdRequest, GameRecord>
{
  public override void Configure()
  {
    Get(GetGameByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetGameByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetGameQuery(request.GameId);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new GameRecord(result.Value.Id, result.Value.Name, result.Value.SteamUrl);
    }
  }
}
